using MonitorShop.Business.Abstract;
using MonitorShop.DataAccess.Repositories;
using MonitorShop.Entities;

namespace MonitorShop.Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;

        public OrderDetailManager(
            IGenericRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public List<OrderDetail> GetAll()
        {
            return _orderDetailRepository.GetAll();
        }

        public OrderDetail GetById(int id)
        {
            return _orderDetailRepository.GetById(id);
        }

        public void Add(OrderDetail orderDetail)
        {
            _orderDetailRepository.Add(orderDetail);
        }

        public void Update(OrderDetail orderDetail)
        {
            _orderDetailRepository.Update(orderDetail);
        }

        public void Delete(OrderDetail orderDetail)
        {
            _orderDetailRepository.Delete(orderDetail);
        }
    }
}