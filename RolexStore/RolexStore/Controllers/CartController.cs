using RolexStore.Models;
using RolexStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RolexStore.Controllers
{
    public class CartController : Controller
    {
        WatchModel _db;
        Cart currentCart;
        public CartController()
        {
            _db = new WatchModel();
        }
        // GET: Cart
        //Cart button
        public ActionResult Index(string customerID)
        {
            currentCart = _db.Carts.Where(s => s.CustomerID == customerID && s.CartState.CStateID == 1).FirstOrDefault<Cart>();
            CartViewModel cvm = new CartViewModel();

            var cardDetail = _db.CartDetails.Where(s => s.Cart == currentCart).ToList<CartDetail>();

            if (cardDetail == null)
            {
                return View();
            }
            cardDetail.ForEach(cd =>
            {
                CartProductViewModel cartProductViewModel = new CartProductViewModel
                {
                    ProductID = cd.ProductID,
                    BuyingQuantity = cd.Quantity,
                    Price = cd.Product.Price
                };
                cvm.ProductVm.Add(cartProductViewModel);
            });

            // TODO: Create view
            return View(cvm);
        }
        [HttpPost, ActionName("Update")]
        public ActionResult UpdateCartFromCartPage(CartViewModel cvm)
        {
            var cardItems = GetCardItemsFromCardID(currentCart.CartID);
            cvm.ProductVm.ForEach(item =>
            {
                var cartItem = cardItems.Where(s => s.ProductID == item.ProductID).FirstOrDefault<CartDetail>();
                if (item.BuyingQuantity == 0)
                {
                    _db.CartDetails.Remove(cartItem);
                    cvm.ProductVm.Remove(item);
                }
                else
                {
                    cartItem.Quantity = item.BuyingQuantity;
                };
                _db.SaveChanges();
            });

            if (GetCardItemsFromCardID(currentCart.CartID).Count == 0)
            {
                return View();
            }

            return View(cvm);
        }

        //public ActionResult UpdateCartFromProductDetail(ProductDetailViewModel pdvm)
        //{
        //    return View();
        //}

        private List<CartDetail> GetCardItemsFromCardID(int cardID)
        {
            var cardItems = _db.CartDetails.Where(s => s.CartID == cardID).ToList<CartDetail>();
            return cardItems;
        }
    }
}