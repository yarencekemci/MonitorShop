using MonitorShop.Entities;

namespace MonitorShop.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product GetById(int id);

        void Add(Product product);

        void Update(Product product);

        void Delete(Product product);
        List<Product> GetProductsByCategory(int categoryId);
        
    }
}