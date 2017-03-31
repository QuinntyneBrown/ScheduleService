using System.Data.Entity.Migrations;
using ScheduleService.Data;
using ScheduleService.Data.Model;
using ScheduleService.Features.Users;

namespace ScheduleService.Migrations
{
    public class RoleConfiguration
    {
        public static void Seed(ScheduleServiceContext context) {

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = Roles.SYSTEM
            });

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = Roles.PRODUCT
            });

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = Roles.DEVELOPMENT
            });

            context.SaveChanges();
        }
    }
}
