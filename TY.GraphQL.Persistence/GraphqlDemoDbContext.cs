using Microsoft.EntityFrameworkCore;
using TY.GraphQL.Data;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace TY.GraphQL.Persistence
{
    public class GraphqlDemoDbContext : DbContext
    {
        public GraphqlDemoDbContext(DbContextOptions<GraphqlDemoDbContext> options)
            :base(options)
        {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(b =>
            {
                b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
                b.Property(u => u.IsDeleted).HasDefaultValueSql("0");
                b.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
                b.Property(u => u.ModifiedAt).HasDefaultValueSql(null);
            });

            modelBuilder.Entity<Order>(b =>
            {
                b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
                b.Property(u => u.IsDeleted).HasDefaultValueSql("0");
                b.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
                b.Property(u => u.ModifiedAt).HasDefaultValueSql(null);
            });

            modelBuilder.Entity<Variant>(b =>
            {
                b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
                b.Property(u => u.IsDeleted).HasDefaultValueSql("0");
                b.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
                b.Property(u => u.ModifiedAt).HasDefaultValueSql(null);
            });

            modelBuilder.Entity<ProductVariant>(b =>
            {
                b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
                b.Property(u => u.IsDeleted).HasDefaultValueSql("0");
                b.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
                b.Property(u => u.ModifiedAt).HasDefaultValueSql(null);
            });

            modelBuilder.Entity<ProductOrder>(b =>
            {
                b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
                b.Property(u => u.IsDeleted).HasDefaultValueSql("0");
                b.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
                b.Property(u => u.ModifiedAt).HasDefaultValueSql(null);
            });

            modelBuilder.Entity<ProductVariant>().HasKey(pv => new { pv.ProductId, pv.VariantId });
            modelBuilder.Entity<ProductOrder>().HasKey(po => new { po.ProductId, po.OrderId });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GraphqlDemoDbContext).Assembly);
        }
    }
}