using MediatR;
using ScheduleService.Data;
using ScheduleService.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ScheduleService.Features.ScheduledItems
{
    public class GetScheduledItemsQuery
    {
        public class GetScheduledItemsRequest : IRequest<GetScheduledItemsResponse> { 
            public int? TenantId { get; set; }        
        }

        public class GetScheduledItemsResponse
        {
            public ICollection<ScheduledItemApiModel> ScheduledItems { get; set; } = new HashSet<ScheduledItemApiModel>();
        }

        public class GetScheduledItemsHandler : IAsyncRequestHandler<GetScheduledItemsRequest, GetScheduledItemsResponse>
        {
            public GetScheduledItemsHandler(ScheduleServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetScheduledItemsResponse> Handle(GetScheduledItemsRequest request)
            {
                var scheduledItems = await _context.ScheduledItems
                    .Where( x => x.TenantId == request.TenantId )
                    .ToListAsync();

                return new GetScheduledItemsResponse()
                {
                    ScheduledItems = scheduledItems.Select(x => ScheduledItemApiModel.FromScheduledItem(x)).ToList()
                };
            }

            private readonly ScheduleServiceContext _context;
            private readonly ICache _cache;
        }

    }

}
