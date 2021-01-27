using Microsoft.EntityFrameworkCore;

namespace Rim.API.Entities
{
	public partial class Context : DbContext
	{

		public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		public virtual DbSet<Product> Product { get; set; }
		public virtual DbSet<Order> Order { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.ProductGuid);
				entity.Property(e => e.ProductPrice);
				entity.Property(e => e.ProductTitle).HasMaxLength(250);
				entity.Property(e => e.IsActive);
			});
			modelBuilder.Entity<Order>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.OrderCompleted);
				entity.Property(e => e.OrderCancelled);
				entity.Property(e => e.OrderCompleted);
				entity.Property(e => e.OrderAddress).HasMaxLength(250);
				entity.Property(e => e.OrderRecipient).HasMaxLength(250);
				entity.Property(e => e.IsActive);
				entity.Property(e => e.ProductId);
				entity.HasOne(d => d.Product)
								.WithMany(p => p.Order)
								.HasForeignKey(d => d.ProductId)
								.HasConstraintName("FK_Product_Order");
			});
			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

	}
}
