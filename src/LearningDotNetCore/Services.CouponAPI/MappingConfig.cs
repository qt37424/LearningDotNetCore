using AutoMapper;
using Services.CouponAPI.Models;
using Services.CouponAPI.Models.DTO;

namespace Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // why i must be map in 2 line code? Why do not combine it in one line of code.
                config.CreateMap<CouponDTO, Coupon>();
                config.CreateMap<Coupon, CouponDTO>();
            });
            return mappingConfig;
        }
    }
}
