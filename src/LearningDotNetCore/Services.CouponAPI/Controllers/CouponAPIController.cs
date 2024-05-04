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

        #endregion

        #region Methods API

        #region [GET Methods]

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

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDTO Get(string code)
        {
            try
            {
                Coupon obj = _db.Coupons.First(i => i.CouponCode.ToLower() == code.ToLower());
                _responseDTO.Result = _mapper.Map<CouponDTO>(obj);
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;
        }

        #endregion

        #region [POST Methods]

        [HttpPost]
        public ResponseDTO Post([FromBody] CouponDTO couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                Guid myuuid = Guid.NewGuid();
                obj.CouponCode = myuuid.ToString();
                obj.LastUpdated = DateTime.UtcNow;
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                _responseDTO.Result = _mapper.Map<CouponDTO>(obj);
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;
        }

        #endregion

        #region [PUT Methods]

        [HttpPut]
        [Route("{id:int}")]
        public ResponseDTO Put([FromBody] CouponDTO couponDto, int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(i => i.CouponId == id);
                obj.DiscountAmount = couponDto.DiscountAmount;
                obj.MinAmount = couponDto.MinAmount;
                obj.LastUpdated = DateTime.UtcNow;
                _db.Coupons.Update(obj);
                _db.SaveChanges();
                _responseDTO.Result = _mapper.Map<CouponDTO>(obj);
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;
        }

        #endregion

        #region [Delete Methods]

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDTO Delete(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(i => i.CouponId == id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();
                _responseDTO.IsSuccess = true;
                _responseDTO.Message = "Successfully!";
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;
        }

        #endregion

        #endregion
    }
}
