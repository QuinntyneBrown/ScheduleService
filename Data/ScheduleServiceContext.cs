using ScheduleService.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ScheduleService.Data
{
    public class ScheduleServiceContext: DbContext
    {
        public ScheduleServiceContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Contact> Contacts { get; set; }        
    }
}
