using MediatR;
using ScheduleService.Data;
using ScheduleService.Data.Model;
using ScheduleService.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ScheduleService.Features.ScheduledItems
{
    public class AddOrUpdateScheduledItemCommand
    {
        public class AddOrUpdateScheduledItemRequest : IRequest<AddOrUpdateScheduledItemResponse>
        {
            public ScheduledItemApiModel ScheduledItem { get; set; }
            public int? TenantId { get; set; }
        }

        public class AddOrUpdateScheduledItemResponse { }

        public class AddOrUpdateScheduledItemHandler : IAsyncRequestHandler<AddOrUpdateScheduledItemRequest, AddOrUpdateScheduledItemResponse>
        {
            public AddOrUpdateScheduledItemHandler(ScheduleServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateScheduledItemResponse> Handle(AddOrUpdateScheduledItemRequest request)
            {
                var entity = await _context.ScheduledItems
                    .SingleOrDefaultAsync(x => x.Id == request.ScheduledItem.Id && x.TenantId == request.TenantId);
                if (entity == null) _context.ScheduledItems.Add(entity = new ScheduledItem());
                
                entity.TenantId = request.TenantId;

                await _context.SaveChangesAsync();

                return new AddOrUpdateScheduledItemResponse();
            }

            private readonly ScheduleServiceContext _context;
            private readonly ICache _cache;
        }

    }

}
