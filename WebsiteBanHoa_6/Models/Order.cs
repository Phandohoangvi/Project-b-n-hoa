using System;
using System.Collections.Generic;

#nullable disable

namespace WebsiteBanHoa_6.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public object OrderID { get; internal set; }
        public string CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
    }
}
