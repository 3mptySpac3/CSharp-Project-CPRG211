using JPsShopz.Shared;
using System.Collections.Generic;
using System.Linq;
using JPsShopz.Pages;


namespace JPsShopz.Services
{
    public class CartService
    {
        private List<Product> _cartItems = new List<Product>();

        public IReadOnlyList<Product> CartItems => _cartItems.AsReadOnly();

        public void AddToCart(Product product)
        {
            _cartItems.Add(product);
        }

        public void RemoveFromCart(Product product)
        {
            _cartItems.Remove(product);
        }

        public decimal GetTotalPrice()
        {
            return _cartItems.Sum(item => item.Price);

        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }


        // More methods please...
    }
}
