using MediatR;
using ScheduleService.Data;
using ScheduleService.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ScheduleService.Features.Brands
{
    public class GetBrandsQuery
    {
        public class GetBrandsRequest : IRequest<GetBrandsResponse> { 
            public int? TenantId { get; set; }        
        }

        public class GetBrandsResponse
        {
            public ICollection<BrandApiModel> Brands { get; set; } = new HashSet<BrandApiModel>();
        }

        public class GetBrandsHandler : IAsyncRequestHandler<GetBrandsRequest, GetBrandsResponse>
        {
            public GetBrandsHandler(ScheduleServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetBrandsResponse> Handle(GetBrandsRequest request)
            {
                var brands = await _context.Brands
                    .Where( x => x.TenantId == request.TenantId )
                    .ToListAsync();

                return new GetBrandsResponse()
                {
                    Brands = brands.Select(x => BrandApiModel.FromBrand(x)).ToList()
                };
            }

            private readonly ScheduleServiceContext _context;
            private readonly ICache _cache;
        }

    }

}
