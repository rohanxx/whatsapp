using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using socialTrack.DAL.Context;
using socialTrack.DAL.TableModel;
using socialTrack.Model;
using socialTrack.Model.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace socialTrack.Controllers
{
    [Route("Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly SocialTrackContext _dbcontext;
        public AdminController(SocialTrackContext dbcontext)

        {
            _dbcontext = dbcontext;
        }
        [Route("Getadmin")]
        [HttpGet]
       
        public ReturnModel Getadmin()
        {
            ReturnModel returnModel = new ReturnModel();
            List<GetAdmin> data = (from amn in _dbcontext.RegisterTables
                                                    where amn.IsActive && !amn.IsDeleted && amn.UserType=="Admin"
                                                    select new GetAdmin
                                                    {
                                                        Id = amn.Id,
                                                        Email =amn.Email,
                                                        FirstName = amn.First_Name,
                                                        LastName = amn.Last_Name,
                                                        Contact_No = amn.Contact,
                                                        Password = amn.Password
                                                    }).ToList();
            if (data.Count > 0)
            {
                returnModel.StatusCode = HttpStatusCode.OK;
                returnModel.ResponseData = data;
                returnModel.Message = "admin get SuccessFully";
            }
            else
            {
                returnModel.StatusCode = HttpStatusCode.NotFound;
                returnModel.Message = "Something is wrong";
            }
            return returnModel;
        }
        [Route("AddnewAdmin")]
        [HttpPost]
        public ReturnModel AddnewAdmin(NewAdmin admin)
        {
            ReturnModel returnModel = new ReturnModel();
            var AdminExist = _dbcontext.RegisterTables.FirstOrDefault(E => E.Contact == admin.contact && E.UserType == "Admin");
            if (AdminExist != null)
            {
                returnModel.StatusCode = HttpStatusCode.Continue;
                returnModel.Message = "Employee Already Exist, continue forword";
            }
            else
            {
                RegisterTable newAdmin = new RegisterTable()
                {
                    Email =admin.email,
                    First_Name = admin.firstname,
                    Last_Name = admin.lastname,
                    Contact = admin.contact,
                    UserType = "Admin",
                    Password = admin.password,
                   
                    IsActive = true,
                    IsDeleted = false,
                    IsUpdated = false,
                    CreatedDateTime = DateTime.UtcNow,
                    DeletedDateTime = null,
                    updatedDateTime = null
                };
                _dbcontext.RegisterTables.Add(newAdmin);
                var IsDataSave = _dbcontext.SaveChanges();
                if (IsDataSave == 1)
                {
                    returnModel.StatusCode = HttpStatusCode.OK;
                    returnModel.Message = "New Admin Add Successfully ";
                }
                else
                {
                    returnModel.StatusCode = HttpStatusCode.BadRequest;
                    returnModel.Message = "Admin couldn't be added, Please try after some time";
                }
            }
            return returnModel;
        }
        [Route("AdminUpdate")]
        [HttpPut]
        public ReturnModel AdminUpdate(UpdateAdmin update)
        {
            ReturnModel returnModel = new ReturnModel();
            var Data = _dbcontext.RegisterTables.FirstOrDefault(E => E.Id == update.AdminId && E.IsActive && !E.IsDeleted && E.UserType == "Admin");
            if (Data != null)
            {
               
                Data.Email = update.Email;
                Data.First_Name = update.FirstName;
                Data.Last_Name = update.LastName;
                Data.Contact = update.contact;
                Data.Password = update.Password;
               
                Data.IsUpdated = true;
                Data.updatedDateTime = DateTime.UtcNow;
                _dbcontext.RegisterTables.Update(Data);
                var Isupdated = _dbcontext.SaveChanges();
                if (Isupdated == 1)
                {
                    GetAdmin newupdate = new GetAdmin()
                    {
                  
                    FirstName = Data.First_Name,
                    LastName = Data.Last_Name,
                    Contact_No = Data.Contact,
                };
                    returnModel.StatusCode = HttpStatusCode.OK;
                    returnModel.ResponseData = newupdate;
                    returnModel.Message = "Employee Details SuccessFully Updated";
                }
                else
                {
                    returnModel.StatusCode = HttpStatusCode.BadRequest;
                    returnModel.Message = "Details not Updated";
                }
            }
            return returnModel;
        }
        [Route("DeleteAdmin")]
        [HttpDelete]
        public ReturnModel DeleteAdmin(int adm_ID)
        {
            ReturnModel returnModel = new ReturnModel();
            var Data = _dbcontext.RegisterTables.FirstOrDefault(x => x.Id == adm_ID && x.IsActive && !x.IsDeleted && x.UserType == "Admin");
            if (Data != null)
            {
                Data.IsActive = false;
                Data.IsDeleted = true;
                Data.DeletedDateTime = DateTime.UtcNow;
                _dbcontext.RegisterTables.Update(Data);
                var IsDeleted = _dbcontext.SaveChanges();
                if (IsDeleted == 1)
                {
                    returnModel.StatusCode = HttpStatusCode.OK;
                    returnModel.Message = "Admin Details Successfully Delated";
                }
                else
                {
                    returnModel.StatusCode = HttpStatusCode.BadRequest;
                    returnModel.Message = "Details not Deleted";
                }
            }
            else
            {
                returnModel.StatusCode = HttpStatusCode.NotFound;
                returnModel.Message = "Data not found";
            }
            return returnModel;
        }

    }
}
