using WebWooden.Models;

namespace WebWooden.Helpes // Đảm bảo bạn sử dụng namespace phù hợp
{
    public static class CartHelper
    {
        // Phương thức để thêm sản phẩm vào giỏ hàng trong session
        public static void AddToCartSession(ISession session, TbCartItem cartItem)
        {
            // Lấy giỏ hàng từ session hoặc khởi tạo giỏ hàng mới nếu chưa có
            List<TbCartItem> cart = session.GetObject<List<TbCartItem>>("Cart") ?? new List<TbCartItem>();

            // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
            var existingItem = cart.FirstOrDefault(c => c.ProductId == cartItem.ProductId);
            if (existingItem != null)
            {
                // Nếu sản phẩm đã có trong giỏ, tăng số lượng
                existingItem.Quantity += cartItem.Quantity;
            }
            else
            {
                // Nếu chưa có, thêm mới sản phẩm vào giỏ
                cart.Add(cartItem);
            }

            // Lưu giỏ hàng vào session
            session.SetObject("Cart", cart);
        }
    }
}
