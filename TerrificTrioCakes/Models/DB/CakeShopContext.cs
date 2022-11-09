using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TerrificTrioCakes.Models.DB
{
    public partial class CakeShopContext : DbContext
    {
        public CakeShopContext()
        {
        }

        public CakeShopContext(DbContextOptions<CakeShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cake> Cakes { get; set; } = null!;
        public virtual DbSet<CakeIngredient> CakeIngredients { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public List<CartItems> CartItems { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CakeShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cake>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.IsFeatured).HasColumnName("isFeatured");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Categories)
                    .WithMany(p => p.Cakes)
                    .HasForeignKey(d => d.CategoriesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cakes_Categories");
            });

            modelBuilder.Entity<CakeIngredient>(entity =>
            {
                entity.Property(e => e.CakeId).HasColumnName("CakeID");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.HasOne(d => d.Cake)
                    .WithMany(p => p.CakeIngredients)
                    .HasForeignKey(d => d.CakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CakeIngredients_Cakes");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.CakeIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CakeIngredients_Ingredients");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.CakeId).HasColumnName("CakeID");

                entity.Property(e => e.ShoppingCartId).HasColumnName("ShoppingCartID");

                entity.HasOne(d => d.Cake)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CakeId)
                    .HasConstraintName("FK_Cart_Cakes");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.OrderTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Phone).HasMaxLength(25);

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.CakeId).HasColumnName("CakeID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Cake)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Cakes");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Orders");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
