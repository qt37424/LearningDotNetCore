/// ======================================================================
/// File Description
///     This will define the respone when send request
/// ======================================================================

namespace Services.CouponAPI.Models.DTO
{
    public class ResponseDTO
    {
        #region [Properties]

        /// <summary>
        /// Object Result
        /// </summary>
        public object? Result { get; set; }

        /// <summary>
        /// Is Success
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// Message Confirm
        /// </summary>
        public string Message { get; set; } = String.Empty;

        #endregion
    }
}
