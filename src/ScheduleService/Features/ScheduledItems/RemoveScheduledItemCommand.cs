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
    public class RemoveScheduledItemCommand
    {
        public class RemoveScheduledItemRequest : IRequest<RemoveScheduledItemResponse>
        {
            public int Id { get; set; }
            public int? TenantId { get; set; }
        }

        public class RemoveScheduledItemResponse { }

        public class RemoveScheduledItemHandler : IAsyncRequestHandler<RemoveScheduledItemRequest, RemoveScheduledItemResponse>
        {
            public RemoveScheduledItemHandler(ScheduleServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveScheduledItemResponse> Handle(RemoveScheduledItemRequest request)
            {
                var scheduledItem = await _context.ScheduledItems.SingleAsync(x=>x.Id == request.Id && x.TenantId == request.TenantId);
                scheduledItem.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveScheduledItemResponse();
            }

            private readonly ScheduleServiceContext _context;
            private readonly ICache _cache;
        }
    }
}
