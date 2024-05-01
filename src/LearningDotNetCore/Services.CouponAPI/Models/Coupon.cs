using System.ComponentModel.DataAnnotations;

namespace Services.CouponAPI.Models
{
    public class Coupon
    {
        #region [Properties]

        /// <summary>
        /// CouponID
        /// </summary>
        /// Nghien cuu xem co cach nao change coupon id thanh string de add uuid duoc khong? Hoac don gian la de add uuid
        [Key]
        public int CouponId { get; set; }

        /// <summary>
        /// Coupon code
        /// </summary>
        [Required]
        public string CouponCode { get; set; }

        /// <summary>
        /// Discount Amount
        /// </summary>
        [Required]
        public double DiscountAmount { get; set; }

        /// <summary>
        /// Min Amount value
        /// </summary>
        public int MinAmount { get; set; }

        /// <summary>
        /// Last Updated
        /// </summary>
        public DateTime LastUpdated { get; set; }

        #endregion
    }
}
