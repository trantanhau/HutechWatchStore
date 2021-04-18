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
        Customer currentCustomer;
        public CartController()
        {
            _db = new WatchModel();
            
        }
        // GET: Cart
        //Cart button
        public ActionResult Index()
        {
            currentCustomer = Session["user"] as Customer;
            if (currentCustomer == null)
            {
                return RedirectToAction("Login", "Account");
            }

            currentCart = GetCurrentCart(currentCustomer.CustomerID);
            if (currentCart == null)
            {
                return RedirectToAction("Index", "Watch");
            }
            CartViewModel cvm = new CartViewModel();
            cvm.CartID = currentCart.CartID;
            var cardDetail = _db.CartDetails.Where(s => s.Cart.CartID == currentCart.CartID).ToList<CartDetail>();
            cvm.Total = 0;
            cardDetail.ForEach(cd =>
            {
                CartProductViewModel cartProductViewModel = new CartProductViewModel
                {
                    ProductID = cd.ProductID,
                    CollectionName = cd.Product.Collection.CollectionName,
                    BuyingQuantity = cd.Quantity,
                    Price = cd.Product.Price
                };
                cvm.Total += cd.Product.Price * cd.Quantity;

                cvm.ProductVm.Add(cartProductViewModel);
            });

            // TODO: Create view
            return View(cvm);
        }

        [HttpPost, ActionName("Update")]
        public ActionResult UpdateCartFromCartPage(CartViewModel cvm)
        {
            currentCustomer = Session["user"] as Customer;
            if (currentCustomer == null)
            {
                return RedirectToAction("Login", "Account");
            }

            currentCart = GetCurrentCart(currentCustomer.CustomerID);

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
            currentCustomer = Session["user"] as Customer;
            if (currentCustomer == null)
            {
                return RedirectToAction("Login", "Account");
            }
            currentCart = GetCurrentCart(currentCustomer.CustomerID);
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
                    CustomerID = currentCustomer.CustomerID,
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

        public ActionResult Checkout()
        {
            currentCustomer = Session["user"] as Customer;
            if (currentCustomer == null)
            {
                return RedirectToAction("Login", "Account");
            }
            currentCart = GetCurrentCart(currentCustomer.CustomerID);
            if (currentCart == null)
            {
                return RedirectToAction("Index", "Watch");
            }
            CheckoutViewModel cvm = new CheckoutViewModel
            {
                Customer = currentCustomer,
                CartID = currentCart.CartID
            };
            var cardDetail = _db.CartDetails.Where(s => s.Cart.CartID == currentCart.CartID).ToList<CartDetail>();
            
            cvm.Total = 0;
            cardDetail.ForEach(cd =>
            {
                CartProductViewModel cartProductViewModel = new CartProductViewModel
                {
                    ProductID = cd.ProductID,
                    CollectionName = cd.Product.Collection.CollectionName,
                    BuyingQuantity = cd.Quantity,
                    Price = cd.Product.Price
                };
                cvm.Total += cd.Product.Price * cd.Quantity;

                cvm.ProductVm.Add(cartProductViewModel);

            });

            return View(cvm);

        }
        [HttpPost]
        public ActionResult Order(int cartID)
        {
            var cart = _db.Carts.Where(s => s.CartID == cartID).FirstOrDefault<Cart>();
            cart.CStateID = 2;
            _db.SaveChanges();
            return RedirectToAction("Order");

        }
        public ActionResult Order()
        {
            currentCustomer = Session["user"] as Customer;
            if (currentCustomer == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var cart = _db.Carts.Where(s => s.CStateID == 2).FirstOrDefault<Cart>();
            if (cart == null)
            {
                return RedirectToAction("Index", "Watch");
            }

            _db.SaveChanges();

            OrderViewModel ovm = new OrderViewModel();
            ovm.CartID = cart.CartID;
            ovm.CartStatus = cart.CStateID == 2 ? "ĐANG ĐƯỢC GIAO" : (cart.CStateID == 3 ? "ĐÃ GIAO" : "ĐÃ HỦY"); 
            var cardDetail = _db.CartDetails.Where(s => s.Cart.CartID == cart.CartID).ToList<CartDetail>();
            ovm.Total = 0;
            cardDetail.ForEach(cd =>
            {
                CartProductViewModel cartProductViewModel = new CartProductViewModel
                {
                    ProductID = cd.ProductID,
                    CollectionName = cd.Product.Collection.CollectionName,
                    BuyingQuantity = cd.Quantity,
                    Price = cd.Product.Price
                };
                ovm.Total += cd.Product.Price * cd.Quantity;

                ovm.ProductVm.Add(cartProductViewModel);
            });

            // TODO: Create view
            return View(ovm);
        }

        public ActionResult Cancel(int cartID)
        {
            Cart cartToCancel = _db.Carts.Where(s => s.CartID == cartID).FirstOrDefault<Cart>();
            if (cartToCancel != null)
            {
                _db.Carts.Remove(cartToCancel);
                return RedirectToAction("Order", "Cart");
            }
            return RedirectToAction("Index", "Watch");
        }
        private List<CartDetail> GetCardItemsFromCardID(int cardID)
        {
            var cardItems = _db.CartDetails.Where(s => s.CartID == cardID).ToList<CartDetail>();
            return cardItems;
        }

        private Cart GetCurrentCart(int customerID)
        {
            return _db.Carts.Where(s => s.CustomerID == customerID && s.CartState.CStateID == 1).FirstOrDefault<Cart>();
        }
        public ActionResult UpdateQuantity(string cart_id, string product_id)
        {
            CartDetail cartDetail = currentCart.CartDetails.Where(s => s.ProductID == product_id && s.CartID == Convert.ToInt32(cart_id)).FirstOrDefault<CartDetail>();
            cartDetail.Quantity++;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public Customer GetCurrentCustomer(int customerID)
        {
            return _db.Customers.Where(s => s.CustomerID == customerID).FirstOrDefault<Customer>();
        }
    }
}