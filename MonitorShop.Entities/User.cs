using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorShop.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public int RoleId { get; set; }

        public Role Role { get; set; } = null!;

        public List<Order> Orders { get; set; } = new List<Order>();

        public List<Basket> Baskets { get; set; } = new List<Basket>();
    }
}
