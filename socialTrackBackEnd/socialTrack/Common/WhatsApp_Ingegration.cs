using Microsoft.Extensions.Configuration;
using socialTrack.Model.MessageInfoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Conversations.V1.Conversation;
using Twilio.TwiML.Messaging;
using Twilio.Types;
using WhatsAppApi;


using Twilio.Rest.Api.V2010.Account;


namespace socialTrack.Common
{
    public class WhatsApp_Ingegration
    {
        private readonly IConfiguration _config;
        public WhatsApp_Ingegration(IConfiguration config)
        {
            _config = config;
        }
        //  public void SendMessage(string phoneNo, string messageBody)
        //  {
        //      Message message = new Message();
        //      phoneNo = "+91" + phoneNo;
        //      string accountSid = "ACdd718151a50ce287367c3f79bfead065";
        //      string authToken = "223795ecc292e05c31491d3d371bb7d9";

        //      TwilioClient.Init(accountSid, authToken);

        //      var participant = ParticipantResource.Create(
        //          messagingBindingAddress: "9557554796",
        //          messagingBindingProxyAddress: "+14434291835",
        //          pathConversationSid: "CHXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        //      );

        //      Console.WriteLine(participant.Sid);
        //  }
        //  public string chat(string PhoneNumber, string UserMessage
        //      { 
        //Message message = new Message();
        // PhoneNumber = "whatsaap:+91" + PhoneNumber;

        //  var accountSid = "ACdc382fc380f53c4bbd81291d5af472c5";
        // var authToken = "caad0edf4c0fedc71cd9d2c17bccb01e";
        // TwilioClient.Init(accountSid, authToken);
        //var participant = ParticipantResource.Create(
        //   messagingBindingAddress: "whatsaap:+91" + PhoneNumber,
        //   messagingBindingProxyAddress: "+14434291835"

        //      return "";
        //  }

        //public string sendMessage(string To,string Message)
        //{
        //    string status = "";
        //    WhatsApp wa = new WhatsApp("9557554796", "12345678", "sandeep", false, false);
        //    wa.OnConnectSuccess += () =>
        //     {
        //         wa.OnLoginSuccess += (PhoneNumber, data) =>
        //          {
        //              status = "connection success";
        //              wa.SendMessage(To, Message);
        //              status = "Message Sent Success";
        //          };
        //         wa.OnLoginFailed += (data) =>
        //         {
        //             status = "Status Failed" + data;
        //         };
        //         wa.Login();
        //     };
        //    wa.OnConnectFailed += (ex) =>
        //     {
        //         status = "Connection Failed" + ex.StackTrace;
        //     };
        //    wa.Connect();
        //    return status;
        //}
        public Twilio.Rest.Api.V2010.Account.MessageResource SmsCommon(ChatModel chat) {
            var accountSid = _config.GetSection("TwilioCredentials:AccountSid").Value;
            var authToken = _config.GetSection("TwilioCredentials:AuthToken").Value;
            TwilioClient.Init(accountSid, authToken);
            var messageOptions = new Twilio.Rest.Api.V2010.Account.CreateMessageOptions(new PhoneNumber("whatsapp:+91" + chat.PhoneNumber));

            string whatsAppNumber = _config.GetSection("TwilioCredentials:WhatsAppNumber").Value;
            messageOptions.From = new PhoneNumber("whatsapp:" + whatsAppNumber);
            messageOptions.Body = chat.UserMessage;

            return Twilio.Rest.Api.V2010.Account.MessageResource.Create(messageOptions);

        }
    }
}