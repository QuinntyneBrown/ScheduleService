using ScheduleService.Data.Helpers;
using static ScheduleService.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleService.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class Tenant: ILoggable
    {
        public int Id { get; set; }
        [Index("NameIndex", IsUnique = true)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(MaxStringLength)]
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
