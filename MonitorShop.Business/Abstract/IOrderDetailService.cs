using MonitorShop.Entities;

namespace MonitorShop.Business.Abstract
{
    public interface IOrderDetailService
    {
        List<OrderDetail> GetAll();
        OrderDetail GetById(int id);
        void Add(OrderDetail orderDetail);
        void Update(OrderDetail orderDetail);
        void Delete(OrderDetail orderDetail);
    }
}