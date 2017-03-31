using ScheduleService.Data.Model;

namespace ScheduleService.Features.Brands
{
    public class BrandApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }

        public static TModel FromBrand<TModel>(Brand brand) where
            TModel : BrandApiModel, new()
        {
            var model = new TModel();
            model.Id = brand.Id;
            model.TenantId = brand.TenantId;
            model.Name = brand.Name;
            return model;
        }

        public static BrandApiModel FromBrand(Brand brand)
            => FromBrand<BrandApiModel>(brand);

    }
}
