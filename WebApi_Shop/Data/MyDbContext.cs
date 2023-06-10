using Microsoft.EntityFrameworkCore;

namespace WebApi_Shop.Data
{
    public class MyDbContext : DbContext
    {
        // khai bao ham tao voi cac options mk co
        public MyDbContext(DbContextOptions options) : base(options) { }

        //
        #region DbSet
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<ShipperMethod> ShipperMethods { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(C =>
            {
                C.ToTable("Customer");
                C.HasKey(c => c.Id);
            });

            modelBuilder.Entity<Shipper>(S =>
            {
                S.ToTable("Shipper");
                S.HasKey(s => s.Id);
            });

            modelBuilder.Entity<ShipperMethod>(SM =>
            {
                SM.ToTable("ShipperMethod");
                SM.HasKey(sm => sm.Id);
            });

            modelBuilder.Entity<PaymentMethod>(P =>
            {
                P.ToTable("PaymentMethod");
                P.HasKey(p => p.Id);
            });

            modelBuilder.Entity<Order>(O =>
            {
                O.ToTable("Order");
                O.HasKey(o => o.Id);
                O.Property(o => o.OrderDate).HasDefaultValueSql("getutcdate()");

                O.HasOne(o => o.Customer)
                    .WithMany(o => o.orders)
                    .HasForeignKey(o => o.CustomerId)
                    .HasConstraintName("CustomerId");

                O.HasOne(o => o.Shipper)
                    .WithMany(o => o.Orders)
                    .HasForeignKey(o => o.ShipperId)
                    .HasConstraintName("ShipperId");

                O.HasOne(o => o.ShipperMethod)
                    .WithMany(o => o.Orders)
                    .HasForeignKey(o => o.ShipperMethodId)
                    .HasConstraintName("ShipperMethodId");

                O.HasOne(o => o.PaymentMethod)
                    .WithMany(o => o.Orders)
                    .HasForeignKey(o => o.PaymentMethodId)
                    .HasConstraintName("PaymentMethodId");

            });

            modelBuilder.Entity<Shop>(S =>
            {
                S.ToTable("Shop");
                S.HasKey(s => s.Id);
            });

            modelBuilder.Entity<Category>(C =>
            {
                C.ToTable("Category");
                C.HasKey(c => c.Id);
            });

            modelBuilder.Entity<Item>(I =>
            {
                I.ToTable("Item");
                I.HasKey(i => i.Id);

                I.HasOne(i => i.shop)
                    .WithMany(i => i.Items)
                    .HasForeignKey(i => i.ShopId)
                    .HasConstraintName("ShopId");

                I.HasOne(i => i.category)
                    .WithMany(i => i.Items)
                    .HasForeignKey(i => i.CategoryId)
                    .HasConstraintName("CategoryId");
            });
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("orderDetail");

                entity.HasKey(o => new { o.OrderId, o.ItemId });

                entity.HasOne(o => o.order)
                    .WithMany(o => o.oderdetails)
                    .HasForeignKey(o => o.OrderId)
                    .HasConstraintName("OrderId");

                entity.HasOne(o => o.item)
                  .WithMany(o => o.OrderDetails)
                  .HasForeignKey(o => o.ItemId)
                  .HasConstraintName("ItemId");

            });

        }
    }
}
