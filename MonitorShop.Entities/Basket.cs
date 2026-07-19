using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorShop.Entities
{
    public class Basket
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }
    }
}
