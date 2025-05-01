using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p=>p.ProductID);
            builder.Property(p=> p.ProductName).IsRequired();
            builder.Property(p=> p.Price).IsRequired();
            builder.HasData(
            new Product() { ProductID = 1,CategoryId=2,ImageUrl="/images/5.jpg", ProductName = "Computer", Price = 17_000 },
            new Product() { ProductID = 2,CategoryId=2,ImageUrl="/images/2.jpg", ProductName = "Keyboard", Price = 1_000 },
            new Product() { ProductID = 3,CategoryId=2,ImageUrl="/images/1.jpg", ProductName = "Mouse", Price = 500 },
            new Product() { ProductID = 4,CategoryId=2,ImageUrl="/images/4.jpg", ProductName = "Mointor", Price = 7_000 },
            new Product() { ProductID = 5,CategoryId=2,ImageUrl="/images/3.jpg", ProductName = "Headphone", Price = 1_500 },
            new Product() { ProductID = 6,CategoryId=1,ImageUrl="/images/6.jpg", ProductName = "Hamlet", Price = 25 },
            new Product() { ProductID = 7,CategoryId=1,ImageUrl="/images/7.jpg", ProductName = "Sherlock", Price = 45 }
            );
        }
    }
}