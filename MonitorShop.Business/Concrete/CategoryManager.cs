using MonitorShop.Business.Abstract;
using MonitorShop.DataAccess.Repositories;
using MonitorShop.Entities;

namespace MonitorShop.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoryManager(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }

        public List<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(Category category)
        {
            _repository.Add(category);
        }

        public void Update(Category category)
        {
            _repository.Update(category);
        }

        public void Delete(Category category)
        {
            _repository.Delete(category);
        }
    }
}