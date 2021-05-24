using Microsoft.EntityFrameworkCore;
using socialTrack.DAL.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialTrack.DAL.Context
{
    public class SocialTrackContext:DbContext
    {
        public SocialTrackContext(DbContextOptions<SocialTrackContext> Option) : base(Option)
        {

        }
        public DbSet<AccountsTable> AccountsTable { get; set; }
        public DbSet<MessageInfoTable> MessageInfoTable { get; set; }
        public DbSet<ContactsTable> ContactsTables { get; set; }
        public DbSet<RegisterTable> RegisterTables { get; set; }
       


    }
}
