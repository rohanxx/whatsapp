using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialTrack.Model.MessageInfoModels
{
    public class GetChatModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SendFrom { get; set; }
        public string Message { get; set; }
        public DateTime? SentTime { get; set; }
        public string SendTo { get; set; }
        public DateTime? ReceiveTime { get; set; }
        public string Direction { get; set; }
    }
}
