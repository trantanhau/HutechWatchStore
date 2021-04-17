using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RolexStore.Models
{
    public partial class WatchModel : DbContext
    {
        public WatchModel()
            : base("name=WatchModel")
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<CartState> CartStates { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<WatchType> WatchTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasMany(e => e.CartDetails)
                .WithRequired(e => e.Cart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CartDetail>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<CartState>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.CartState)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Collection>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Collection)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PaymentMethod>()
                .Property(e => e.PaymentMethodName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.CartDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Size>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Size)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WatchType>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<WatchType>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.WatchType)
                .WillCascadeOnDelete(false);
        }
    }
}
