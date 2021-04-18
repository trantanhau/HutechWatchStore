namespace RolexStore.Migrations
{
    using RolexStore.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RolexStore.Models.WatchModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RolexStore.Models.WatchModel context)
        {
            var cartState = new List<CartState>
            {
                new CartState() {CStateID = 1, CStateDescription = "Not paid"},
                new CartState() {CStateID = 2, CStateDescription = "Paid/Waiting for delivery"},
                new CartState() {CStateID = 3, CStateDescription = "Delivered"},
            };
            cartState.ForEach(s => context.CartStates.AddOrUpdate(p => p.CStateID, s));
            context.SaveChanges();

            var collections = new List<Collection>
            {
                new Collection(){ CollectionID = 1, CollectionName = "Datejust"},
                new Collection(){ CollectionID = 2, CollectionName = "Submariner"},
                new Collection(){ CollectionID = 3, CollectionName = "Explorer"},
                new Collection(){ CollectionID = 4, CollectionName = "Sea Dweller"},
                new Collection(){ CollectionID = 5, CollectionName = "GMT-Master"},
                new Collection(){ CollectionID = 6, CollectionName = "Day-Date"},
            };
            collections.ForEach(s => context.Collections.AddOrUpdate(p => p.CollectionID, s));
            context.SaveChanges();

            // Add data for size
            var sizes = new List<Size>
            {
                new Size() { SizeID = 1, SizeValue = 24 },
                new Size() { SizeID = 2, SizeValue = 26 },
                new Size() { SizeID = 3, SizeValue = 29 },
                new Size() { SizeID = 4, SizeValue = 31 },
                new Size() { SizeID = 5, SizeValue = 34 },
                new Size() { SizeID = 6, SizeValue = 36 },
                new Size() { SizeID = 7, SizeValue = 39 },
                new Size() { SizeID = 8, SizeValue = 40 },
                new Size() { SizeID = 9, SizeValue = 41 }
            };

            sizes.ForEach(s => context.Sizes.AddOrUpdate(p => p.SizeID, s));
            context.SaveChanges();

            // Add data for watch type
            List<WatchType> types = new List<WatchType>
            {
                new WatchType() { TypeID = 1, TypeName = "Men's" },
                new WatchType() { TypeID = 2, TypeName = "Ladies'" }
            };

            types.ForEach(s => context.WatchTypes.AddOrUpdate(p => p.TypeID, s));
            context.SaveChanges();

            //Add data for payment method
            List<PaymentMethod> paymentMethods = new List<PaymentMethod>
            {
                new PaymentMethod() { PaymentMethodID = 1, PaymentMethodName = "Cash" },
                new PaymentMethod() { PaymentMethodID = 2, PaymentMethodName = "Credit Card" },
                new PaymentMethod() { PaymentMethodID = 3, PaymentMethodName = "PayPal" }
            };

            paymentMethods.ForEach(s => context.PaymentMethods.AddOrUpdate(p => p.PaymentMethodID, s));
            context.SaveChanges();

            List<Product> productList = new List<Product>
            {
                new Product()
                {
                    ProductID = "126233",
                    CollectionID = 1,
                    Stock = 10,
                    Price = 309,
                    TypeID = types.Single(s => s.TypeName == "Men's").TypeID,
                    SizeID = sizes.Single(s => s.SizeValue == 34).SizeID,
                    Description = "Watch 1",
                    ProductImg = "../Content/img/124060.jpg",
                },
                new Product()
                {
                    ProductID = "278381",
                    CollectionID = 1,
                    Stock = 10,
                    Price = 530,
                    TypeID = types.Single(s => s.TypeName == "Men's").TypeID,
                    SizeID = sizes.Single(s => s.SizeValue == 34).SizeID,
                    Description = "Watch 2",
                    ProductImg = "../Content/img/124060.jpg"

                },

                new Product()
                {
                    ProductID = "126231",
                    CollectionID = 2,
                    Stock = 10,
                    Price = 600,
                    TypeID = 1,
                    SizeID = 6,
                    Description = "Watch 1",
                    ProductImg = "../Content/img/124060.jpg"
                },
                new Product()
                {
                    ProductID = "126610LV",
                    CollectionID = 2,
                    Stock = 10,
                    Price = 504,
                    TypeID = 1,
                    SizeID = 9,
                    Description = "Watch 2",
                    ProductImg = "../Content/img/124060.jpg"

                },
                new Product()
                {
                    ProductID = "124560",
                    CollectionID = 3,
                    Stock = 10,
                    Price = 312,
                    TypeID = 1,
                    SizeID = 9,
                    Description = "Watch 4",
                    ProductImg = "../Content/img/124060.jpg"
                },new Product()
                {
                    ProductID = "125060",
                    CollectionID = 3,
                    Stock = 10,
                    Price = 312,
                    TypeID = 1,
                    SizeID = 9,
                    Description = "Watch 4",
                    ProductImg = "../Content/img/124060.jpg"
                },new Product()
                {
                    ProductID = "121060",
                    CollectionID = 3,
                    Stock = 10,
                    Price = 312,
                    TypeID = 1,
                    SizeID = 9,
                    Description = "Watch 4",
                    ProductImg = "../Content/img/124060.jpg"
                },new Product()
                {
                    ProductID = "122060",
                    CollectionID = 3,
                    Stock = 10,
                    Price = 312,
                    TypeID = 1,
                    SizeID = 9,
                    Description = "Watch 4",
                    ProductImg = "../Content/img/124060.jpg"
                },new Product()
                {
                    ProductID = "125062",
                    CollectionID = 3,
                    Stock = 10,
                    Price = 312,
                    TypeID = 1,
                    SizeID = 9,
                    Description = "Watch 4",
                    ProductImg = "../Content/img/124060.jpg"
                },new Product()
                {
                    ProductID = "124160",
                    CollectionID = 3,
                    Stock = 10,
                    Price = 312,
                    TypeID = 1,
                    SizeID = 9,
                    Description = "Watch 4",
                    ProductImg = "../Content/img/124060.jpg"
                },
            };

            productList.ForEach(s => context.Products.AddOrUpdate(p => p.ProductID, s));
            context.SaveChanges();


            //add initial Customer
            Customer customer = new Customer()
            {
                CustomerName = "Dango",
                AccountType = 2,
                Address = "153 Dingleton",
                Email = "alex@gmail.com",
                Password = "1234",
                Phone = "03131"
            };
            context.Customers.AddOrUpdate(p => p.CustomerID, customer);
            context.SaveChanges();

            // Add New Cart
            Cart cart = new Cart()
            {
                CStateID = 1,
                CustomerID = 1,
            };
            context.Carts.AddOrUpdate(p => p.CartID, cart);
            context.SaveChanges();

            List<CartDetail> cartDetails = new List<CartDetail>
            {
                new CartDetail()
                {
                    CartID = 3,
                    ProductID = "124160",
                    Quantity = 1,
                },
                new CartDetail()
                {
                    CartID = 3,
                    ProductID = "125062",
                    Quantity = 2,
                },
                new CartDetail()
                {
                    CartID = 3,
                    ProductID = "121060",
                    Quantity = 2,
                },
            };
            cartDetails.ForEach(s => context.CartDetails.AddOrUpdate(p => new { p.ProductID, p.CartID }, s));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
