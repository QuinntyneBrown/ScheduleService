using MediatR;
using ScheduleService.Data;
using ScheduleService.Data.Model;
using ScheduleService.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ScheduleService.Features.Brands
{
    public class RemoveBrandCommand
    {
        public class RemoveBrandRequest : IRequest<RemoveBrandResponse>
        {
            public int Id { get; set; }
            public int? TenantId { get; set; }
        }

        public class RemoveBrandResponse { }

        public class RemoveBrandHandler : IAsyncRequestHandler<RemoveBrandRequest, RemoveBrandResponse>
        {
            public RemoveBrandHandler(ScheduleServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveBrandResponse> Handle(RemoveBrandRequest request)
            {
                var brand = await _context.Brands.SingleAsync(x=>x.Id == request.Id && x.TenantId == request.TenantId);
                brand.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveBrandResponse();
            }

            private readonly ScheduleServiceContext _context;
            private readonly ICache _cache;
        }
    }
}
