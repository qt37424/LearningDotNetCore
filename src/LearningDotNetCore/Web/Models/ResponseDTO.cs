/// ======================================================================
/// File Description
///     This will define the respone ORM when send request CRUD
/// ======================================================================

namespace Web.Models
{
    public class ResponseDTO
    {
        #region [Properties]

        /// <summary>
        /// Object Result or ORM result
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
