using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using socialTrack.DAL.Context;
using socialTrack.DAL.TableModel;
using socialTrack.Model;
using socialTrack.Model.ContactModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace socialTrack.Controllers
{
    [Route("Contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly SocialTrackContext _dbContext;
        public ContactsController(SocialTrackContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Route("AddNewContacts")]
        [HttpPost]
        public ReturnModel AddNewContacts(MyContactsModel myContact)
        {
            ReturnModel returnModel = new ReturnModel();
            var Number = _dbContext.ContactsTables.FirstOrDefault(n => n.PhoneNumber == myContact.PhoneNumber);
            if (Number != null)
            {
                returnModel.StatusCode = HttpStatusCode.Continue;
                returnModel.Message = "Contact Already Exist, continue forword";
            }
            else
            {
                ContactsTable contacts = new ContactsTable()
                {
                    First_Name = myContact.First_Name,
                    Last_Name = myContact.Last_Name,
                    PhoneNumber = myContact.PhoneNumber,
                    IsActive=true,
                    CreatedDateTime = DateTime.UtcNow,
                    DeletedDateTime = null,
                    updatedDateTime = null
                    
                };
                _dbContext.ContactsTables.Add(contacts);
                var IsDataSave = _dbContext.SaveChanges();
                if (IsDataSave == 1)
                {
                    returnModel.StatusCode = HttpStatusCode.OK;
                    returnModel.Message = "New Contact Add Successfully ";
                }
                else
                {
                    returnModel.StatusCode = HttpStatusCode.BadRequest;
                    returnModel.Message = "Contact couldn't be added, Please try after some time";
                }
            }
            return returnModel;
        }
        [Route("GetContats")]
        [HttpGet]
        public ReturnModel GetContacts()
        {
            ReturnModel returnModel = new ReturnModel();
            //List<MyContactsModel> ContactList = (from No. in _dbContext.ContactsTables
            //                                     where No.IsActive && !No.IsDeleted
            //                                     select new MyContactsModel
            //                                     {
            //                                         First_Name = No.First
            //                                     }).ToList();
            List<MyContactsModel> contact = (from m in _dbContext.ContactsTables
                                             where m.IsActive && !m.IsDeleted
                                             select new MyContactsModel
                                             {
                                                 First_Name = m.First_Name,
                                                 Last_Name = m.Last_Name,
                                                 PhoneNumber = m.PhoneNumber,
                                             }).ToList();
            if(contact.Count>0)
            {
                returnModel.StatusCode = HttpStatusCode.OK;
                returnModel.Message = "ContactList Successfully Get";
                returnModel.ResponseData = contact;
            }
            else
            {
                returnModel.StatusCode = HttpStatusCode.NotFound;
                returnModel.Message = "ContactList Not Found";
            }
            return returnModel;
        }
        //[Route("updateNumber")]
        //[HttpPost]
        //public ReturnModel updateNumber(MyContactsModel contactsModel)
        //{
        //    ReturnModel returnModel = new ReturnModel();
        //        var contact = _dbContext.ContactsTables.FirstOrDefault(c => c.PhoneNumber == contactsModel.PhoneNumber);
        //            if(contact !=null)
        //    {
        //        contact.First_Name = contactsModel.First_Name;
        //        contact.Last_Name = contactsModel.Last_Name;
        //        contact.PhoneNumber = contactsModel.PhoneNumber;
        //        contact.IsUpdated = true;
        //        contact.updatedDateTime = DateTime.UtcNow;
        //        _dbContext.ContactsTables.Update(contact);
        //        var Isupdated = _dbContext.SaveChanges();
        //        if(Isupdated==1)
        //        {
        //            returnModel.Message = "Contact update";
        //            returnModel.StatusCode = HttpStatusCode.OK;
        //        }
        //        else
        //        {
        //            returnModel.Message = "Contact not update";
        //            returnModel.StatusCode = HttpStatusCode.NotFound;
        //        }
        //    }
        //    else
        //    {
        //        returnModel.Message = "somthing wrong";
        //        returnModel.StatusCode = HttpStatusCode.BadRequest;
        //    }
        //    return returnModel;
        //}
    }
}