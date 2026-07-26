using MonitorShop.Business.Abstract;
using MonitorShop.DataAccess.Repositories;
using MonitorShop.Entities;

namespace MonitorShop.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IGenericRepository<Role> _roleRepository;

        public RoleManager(IGenericRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public Role GetById(int id)
        {
            return _roleRepository.GetById(id);
        }

        public void Add(Role role)
        {
            _roleRepository.Add(role);
        }

        public void Update(Role role)
        {
            _roleRepository.Update(role);
        }

        public void Delete(Role role)
        {
            _roleRepository.Delete(role);
        }
    }
}