using ScheduleService.Features.ScheduledItems;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleService.Features.RESTServices
{
    public interface IRESTServiceClient
    {
        Task<List<ScheduledItemApiModel>> Get(DateTime start, DateTime end);
    }
}
