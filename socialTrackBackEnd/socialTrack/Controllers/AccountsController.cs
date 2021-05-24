using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using socialTrack.Common;
using socialTrack.DAL.Context;
using socialTrack.DAL.TableModel;
using socialTrack.Model;
using socialTrack.Model.AccountsModel;
using socialTrack.Model.MessageInfoModels;
using socialTrack.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using WhatsAppApi;

namespace socialTrack.Controllers
{
    [Route("Accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly SocialTrackContext _dbcontext;
        private readonly OTP_Manager _otpManager;
        
        public AccountsController(SocialTrackContext dbcontext, OTP_Manager otpManager)
        {
            _dbcontext = dbcontext;
            _otpManager = otpManager;
          
        }
       
     
      
        [Route("UpdateUser")]
        [HttpPut]
        public ReturnModel UpdateUser(UpdateUserModel updateUser)
        {
            ReturnModel returnModel = new ReturnModel();
            try
            {
                var user = _dbcontext.AccountsTable.FirstOrDefault(a => a.Contact == updateUser.Contact);
                if (user != null)
                {
                    user.First_Name = updateUser.FirstName;
                    user.Last_Name = updateUser.LastName;
                    user.User_Password = updateUser.UserPassword;
                    user.IsUpdated = true;
                    user.updatedDateTime = DateTime.UtcNow;
                    _dbcontext.AccountsTable.Update(user);
                    var Isupdated = _dbcontext.SaveChanges();
                    if (Isupdated > 0)
                    {
                        returnModel.StatusCode = HttpStatusCode.OK;
                        returnModel.Message = "Successfully updated user info";
                        returnModel.ResponseData = user;
                    }
                    else
                    {
                        returnModel.StatusCode = HttpStatusCode.BadRequest;
                        returnModel.Message = "can't update user info";
                    }
                }
                else
                {
                    returnModel.StatusCode = HttpStatusCode.NotFound;
                    returnModel.Message = "user not found";
                }

            }
            catch (Exception ex)
            {
                returnModel.StatusCode = HttpStatusCode.InternalServerError;
                returnModel.Message = ex.Message.ToString();
            }
            return returnModel;

        }
        [Route("forgetpasswordUser")]
        [HttpPost]
        public ReturnModel forgetpasswordUser(string email)
        {
            ReturnModel returnModel = new ReturnModel();
            var user = _dbcontext.AccountsTable.FirstOrDefault(a => a.Email_Id.ToLower() == email.ToLower());
            if (user != null)
            {
                string OTP = _otpManager.GenerateOtp();
                bool isSent = _otpManager.sendotp(user.Contact, OTP);
                if (isSent)
                {
                    user.OTP = OTP;
                    user.OTP_GenerateTime = DateTime.UtcNow;
                    _dbcontext.AccountsTable.Update(user);
                    int ff = _dbcontext.SaveChanges();
                    if (ff > 0)
                    {
                        returnModel.Message = "OTP sent successfully";
                        returnModel.StatusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        returnModel.Message = "your request can't be process right now";
                        returnModel.StatusCode = HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    returnModel.Message = "OTP Can't be sent right now";
                    returnModel.StatusCode = HttpStatusCode.BadRequest;
                }
            }
            else
            {
                returnModel.Message = "Email dosen't exist";
                returnModel.StatusCode = HttpStatusCode.NotFound;
            }
            return returnModel;
        }
        [Route("resetpswdUser")]
        [HttpPost]
        public ReturnModel resetpswdUser(string email, string otp, string password)
        {
            ReturnModel returnModel = new ReturnModel();
            var user = _dbcontext.AccountsTable.FirstOrDefault(a => a.Email_Id.ToLower() == email.ToLower() && a.OTP == otp);
            if (user != null)
            {
                var diff = DateTime.UtcNow - user.OTP_GenerateTime;
                if (user.OTP == otp && diff.TotalMinutes < 10)
                {
                    user.User_Password = password;
                    _dbcontext.Update(user);
                    int isSaved = _dbcontext.SaveChanges();
                    if (isSaved > 0)
                    {
                        returnModel.Message = "You're verified now, please proceed for login";
                        returnModel.StatusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        returnModel.Message = "You can't be verified now, please try again later";
                        returnModel.StatusCode = HttpStatusCode.InternalServerError;
                    }
                }
                else
                {
                    returnModel.Message = "Either otp is incorrect or expired";
                    returnModel.StatusCode = HttpStatusCode.BadRequest;
                }
            }
            else
            {
                returnModel.Message = "OTP is invalid or user doesn't exist";
                returnModel.StatusCode = HttpStatusCode.NotFound;
            }

            return returnModel;
        }


        [Route("Profile")]
        [HttpGet]
        public ReturnModel Profile(string id)
        {
            ReturnModel returnModel = new ReturnModel();
            var user = _dbcontext.RegisterTables.FirstOrDefault(a => a.Id == int.Parse(id) && a.IsActive && !a.IsDeleted);

            if (user != null)
            {
                returnModel.Message = "Success";
                returnModel.StatusCode = HttpStatusCode.OK;
                returnModel.ResponseData = user;
            }
            else
            {
                returnModel.Message = "No user found";
                returnModel.StatusCode = HttpStatusCode.NotFound;
            }
            return returnModel;
        }

        [Route("EditProfile")]
        [HttpPost]
        public ReturnModel EditProfile(EditProfile model)
        {
            ReturnModel returnModel = new ReturnModel();
            var user = _dbcontext.RegisterTables.FirstOrDefault(a => a.Id == int.Parse(model.id) && a.IsActive && !a.IsDeleted);
            if (user != null)
            {
                user.First_Name = model.firstname;
                user.Last_Name = model.lastname;
                user.Contact = model.contact;
                user.updatedDateTime = DateTime.UtcNow;
                user.IsUpdated = true;
                _dbcontext.SaveChanges();

                returnModel.Message = "Profile successfully updated";
                returnModel.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                returnModel.Message = "No user found";
                returnModel.StatusCode = HttpStatusCode.NotFound;
            }
            return returnModel;
        }

       
    }

}

