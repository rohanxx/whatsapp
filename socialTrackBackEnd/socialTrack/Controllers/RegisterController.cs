using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using socialTrack.Common;
using socialTrack.DAL.Context;
using socialTrack.DAL.TableModel;
using socialTrack.Model;
using socialTrack.Model.AccountsModel;
using socialTrack.Model.RegisterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace socialTrack.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly SocialTrackContext _dbcontext;

        public RegisterController(SocialTrackContext dbcontext)
        {
            _dbcontext = dbcontext;
          
        }
        [Route("RegisterNewUser")]
        [HttpPost]
        public ReturnModel RegisterNewUser([FromBody] NewRegistation NewAccount)
        {
            ReturnModel returnModel = new ReturnModel();
            var A_Exist = _dbcontext.RegisterTables.FirstOrDefault(u => u.Contact == NewAccount.Contact);
            if (A_Exist != null)
            {
                returnModel.StatusCode = HttpStatusCode.Continue;
                returnModel.Message = "User Already Exist, continue forword";
            }
            else
            {
                RegisterTable newtable = new RegisterTable()
                {
                    First_Name = NewAccount.First_Name,
                    Last_Name = NewAccount.Last_Name,
                    Contact = NewAccount.Contact,
                   Email=NewAccount.Email,
                   Password=NewAccount.Password,
                    IsActive = true,
                    IsDeleted = false,
                    IsUpdated = false,
                    CreatedDateTime = DateTime.UtcNow,
                    DeletedDateTime = null,
                    updatedDateTime = null,
                    UserType = "User"
                };
                _dbcontext.RegisterTables.Add(newtable);
                var IsDataSave = _dbcontext.SaveChanges();
                if (IsDataSave == 1)
                {
                    returnModel.StatusCode = HttpStatusCode.OK;
                    returnModel.Message = "New Account Add Successfully ";
                }
                else
                {
                    returnModel.StatusCode = HttpStatusCode.BadRequest;
                    returnModel.Message = "Account couldn't be added, Please try after some time";
                }
            }
            return returnModel;

        }
        [Route("DeleteAccount")]
        [HttpDelete]
        public ReturnModel DeleteUser(string    m_number)
        {
            ReturnModel returnModel = new ReturnModel();
            var Acc = _dbcontext.RegisterTables.FirstOrDefault(d => d.Contact == m_number);
            if (Acc != null)
            {
                Acc.IsActive = false;
                Acc.IsDeleted = true;
                Acc.DeletedDateTime = DateTime.UtcNow;
                _dbcontext.RegisterTables.Update(Acc);
                var IsDeleted = _dbcontext.SaveChanges();
                if (IsDeleted == 1)
                {
                    returnModel.StatusCode = HttpStatusCode.OK;
                    returnModel.Message = " Accounts Successfully Delated";
                }
                else
                {
                    returnModel.StatusCode = HttpStatusCode.BadRequest;
                    returnModel.Message = "Accounts not Deleted";
                }
            }
            else
            {
                returnModel.StatusCode = HttpStatusCode.NotFound;
                returnModel.Message = "Accounts not found";
            }
            return returnModel;
        }
        [Route("Login")]
        [HttpPost]
        public ReturnModel Login([FromBody] SignInModel log)
        {
            ReturnModel returnModel = new ReturnModel();
            var userlist = _dbcontext.RegisterTables.FirstOrDefault(x => x.Email.ToLower() == log.Email.ToLower() && x.Password == log.Password && x.IsActive && !x.IsDeleted);
            if (userlist != null)
            {
                returnModel.StatusCode = HttpStatusCode.OK;
                returnModel.ResponseData = userlist;
                returnModel.Message = "User can login successfully";
            }
            else
            {
                returnModel.StatusCode = HttpStatusCode.NotFound;
                returnModel.Message = "user not found";
            }
            return returnModel;
        }
    }
}
