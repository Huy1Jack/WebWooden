
using Microsoft.AspNetCore.Mvc;
using WebWooden.Models;
using WebWooden.Utilities;

namespace Harmic.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly WoodContext _context;

        public MenuTopViewComponent(WoodContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["miniCart"] = _context.TbCartItems.Where(i=>i.CustomerId == Function._CustomerID).ToList();
            var items = _context.TbMenus.Where(m => (bool)m.IsActive).
                OrderBy(m => m.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
