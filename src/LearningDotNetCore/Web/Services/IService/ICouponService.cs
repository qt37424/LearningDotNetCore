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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ResponseDTO?> GetAllCouponAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseDTO?> GetCouponByIDAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coupondto"></param>
        /// <returns></returns>
        Task<ResponseDTO?> CreateCouponAsync(CouponDTO coupondto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coupondto"></param>
        /// <returns></returns>
        Task<ResponseDTO?> UpdateCouponAsync(CouponDTO coupondto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseDTO?> DeleteCouponAsync(int id);

        #endregion
    }
}
