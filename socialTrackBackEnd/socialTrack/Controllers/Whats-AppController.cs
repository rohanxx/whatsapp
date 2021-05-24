using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using socialTrack.Common;
using socialTrack.DAL.Context;
using socialTrack.DAL.TableModel;
using socialTrack.Model;
using socialTrack.Model.MessageInfoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace socialTrack.Controllers
{
    [Route("WhatsApp")]
    [ApiController]
    public class Whats_AppController : ControllerBase
    {
        private readonly SocialTrackContext _dbcontext;
        private readonly IConfiguration _config;
        private readonly WhatsApp_Ingegration _integrate;
        public Whats_AppController(SocialTrackContext dbcontext, IConfiguration config, WhatsApp_Ingegration integrate)

        {
            _dbcontext = dbcontext;
            _config = config;
            _integrate = integrate;

        }
        [Route("GetChats")]
        [HttpGet]
        public ReturnModel GetChats()
        {
            ReturnModel returnModel = new ReturnModel();
            try
            {

                List<GetChatModel> message = (from chat in _dbcontext.MessageInfoTable
                                              where chat.SendTo != "null" && chat.SendTo != "+14155238886"
                                              select new GetChatModel
                                              {

                                                  SendFrom = chat.SendFrom,
                                                  Message = chat.Message,
                                                  SentTime = chat.SentTime,
                                                  SendTo = chat.SendTo,
                                                  ReceiveTime = chat.ReceiveTime,
                                              }).OrderByDescending(y => y.SentTime).ToList();
                if (message.Count > 0)
                {
                    var ff = message.GroupBy(x => x.SendTo).Select(s => s.FirstOrDefault()).ToList();
                    returnModel.Message = "chats";
                    returnModel.StatusCode = HttpStatusCode.OK;
                    returnModel.ResponseData = ff;
                }

                else
                {
                    returnModel.Message = "No data found";
                    returnModel.StatusCode = HttpStatusCode.NotFound;
                }

            }
            catch (Exception ex)
            {
                returnModel.Message = ex.Message;
                returnModel.StatusCode = HttpStatusCode.BadRequest;

            }
            return returnModel;
        }
        [Route("GetChatByNumber")]
        [HttpGet]
        public ReturnModel GetChatByNumber(string number)
        {
            ReturnModel returnModel = new ReturnModel();
            List<GetChatModel> chatModel = new List<GetChatModel>();
            try
            {
                number = "+91" + number.Trim();
                var sentData = (from mm in _dbcontext.MessageInfoTable
                                where mm.SendTo == number || mm.SendFrom == number
                                select new GetChatModel
                                {
                                    SendTo = mm.SendTo,
                                    Message = mm.Message,
                                    ReceiveTime = mm.ReceiveTime,
                                    SentTime = mm.SentTime,
                                    Direction = mm.Status
                                }).ToList();
                if (sentData.Any())
                {
                    returnModel.StatusCode = HttpStatusCode.OK;
                    returnModel.ResponseData = sentData;
                    returnModel.Message = "Data Load Successfully";
                }
                else
                {
                    returnModel.StatusCode = HttpStatusCode.NotFound;
                }
            }
            catch (Exception ex)
            {
                returnModel.StatusCode = HttpStatusCode.InternalServerError;
                returnModel.Message = "Internal Server Error";
            }
            return returnModel;
        }
        [Route("SendWhatsaapMessage")]
        [HttpPost]
        public ReturnModel SendWhatsaapMessage([FromBody] ChatModel chat)
        {

            ReturnModel returnModel = new ReturnModel();
            var message =_integrate.SmsCommon(chat);


            if (message.ErrorCode == null)
            {
                Console.WriteLine(message.Body);
                string conversationId = message.Sid;
                MessageInfoTable messageInfoTable = new MessageInfoTable
                {

                    Message = chat.UserMessage,
                    SendFrom = _config.GetSection("TwilioCredentials:WhatsAppNumber").Value,
                    SendTo = chat.PhoneNumber,
                    ConversationSid = conversationId,
                    SentTime = DateTime.UtcNow,
                };
                _dbcontext.MessageInfoTable.Add(messageInfoTable);
                _dbcontext.SaveChanges();
            }


            else
            {
                //Error
            }
            return returnModel;
        }
        [HttpPost]
        [Route("Message")]
        public string Message([FromForm] string message)
        {
            ReturnModel returnModel = new ReturnModel();
            var receiveDateTime = DateTime.UtcNow;
            if (message != null)
            {
                MessageInfoTable response = new MessageInfoTable
                {
                    SendTo = _config.GetSection("TwilioCredentials:WhatsAppNumber").Value,
                    SendFrom = "+" + Request.Form["WaId"],
                    Message = Request.Form["Body"],
                    ConversationSid = Request.Form["MessageSid"],
                    ReceiveTime = receiveDateTime,
                    Status = Request.Form["SmsStatus"]
                };
                _dbcontext.MessageInfoTable.Add(response);
                _dbcontext.SaveChanges();
            }
            else
            {
               returnModel.StatusCode = HttpStatusCode.NotFound;
                
                returnModel.Message = "message not semd";
            }

            return message;
        }
    }
}

