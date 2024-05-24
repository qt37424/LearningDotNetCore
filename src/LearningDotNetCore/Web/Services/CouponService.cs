using Services.CouponAPI.Models.DTO;
using Web.Models;
using Web.Services.IService;

namespace Web.Services
{
    public class CouponService : ICouponService
    {
        #region [Variables]

        private readonly IBaseService _baseService;

        #endregion

        #region [Constructors]

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        #endregion

        #region [Methods]

        public async Task<ResponseDTO?> CreateCouponAsync(CouponDTO coupondto)
        {
            // TODO
        }

        public async Task<ResponseDTO?> DeleteCouponAsync(int id)
        {
            // TODO
        }

        public async Task<ResponseDTO?> GetAllCouponAsync()
        {
            // TODO
        }

        public async Task<ResponseDTO?> GetCouponAsync(string CouponCode)
        {
            // TODO
        }

        public async Task<ResponseDTO?> GetCouponByIDAsync(int id)
        {
            // TODO
        }

        public async Task<ResponseDTO?> UpdateCouponAsync(CouponDTO coupondto)
        {
            // TODO
        }

        #endregion
    }
}
