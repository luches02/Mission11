using Microsoft.AspNetCore.Mvc;
using Mission11.Models;

namespace Mission11.Components
{
    public class CartSummaryViewComponent : ViewComponent 
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
