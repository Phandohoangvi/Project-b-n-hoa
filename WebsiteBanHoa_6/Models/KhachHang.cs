using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBanHoa_6.Models
{
    public class KhachHang
    {
        public char CustomerId { get; set; }
        public string Customerame { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}
