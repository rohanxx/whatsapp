using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace socialTrack.DAL.TableModel
{
    public class AccountsTable:BasicEntity
    {
        [Key]
        public string User_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email_Id { get; set; }
        public string Contact { get; set; }
        public string User_Password { get; set; }
        public DateTime Last_LogIn_Date { get; set; }
        public DateTime Password_GenerateDateTime { get; set; }
        public string OTP { get; set; }
        public DateTime OTP_GenerateTime { get; set; }
        public bool Verified { get; set; }
    }
}

