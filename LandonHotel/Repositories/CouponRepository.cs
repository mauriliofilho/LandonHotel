using System.Collections.Generic;
using System.Linq;
using LandonHotel.Data;

namespace LandonHotel.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        // Stub repository data - this could be replaced by a database connection
        private readonly IList<Coupon> couponList = new List<Coupon>
        {
            new Coupon
            {
                Code = "10OFF",
                PercentageDiscount = 10,
            },
            new Coupon
            {
                Code = "50OFF",
                PercentageDiscount = 50
            }
        };

        public Coupon GetCoupon(string couponCode)
        {
            return couponList.SingleOrDefault(r => r.Code == couponCode);
        }
    }
}