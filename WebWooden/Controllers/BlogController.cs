
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebWooden.Models;

namespace Harmic.Controllers
{
	public class BlogController : Controller
	{
		private readonly WoodContext _context;
		public BlogController(WoodContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		[Route("/blog/{alias}-{id}.html")]

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.TbNews == null)
			{
				return NotFound();
			}

			var blog = await _context.TbNews.FirstOrDefaultAsync(m => m.NewId == id);
			if (blog == null)
			{
				return NotFound();
			}

			//// Gán danh sách bình luận đúng kiểu vào ViewBag
			//ViewBag.blogComment = await _context.TbBlogComments
			//	.Where(c => c.BlogId == id)
			//	.ToListAsync();

			return View(blog);
		}




	}
}
