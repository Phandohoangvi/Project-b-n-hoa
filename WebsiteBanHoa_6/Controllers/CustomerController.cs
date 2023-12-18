using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBanHoa_6.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebsiteBanHoa_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        QLBanHoaContext da = new QLBanHoaContext();
        private object khachHang;

        //Hien thi ds KH
        [HttpPost("get all Customers")]
        public IActionResult GetCustomers()
        {
            var ds = da.Customers.ToList();
            return Ok(ds);
        }

        //Them KH
        [HttpPost("Add new Customers")]
        public void AddCustomer([FromBody] KhachHang khachHang)
        {
            KhachHang c = new KhachHang();
            c.CustomerId = khachHang.CustomerId.ToString();
            c.CustomerName = khachHang.CustomerName;
            c.Phone = khachHang.Phone;
            c.Address = khachHang.Address;
            c.City = khachHang.City;
            c.DOB = khachHang.DOB;
            c.DateOfRegistration = khachHang.DateOfRegistration;

            //da.Customers.Add(c);
            da.SaveChanges();
        }

        //Sua KH
        //[HttpPut("Edit a Customer")]
        //public void EditCustomer([FromBody] KhachHang khachhang)
        //{
        //    using (var tran = da.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            KhachHang c = da.Customers.First(s => s.CustomerId == khachhang.CustomerId.ToString());

        //            c.CustomerId = khachHang.CustomerId.ToString();
        //            c.CustomerName = khachHang.CustomerName;
        //            c.Phone = khachHang.Phone;
        //            c.Address = khachHang.Address;
        //            c.City = khachHang.City;
        //            c.DOB = khachHang.DOB;
        //            c.DateOfRegistration = khachHang.DateOfRegistration;

        //            da.Products.Update(c);
        //            da.SaveChanges();

        //            tran.Commit();
        //        }
        //        catch (Exception)
        //        {
        //            tran.Rollback();
        //        }
        //    }
        //}

        //Xoa KH
        [HttpDelete("Delete a Customer")]
        public void DeleteCustomers(string id)
        {
            try
            {
                Customer c = da.Customers.First(s => s.CustomerId == id);

                //da.Products.Remove(c);
                da.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
    }
}
