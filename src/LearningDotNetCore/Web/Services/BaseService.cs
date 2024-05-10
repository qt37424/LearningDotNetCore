using Newtonsoft.Json;
using System.Text;
using Web.Models;
using Web.Services.IService;
using Web.Utilities;
using System.Net;

namespace Web.Services
{
    public class BaseService : IBaseService
    {
        #region [Variables]

        private readonly IHttpClientFactory _httpClientFactory;

        #endregion

        #region [Constructors]

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BaseService() // update fix warning
        {
        }

        /// <summary>
        /// Initial constructor
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        #endregion

        #region [Methods]

        #region [Interfaces]

        /// <summary>
        /// Interface method
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        public async Task<ResponseDTO?> SendAsync(RequestDTO requestDto)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("QuangTT12API");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json"); // There is some type in here, let check it later

                // token
                message.RequestUri = new Uri(requestDto.Url);
                if(requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? apiResponse = null;

                switch(requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDTO = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                        return apiResponseDTO;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDTO
                {
                    Message = ex.Message,
                    IsSuccess = false,
                };
                return dto;
            }
        }

        #endregion

        #endregion
    }
}
