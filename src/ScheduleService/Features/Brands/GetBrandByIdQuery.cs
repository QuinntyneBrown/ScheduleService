using MediatR;
using ScheduleService.Data;
using ScheduleService.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ScheduleService.Features.Brands
{
    public class GetBrandByIdQuery
    {
        public class GetBrandByIdRequest : IRequest<GetBrandByIdResponse> { 
            public int Id { get; set; }
            public int? TenantId { get; set; }
        }

        public class GetBrandByIdResponse
        {
            public BrandApiModel Brand { get; set; } 
        }

        public class GetBrandByIdHandler : IAsyncRequestHandler<GetBrandByIdRequest, GetBrandByIdResponse>
        {
            public GetBrandByIdHandler(ScheduleServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetBrandByIdResponse> Handle(GetBrandByIdRequest request)
            {                
                return new GetBrandByIdResponse()
                {
                    Brand = BrandApiModel.FromBrand(await _context.Brands.SingleAsync(x=>x.Id == request.Id && x.TenantId == request.TenantId))
                };
            }

            private readonly ScheduleServiceContext _context;
            private readonly ICache _cache;
        }

    }

}
