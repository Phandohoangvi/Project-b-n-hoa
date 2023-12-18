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
    public class ProductController : ControllerBase
    {
        QLBanHoaContext da = new QLBanHoaContext();
        
        //Hien thi ds SP
        [HttpPost("get all Products")]
        public IActionResult GetProducts()
        {
            var ds = da.Products.ToList();
            return Ok(ds);
        }

        //Hien thi ds SP
        [HttpGet("get all products Get")]
        public IActionResult GetProductsGet()
        {
            var ds = da.Products.OrderByDescending(s => s.ProductId).ToList();
            return Ok(ds);
        }

        private object SearchProducts(SearchProductReq searchProductReq)
        {
            //Lay DS cac SP theo tu khoa
            var products = da.Products.Where(x => x.ProductName.Contains(searchProductReq.Keyword));
            //Xu ly phan trang
            var offset = (searchProductReq.Page - 1) * searchProductReq.Size;
            var total = products.Count();
            int totalPage = (total % searchProductReq.Size) == 0 ? (int)(total / searchProductReq.Size)
                : (int)(1 + (total / searchProductReq.Size));
            var data = products.OrderBy(x => x.ProductId).Skip(offset).Take(searchProductReq.Size).ToList();
            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPage,
                Page = searchProductReq.Page,
                Size = searchProductReq.Size
            };
            return res;
        }

        //Tim kiem SP
        [HttpPost("Search Product by Id")]
        public IActionResult SearchProduct([FromBody] SearchProductReq searchProductReq)
        {
            var product = SearchProducts(searchProductReq);

            return Ok(product);
        }

        //Them SP
        [HttpPost("Add new Product")]
        public void AddProduct([FromBody] SanPham sanPham)
        {
            Product p = new Product();
            p.ProductId = sanPham.ProductId.ToString();
            p.ProductName = sanPham.ProductName;
            p.UnitPrice = sanPham.UnitPrice;
            p.QuantityPerUnit = sanPham.QuantityPerUnit;
            p.UnitsInStock = sanPham.UnitsInStock;
            p.CategoryId = sanPham.CategoryId.ToString();
            p.SupplierId = sanPham.SupplierId.ToString();

            da.Products.Add(p);
            da.SaveChanges();
        }

        //Sua SP
        [HttpPut("Edit a Product")]
        public void EditProduct([FromBody] SanPham sanPham)
        {
            using (var tran = da.Database.BeginTransaction())
            {
                try
                {
                    Product p = da.Products.First(s => s.ProductId == sanPham.ProductId.ToString());

                    p.ProductName = sanPham.ProductName;
                    p.UnitPrice = sanPham.UnitPrice;
                    p.QuantityPerUnit = sanPham.QuantityPerUnit;
                    p.UnitsInStock = sanPham.UnitsInStock;
                    p.CategoryId = sanPham.CategoryId.ToString();
                    p.SupplierId = sanPham.SupplierId.ToString();

                    da.Products.Update(p);
                    da.SaveChanges();

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
        }

        //Xoa SP
        [HttpDelete("Delete a Product")]
        public void DeleteProducts(string id)
        {
            try
            {
                Product p = da.Products.First(s => s.ProductId == id);

                da.Products.Remove(p);
                da.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        // Hien thi ds SP
        [HttpPost("cal orders by Customers")]
        public IActionResult CalOrdersByCus()
        {
            var ds = da.Orders.GroupBy(s => s.CustomerId).Select(s => new { s.Key, sl = s.Count() }).ToList();
            return Ok(ds);
        }
    }
}
