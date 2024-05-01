using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CouponAPI.Data;
using Services.CouponAPI.Models;

namespace Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        #region [Variables]

        private readonly AppDbContext _db;

        #endregion

        #region [Constructors]

        public CouponAPIController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                return objList;
            }
            catch (Exception ex) { }
            return null;
        }

        [HttpGet]
        //[Route("{id:int}")]
        public object Get(int id)
        {
            try
            {
                Coupon objList = _db.Coupons.First(i => i.CouponId == id);
                return objList;
            }
            catch (Exception ex) { }
            return null ;
        }

        #endregion
    }
}
