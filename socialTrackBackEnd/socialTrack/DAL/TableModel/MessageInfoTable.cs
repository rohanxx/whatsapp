using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace socialTrack.DAL.TableModel
{
    public class MessageInfoTable
    {
        [Key]
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string SendTo { get; set; }
        public string SendFrom { get; set; }
        public string Message { get; set; }
        public string ConversationSid { get; set; }
        public DateTime? SentTime { get; set; }
        public DateTime? ReceiveTime { get; set; }
        public string Status { get; set; }
    }
}
