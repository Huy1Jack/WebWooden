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
            var product = await _Context.TbProducts.Where(m => (bool)m.IsActive).Where(m => (bool)m.IsNew)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            idproduct = id;
            aliasproduct = product.Alias;
            var productReviews = _Context.TbProductReviews
            .Where(m => m.ProductId == id && m.IsActive == true)
            .ToList() ?? new List<TbProductReview>();
            ViewBag.productReviews = productReviews;
            ViewBag.productRelated = _Context.TbProducts
                .Where(m => m.ProductId != id && m.CategoryProductId == product.CategoryProductId)
                .OrderByDescending(m => m.ProductId).ToList();
            return View(product);
        }
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
