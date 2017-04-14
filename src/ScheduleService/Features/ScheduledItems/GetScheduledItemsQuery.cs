using MediatR;
using ScheduleService.Data;
using ScheduleService.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using System;
using ScheduleService.Features.RESTServices;

namespace ScheduleService.Features.ScheduledItems
{
    public class GetScheduledItemsQuery
    {
        public class GetScheduledItemsRequest : IRequest<GetScheduledItemsResponse> { 
            public int? TenantId { get; set; }     
            public DateTime Start { get; set; }  
            public DateTime End { get; set; }
            public string TimeZoneName { get; set; } 
        }

        public class GetScheduledItemsResponse
        {
            public ICollection<ScheduledItemApiModel> ScheduledItems { get; set; } = new HashSet<ScheduledItemApiModel>();
        }

        public class GetScheduledItemsHandler : IAsyncRequestHandler<GetScheduledItemsRequest, GetScheduledItemsResponse>
        {
            public GetScheduledItemsHandler(ICache cache, IRESTServiceClientProvider restServiceClientProvider)
            {
                _cache = cache;
                _restServiceClientProvider = restServiceClientProvider;
            }

            public async Task<GetScheduledItemsResponse> Handle(GetScheduledItemsRequest request)
            {
                var restServiceClient = _restServiceClientProvider.Get(request.TimeZoneName);
                var scheduledItems = await restServiceClient.Get(request.Start, request.End);

                return new GetScheduledItemsResponse()
                {
                    ScheduledItems = scheduledItems
                };
            }

            private readonly IRESTServiceClientProvider _restServiceClientProvider;
            private readonly ICache _cache;
        }
    }
}
