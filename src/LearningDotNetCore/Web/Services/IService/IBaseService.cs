using Web.Models;

namespace Web.Services.IService
{
    public interface IBaseService
    {
        Task<RequestDTO?> SendAsync(RequestDTO requestDto);
    }
}
