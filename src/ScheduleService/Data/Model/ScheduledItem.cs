using System;
using ScheduleService.Data.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleService.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class ScheduledItem: ILoggable
    {
        public int Id { get; set; }
        
		[ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        
		public DateTime CreatedOn { get; set; }
        
		public DateTime LastModifiedOn { get; set; }
        
		public string CreatedBy { get; set; }
        
		public string LastModifiedBy { get; set; }
        
		public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}
