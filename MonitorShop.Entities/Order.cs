using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorShop.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public User User { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
