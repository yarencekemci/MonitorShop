using MonitorShop.Business.Abstract;
using MonitorShop.DataAccess.Repositories;
using MonitorShop.Entities;

namespace MonitorShop.Business.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IGenericRepository<Basket> _basketRepository;

        public BasketManager(IGenericRepository<Basket> basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public List<Basket> GetAll()
        {
            return _basketRepository.GetAll();
        }

        public Basket GetById(int id)
        {
            return _basketRepository.GetById(id);
        }

        public void Add(Basket basket)
        {
            _basketRepository.Add(basket);
        }

        public void Update(Basket basket)
        {
            _basketRepository.Update(basket);
        }

        public void Delete(Basket basket)
        {
            _basketRepository.Delete(basket);
        }
    }
}