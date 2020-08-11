using LandonHotel.Data;

namespace LandonHotel.Repositories
{
    public interface ICouponRepository
    {
        Coupon GetCoupon(string couponCode);
    }
}