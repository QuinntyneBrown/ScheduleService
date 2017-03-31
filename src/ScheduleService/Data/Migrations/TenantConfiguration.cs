using System.Data.Entity.Migrations;
using ScheduleService.Data;
using ScheduleService.Data.Model;

namespace ScheduleService.Migrations
{
    public class TenantConfiguration
    {
        public static void Seed(ScheduleServiceContext context) {

            context.Tenants.AddOrUpdate(x => x.Name, new Tenant()
            {
                Name = "Default"
            });

            context.SaveChanges();
        }
    }
}
