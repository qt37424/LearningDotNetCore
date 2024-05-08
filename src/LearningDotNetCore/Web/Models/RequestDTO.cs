using Web.Utilities;

namespace Web.Models
{
    public class RequestDTO
    {
        #region [Properties]

        /// <summary>
        /// API Type
        /// </summary>
        /// <default>GET</default>
        public ApiType ApiType { get; set; } =  ApiType.GET;

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Data object
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Access Token
        /// </summary>
        public string AccessToken { get; set; }

        #endregion
    }
}
