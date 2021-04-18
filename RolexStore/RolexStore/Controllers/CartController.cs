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
            currentCart = GetCurrentCart();
        }
        // GET: Cart
        //Cart button
        public ActionResult Index()
        {
            currentCart = GetCurrentCart();
            if (currentCart == null)
            {
                return RedirectToAction("Index", "Watch");
            }
            CartViewModel cvm = new CartViewModel();
            cvm.CartID = currentCart.CartID;
            var cardDetail = _db.CartDetails.Where(s => s.Cart.CartID == currentCart.CartID).ToList<CartDetail>();
            cardDetail.ForEach(cd =>
            {
                CartProductViewModel cartProductViewModel = new CartProductViewModel
                {
                    ProductID = cd.ProductID,
                    CollectionName = cd.Product.Collection.CollectionName,
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
            CartViewModel newCvm = new CartViewModel { CartID = cvm.CartID };
            List<CartDetail> cardItems = GetCardItemsFromCardID(currentCart.CartID);
            cvm.ProductVm.ForEach(item =>
            {
                var cartItem = cardItems.Where(s => s.ProductID == item.ProductID).FirstOrDefault<CartDetail>();
                if (item.BuyingQuantity == 0)
                {
                    _db.CartDetails.Remove(cartItem);
                }
                else
                {
                    cartItem.Quantity = item.BuyingQuantity;
                    newCvm.ProductVm.Add(item);
                };
            });
            _db.SaveChanges();
            cvm = newCvm;

            if (GetCardItemsFromCardID(currentCart.CartID).Count == 0)
            {
                _db.Carts.Remove(currentCart);
                _db.SaveChanges();
                return RedirectToAction("Index", "Watch");
            }

            return RedirectToAction("Index");
        }
        public ActionResult AddFromIndex(string productID)
        {
            currentCart = GetCurrentCart();
            if (currentCart != null)
            {

                CartDetail cartDetail = currentCart.CartDetails.Where(s => s.ProductID == productID).FirstOrDefault<CartDetail>();
                if (cartDetail != null)
                {
                    cartDetail.Quantity++;
                    _db.SaveChanges();
                }
                else
                {
                    CartDetail cd = new CartDetail()
                    {
                        ProductID = productID,
                        CartID = currentCart.CartID,
                        Quantity = 1
                    };
                    currentCart.CartDetails.Add(cd);
                    _db.SaveChanges();
                }
            }
            else
            {
                Cart newCart = new Cart()
                {
                    CustomerID = 1001,
                    CStateID = 1,
                };

                CartDetail cd = new CartDetail()
                {
                    ProductID = productID,
                    CartID = newCart.CartID,
                    Quantity = 1
                };
                newCart.CartDetails.Add(cd);
                _db.Carts.Add(newCart);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "Watch");


            //public ActionResult UpdateCartFromProductDetail(ProductDetailViewModel pdvm)
            //{
            //    return View();
            //}

        }
        private List<CartDetail> GetCardItemsFromCardID(int cardID)
        {
            var cardItems = _db.CartDetails.Where(s => s.CartID == cardID).ToList<CartDetail>();
            return cardItems;
        }

        private Cart GetCurrentCart()
        {
            return _db.Carts.Where(s => s.CustomerID == 1001 && s.CartState.CStateID == 1).FirstOrDefault<Cart>();
        }
        public ActionResult UpdateQuantity(string cart_id, string product_id)
        {
            CartDetail cartDetail = currentCart.CartDetails.Where(s => s.ProductID == product_id && s.CartID == Convert.ToInt32(cart_id)).FirstOrDefault<CartDetail>();
            cartDetail.Quantity++;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}