using MonitorShop.Entities;

namespace MonitorShop.Business.Abstract
{
    public interface IRoleService
    {
        List<Role> GetAll();
        Role GetById(int id);
        void Add(Role role);
        void Update(Role role);
        void Delete(Role role);
    }
}