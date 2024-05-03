using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CouponAPI.Data;
using Services.CouponAPI.Models;
using Services.CouponAPI.Models.DTO;

namespace Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        #region [Variables]

        private readonly AppDbContext _db;

        private ResponseDTO _responseDTO;

        #endregion

        #region [Constructors]

        public CouponAPIController(AppDbContext db)
        {
            _db = db;
            _responseDTO = new ResponseDTO();
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _responseDTO.Result = objList;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDTO Get(int id)
        {
            try
            {
                Coupon objList = _db.Coupons.First(i => i.CouponId == id);
                _responseDTO.Result = objList;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;
        }

        #endregion
    }
}
