using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialTrack.DAL.TableModel
{
    public class BasicEntity
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsUpdated { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public DateTime? updatedDateTime { get; set; }
    }
}

