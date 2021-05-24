using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialTrack.Model.MessageInfoModels
{
    public class ChatModel
    {
        public string UserMessage { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime SentTime { get; set; }
        public DateTime ReceiveTime { get; set; }
    }
}
