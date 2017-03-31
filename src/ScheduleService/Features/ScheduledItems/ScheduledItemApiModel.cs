using ScheduleService.Data.Model;

namespace ScheduleService.Features.ScheduledItems
{
    public class ScheduledItemApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        

        public static TModel FromScheduledItem<TModel>(ScheduledItem scheduledItem) where
            TModel : ScheduledItemApiModel, new()
        {
            var model = new TModel();
            model.Id = scheduledItem.Id;
            model.TenantId = scheduledItem.TenantId;
            
            return model;
        }

        public static ScheduledItemApiModel FromScheduledItem(ScheduledItem scheduledItem)
            => FromScheduledItem<ScheduledItemApiModel>(scheduledItem);

    }
}
