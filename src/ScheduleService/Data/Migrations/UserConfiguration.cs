using System.Data.Entity.Migrations;
using ScheduleService.Data;
using ScheduleService.Data.Model;
using System.Linq;
using ScheduleService.Security;
using System.Collections.Generic;

namespace ScheduleService.Migrations
{
    public class UserConfiguration
    {
        public static void Seed(ScheduleServiceContext context) {

            var systemRole = context.Roles.First(x => x.Name == Roles.SYSTEM);
            var roles = new List<Role>();
            var tenant = context.Tenants.Single(x => x.Name == "Default");

            roles.Add(systemRole);
            context.Users.AddOrUpdate(x => x.Username, new User()
            {
                Username = "system",
                Password = new EncryptionService().TransformPassword("system"),
                Roles = roles,
                TenantId = tenant.Id
            });

            context.SaveChanges();
        }
    }
}
