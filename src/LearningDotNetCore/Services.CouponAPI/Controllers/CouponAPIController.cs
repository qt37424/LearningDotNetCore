using AutoMapper;
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

        /// <summary>
        /// AppDbContaext
        /// </summary>
        private readonly AppDbContext _db;

        /// <summary>
        /// ResponseDTO Type
        /// </summary>
        private ResponseDTO _responseDTO;

        /// <summary>
        /// Mapper
        /// </summary>
        private IMapper _mapper;

        #endregion

        #region [Constructors]

        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _responseDTO = new ResponseDTO();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                // _responseDTO.Result = objList; // old
                _responseDTO.Result = _mapper.Map<IEnumerable<CouponDTO>>(objList);
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
                Coupon obj = _db.Coupons.First(i => i.CouponId == id);
                _responseDTO.Result = _mapper.Map<CouponDTO>(obj);
                /// if there is no AutoMapper, developer should be code like as below
                /// --> Start
                //CouponDTO couponDTO = new CouponDTO()
                //{
                //    CouponId = objList.CouponId,
                //    CouponCode = objList.CouponCode,
                //    DiscountAmount = objList.DiscountAmount,
                //    MinAmount = objList.MinAmount,
                //};
                //_responseDTO.Result = couponDTO;
                /// --> End
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
