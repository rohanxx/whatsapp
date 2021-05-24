using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialTrack.Model.MessageInfoModels
{
    public class AddMessageInfoModel
    {
        public string SendTo { get; set; }
        public string SendFrom { get; set; }
        public string Message { get; set; }
        public string ConversationSid { get; set; }
   
    }
}
