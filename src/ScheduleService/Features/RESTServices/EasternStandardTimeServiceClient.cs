using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ScheduleService.Features.ScheduledItems;
using System.Net.Http;

namespace ScheduleService.Features.RESTServices
{
    public interface IEasternStandardTimeServiceClient: IRESTServiceClient { }

    public class EasternStandardTimeServiceClient : IEasternStandardTimeServiceClient
    {
        public EasternStandardTimeServiceClient(HttpClient client)
        {
            _client = client;
        }

        public Task<List<ScheduledItemApiModel>> Get(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        protected readonly HttpClient _client;
    }
}
