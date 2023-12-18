using System;
using System.Collections.Generic;

#nullable disable

namespace WebsiteBanHoa_6.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? DateOfRegistration { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
