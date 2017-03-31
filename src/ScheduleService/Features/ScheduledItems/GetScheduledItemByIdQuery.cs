using MediatR;
using ScheduleService.Data;
using ScheduleService.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ScheduleService.Features.ScheduledItems
{
    public class GetScheduledItemByIdQuery
    {
        public class GetScheduledItemByIdRequest : IRequest<GetScheduledItemByIdResponse> { 
            public int Id { get; set; }
            public int? TenantId { get; set; }
        }

        public class GetScheduledItemByIdResponse
        {
            public ScheduledItemApiModel ScheduledItem { get; set; } 
        }

        public class GetScheduledItemByIdHandler : IAsyncRequestHandler<GetScheduledItemByIdRequest, GetScheduledItemByIdResponse>
        {
            public GetScheduledItemByIdHandler(ScheduleServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetScheduledItemByIdResponse> Handle(GetScheduledItemByIdRequest request)
            {                
                return new GetScheduledItemByIdResponse()
                {
                    ScheduledItem = ScheduledItemApiModel.FromScheduledItem(await _context.ScheduledItems.SingleAsync(x=>x.Id == request.Id && x.TenantId == request.TenantId))
                };
            }

            private readonly ScheduleServiceContext _context;
            private readonly ICache _cache;
        }

    }

}
