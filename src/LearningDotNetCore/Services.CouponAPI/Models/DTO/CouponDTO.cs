/// ======================================================================
/// File Description
///     This file is defined ORM will be display in UI or ORM user can do with it
/// ======================================================================

namespace Services.CouponAPI.Models.DTO
{
    public class CouponDTO
    {
        #region [Properties]

        /// <summary>
        /// Discount Amount
        /// </summary>
        public double DiscountAmount { get; set; }

        /// <summary>
        /// Min Amount value
        /// </summary>
        public int MinAmount { get; set; }

        #endregion
    }
}
