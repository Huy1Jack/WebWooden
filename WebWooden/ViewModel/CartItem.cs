using WebWooden.Models;

namespace WebWooden.ViewModel
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        public int? ProductId { get; set; }

        public string? ProductName { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public double? PriceTotal => Quantity * (double?)Price;
    }
}
