using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBanHoa_6.Models
{
    public class SanPham
    {
        public char ProductId { get; set; }
        public string ProductName { get; set; }
        public char SupplierId { get; set; }
        public char CategoryId { get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
    }
}
