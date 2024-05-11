using Web.Models;

namespace Web.Services.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO requestDto);
    }
}
