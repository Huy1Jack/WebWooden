using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebWooden.Models;


namespace WebWooden.Controllers
{
    public class ProductController : Controller
    {
        static int? idproduct;
        static string? aliasproduct;
        private readonly WoodContext _Context;
        public ProductController(WoodContext context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/product/{alias}-{id}.html")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _Context.TbProducts == null)
            {
                return NotFound();
            }

            // Lấy sản phẩm
            var product = await _Context.TbProducts
                .Where(m => m.IsActive == true && m.IsNew == true)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            // Nếu View yêu cầu danh sách sản phẩm, tạo danh sách với 1 phần tử
            var productList = new List<TbProduct> { product };

            return View(productList); // Truyền danh sách thay vì một đối tượng
        }

        [HttpGet]
        public IActionResult Search(string searchQuery)
        {
            var products = string.IsNullOrEmpty(searchQuery)
                ? _Context.TbProducts.ToList()
                : _Context.TbProducts.Where(p => p.Title.Contains(searchQuery)).ToList();

            ViewBag.SearchQuery = searchQuery;
            return View(products);
        }
        //public IActionResult Index(string searchQuery)
        //{
        //    var products = string.IsNullOrEmpty(searchQuery)
        //        ? _Context.TbProducts.ToList()
        //        : _Context.TbProducts
        //            .Where(p => p.Title.Contains(searchQuery) || p.Alias.Contains(searchQuery))
        //            .ToList();

        //    ViewBag.SearchQuery = searchQuery;
        //    return View(products);
        //}
        
        public IActionResult comment(string _Name, string _Phone, string _Email, string _Detail, int _Star)
        {
            TbProductReview comment = new TbProductReview() { };

            comment.Name = _Name;
            comment.Phone = _Phone;
            comment.Email = _Email;
            comment.Detail = _Detail;
            comment.CreatedDate = DateTime.Now;
            comment.ProductId = idproduct;
            comment.Star = _Star;
            comment.IsActive = true;

            _Context.Add(comment);
            _Context.SaveChanges();
            string surl = $"/product/{aliasproduct}-{idproduct}.html";
            return Redirect(surl);
        }


    }
}
