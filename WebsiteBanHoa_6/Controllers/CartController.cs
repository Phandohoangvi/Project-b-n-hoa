using Microsoft.AspNetCore.Mvc;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using WebsiteBanHoa_6.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebsiteBanHoa_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        QLBanHoaContext da = new QLBanHoaContext();
        private int id;

        public object Session { get; private set; }
        public object ViewBag { get; private set; }

        // GET: Cart
        [HttpGet("Lay DSSP Gio hang")]
        private List<CartModel> GetListCarts()
        {
            List<CartModel> carts = Session["CartModel"] as List<CartModel>;
            if (carts == null)
            {
                carts = new List<CartModel>();
                Session["CartModel"] = carts;
            }
            return carts;

        }
        [HttpPost("DSSP trong gio")]
        public IActionResult ListCarts()
        {
            List<CartModel> carts = GetListCarts();
            ViewBag.CountProduct = carts.Sum(s => s.Quantity);
            ViewBag.Total = carts.Sum(s => s.Total);
            return View(carts);
        }

        private IActionResult View(List<CartModel> carts)
        {
            throw new NotImplementedException();
        }

        [HttpPost("Them vao gio hang")]
        public IActionResult AddCart([FromBody] Product p)
        {
            //lấy DSSP co trong gio hang
            List<CartModel> carts = GetListCarts();
            //Tao moi 1 san pham trong gio hang
            CartModel c = carts.Find(s => s.ProductID == id);
            if (c == null)
            {
                new CartModel(id);
                carts.Add(c);
            }
            else
            {
                c.Quantity++;
            }
            return RedirectToAction("ListCarts");
        }
        [HttpPost("Dat hang")]
        public ActionResult OrderProduct([FromBody] Product p)
        {
            using (TransactionScope tranScop = new TransactionScope())
                try
                {
                    Order order = new Order();
                    order.OrderDate = DateTime.Now;
                    object p1 = da.Orders.InsertOnSubmit(order);
                    da.SubmitChanges();
                    foreach (CartModel item in GetListCarts())
                    {
                        Order_Detail orderDetail = new Order_Detail();
                        orderDetail.OrderID = order.OrderID;
                        orderDetail.ProductID = item.ProductID;
                        orderDetail.UnitPrice = decimal.Parse(item.UnitPrice.ToString());
                        orderDetail.Quantity = short.Parse(item.Quantity.ToString());
                        orderDetail.Discount = 0;
                    }
                    da.SubmitChanges();
                    tranScop.Complete();
                }
                catch
                {
                    tranScop.Dispose();
                }
            return RedirectToAction("ListOrder");
        }

        [HttpPost("DS don dat hang")]
        public IActionResult ListOrder()
        {
            var ds = da.Orders.OrderByDescending(s => s.OrderDate).ToList();
            return View(ds);
        }

        private IActionResult View(List<Order> ds)
        {
            throw new NotImplementedException();
        }
    }

}
}
