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
    public class AddOrUpdateBrandCommand
    {
        public class AddOrUpdateBrandRequest : IRequest<AddOrUpdateBrandResponse>
        {
            public BrandApiModel Brand { get; set; }
            public int? TenantId { get; set; }
        }

        public class AddOrUpdateBrandResponse { }

        public class AddOrUpdateBrandHandler : IAsyncRequestHandler<AddOrUpdateBrandRequest, AddOrUpdateBrandResponse>
        {
            public AddOrUpdateBrandHandler(ScheduleServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateBrandResponse> Handle(AddOrUpdateBrandRequest request)
            {
                var entity = await _context.Brands
                    .SingleOrDefaultAsync(x => x.Id == request.Brand.Id && x.TenantId == request.TenantId);
                if (entity == null) _context.Brands.Add(entity = new Brand());
                entity.Name = request.Brand.Name;
                entity.TenantId = request.TenantId;

                await _context.SaveChangesAsync();

                return new AddOrUpdateBrandResponse();
            }

            private readonly ScheduleServiceContext _context;
            private readonly ICache _cache;
        }

    }

}
