﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebWooden.Models;

namespace Harmic.Controllers
{
	public class BlogController : Controller
	{
		static int? idblog;
		static string? aliasblog;
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
			if (id == null || _context.TbBlogs == null)
			{
				return NotFound();
			}

            var blog = await _context.TbBlogs.FirstOrDefaultAsync(m => m.BlogId == id);
			ViewData["Blog"] = blog;
			if (blog == null)
			{
				return NotFound();
			}
            List<TbProduct> listproduct = _context.TbProducts.Include(i => i.TbProductReviews).Include(i => i.CategoryProduct).Where(i => i.ProductId == id).ToList();
			idblog = id;
            aliasblog = blog.Alias;
            ViewBag.blogComment = await _context.TbBlogComments
                .Where(c => c.BlogId == id)
                .ToListAsync();

            return View(listproduct);
		}


		public IActionResult comment(string _Name, string _Phone, string _Email, string _Detail) { 
			TbBlogComment comment = new TbBlogComment() { };

			comment.Name = _Name;
			comment.Phone = _Phone;
			comment.Email = _Email;
			comment.Detail = _Detail;
			comment.CreatedDate = DateTime.Now;
			comment.BlogId = idblog;
			comment.IsActive = true;
			_context.Add(comment);
			_context.SaveChanges();
			string url = $"/blog/{aliasblog}-{idblog}.html";
            return Redirect(url);
		}
	}
}
