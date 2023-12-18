namespace WebsiteBanHoa_6.Controllers
{
    internal class Order_Detail
    {
        public object OrderID { get; internal set; }
        public int ProductID { get; internal set; }
        public decimal UnitPrice { get; internal set; }
        public short Quantity { get; internal set; }
        public int Discount { get; internal set; }
    }
}