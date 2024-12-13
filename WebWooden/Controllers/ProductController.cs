using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebWooden.Models;
using WebWooden.Helpes;

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

            List<TbProduct> listproduct = _Context.TbProducts.Include(i => i.TbProductReviews).Include(i => i.CategoryProduct).Where(i => i.ProductId == id).ToList();

            // Lấy sản phẩm
            var product = await _Context.TbProducts.Include(m=>m.CategoryProduct).Include(m=>m.TbProductReviews)
                .Where(m => m.IsActive == true)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            
            ViewData["productRelated"] = _Context.TbProducts.Where(m => m.IsActive == true).Where(m=>m.ProductId != id).ToList();
            idproduct = id;
            aliasproduct = product.Alias;
            return View(listproduct);
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
        //[HttpPost]
        //public IActionResult AddToCart(int id, int quantity)
        //{
        //    // Xử lý logic thêm sản phẩm vào giỏ hàng
        //    // Ví dụ:
        //    var product = _Context.TbProducts.Find(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    var cartItem = new TbCartItem
        //    {
        //        ProductId = id,
        //        Quantity = quantity,
        //        Price = product.Price
        //    };

        //    // Thêm vào session hoặc database (tùy logic)
        //    AddToCartSession(cartItem);

        //    // Chuyển hướng người dùng sau khi thêm
        //    return RedirectToAction("Index", "Cart");
        //}


    }
}
