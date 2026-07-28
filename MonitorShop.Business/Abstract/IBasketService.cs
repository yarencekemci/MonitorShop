using MonitorShop.Entities;

namespace MonitorShop.Business.Abstract
{
    public interface IBasketService
    {
        List<Basket> GetAll();
        Basket GetById(int id);
        void Add(Basket basket);
        void Update(Basket basket);
        void Delete(Basket basket);
    }
}