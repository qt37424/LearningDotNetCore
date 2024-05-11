using Services.CouponAPI.Models.DTO;
using Web.Models;

namespace Web.Services.IService
{
    public interface ICouponService
    {
        #region [Interfaces]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CouponCode"></param>
        /// <returns></returns>
        Task<ResponseDTO?> GetCouponAsync(string CouponCode);

        Task<ResponseDTO?> GetAllCouponAsync();

        Task<ResponseDTO?> GetCouponByIDAsync(int id);

        Task<ResponseDTO?> CreateCouponAsync(CouponDTO coupondto);

        Task<ResponseDTO?> UpdateCouponAsync(CouponDTO coupondto);

        Task<ResponseDTO?> DeleteCouponAsync(int id);

        #endregion
    }
}
