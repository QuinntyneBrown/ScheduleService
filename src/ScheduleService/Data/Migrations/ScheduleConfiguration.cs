using System.Data.Entity.Migrations;
using ScheduleService.Data;

namespace ScheduleService.Data.Migrations
{
    public class ScheduleConfiguration
    {
        public static void Seed(ScheduleServiceContext context) {

            context.SaveChanges();
        }
    }
}
