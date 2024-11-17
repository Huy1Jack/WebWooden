using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebWooden.Models;


namespace wooden.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly WoodContext _context;

        public ProductViewComponent(WoodContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbProducts.Where(m => (bool)m.IsActive).Where(m => (bool)m.IsNew);

            return await Task.FromResult<IViewComponentResult>
                (View(items.OrderByDescending(m => m.ProductId).ToList()));
        }

    }

}
