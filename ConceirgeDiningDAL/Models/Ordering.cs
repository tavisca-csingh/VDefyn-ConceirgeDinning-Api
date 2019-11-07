using System;
using System.Collections.Generic;

namespace ConceirgeDiningDAL.Models
{
    public partial class Ordering
    {
        public Ordering()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderId { get; set; }
        public string RestaurantId { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public long TotalPoints { get; set; }

        public virtual RestaurantNames Restaurant { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
