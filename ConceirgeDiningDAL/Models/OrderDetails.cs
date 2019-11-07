using System;
using System.Collections.Generic;

namespace ConceirgeDiningDAL.Models
{
    public partial class OrderDetails
    {
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Ordering Order { get; set; }
    }
}
