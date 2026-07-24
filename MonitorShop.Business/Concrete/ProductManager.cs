using MonitorShop.Business.Abstract;
using MonitorShop.DataAccess.Repositories;
using MonitorShop.Entities;

namespace MonitorShop.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductManager(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productRepository
                .GetAll()
                .Where(x => x.CategoryId == categoryId)
                .ToList();
        }

        

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}