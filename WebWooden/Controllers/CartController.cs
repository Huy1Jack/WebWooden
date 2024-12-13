using Microsoft.AspNetCore.Mvc;
using WebWooden.Models;
using WebWooden.Helpes;
using Microsoft.EntityFrameworkCore;
using WebWooden.Utilities;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace WebWooden.Controllers
{
    public class CartController : Controller
    {
        private readonly WoodContext _context;
        public CartController(WoodContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (Function.CustomerIsLogin())
            {
                var product = _context.TbProducts.Include(i => i.CategoryProduct);
                ViewData["Cart"] = _context.TbCartItems.Include(i => i.Product).Where(i=>i.CustomerId == Function._CustomerID).ToList();
                return View(product); // Trả về View hiển thị giỏ hàng
            }
            else
            {
                return RedirectToAction("Index", "Login");

            }
        }
        [HttpPost]
        public IActionResult AddToCart(int productId, decimal price, int quantity)
        {
            if (Function.CustomerIsLogin())
            {
                // Lấy giỏ hàng hiện tại từ Session
                var cart = HttpContext.Session.GetObject<List<TbCartItem>>("Cart") ?? new List<TbCartItem>();

                // Kiểm tra sản phẩm có trong giỏ hàng hay chưa
                var existingItem = cart.Find(item => item.ProductId == productId);
                if (existingItem != null)
                {
                    // Nếu có thì tăng số lượng
                    existingItem.Quantity += quantity;
                }
                else
                {
                    // Nếu chưa, thêm mới sản phẩm
                    _context.Add(new TbCartItem
                    {
                        ProductId = productId,
                        ProductName = _context.TbProducts.Where(i => i.ProductId == productId).FirstOrDefault().Title,
                        CustomerId = Function._CustomerID,
                        Price = price,
                        Quantity = quantity
                    });
                    _context.SaveChanges();
                }

                // Lưu lại giỏ hàng vào Session
                HttpContext.Session.SetObject("Cart", cart);

                return RedirectToAction("Index", "Cart");
            }
            else
            {
                return RedirectToAction("Index", "Login");

            }
            
        }
        public IActionResult RemoveCart(int id)
        {
            var gioHang = _context.TbCartItems.FirstOrDefault(i => i.CartItemId == id);

            if (gioHang != null)
            {
                _context.Remove(gioHang);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
