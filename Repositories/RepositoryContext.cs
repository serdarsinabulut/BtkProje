/*Bu sınıf, Entity Framework Core (EF Core) kullanılarak veritabanı ile iletişimi sağlayan DbContext sınıfından türetilmiştir.
DbContext, veritabanı bağlantısını yönetir ve veritabanı tablolarını temsil eden DbSet<T> koleksiyonlarını içerir.*/

using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Repositories;
public class RepositoryContext : DbContext
/*✔ RepositoryContext sınıfı, EF Core'un DbContext sınıfından türetilmiştir.
  ✔ Bu sınıf, veritabanı bağlantısını yönetir ve tabloları tanımlar.*/
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    /*✔ DbSet<Product> → Product tablosunu temsil eder.
      ✔ DbSet<Category> → Category tablosunu temsil eder.
      ✔ EF Core, bu tanımları kullanarak SQL'de ilgili tabloları oluşturur.*/

    public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
        /*✔ Bu constructor, dışarıdan DbContextOptions<RepositoryContext> alır.
          ✔ Veritabanı bağlantı ayarları (connection string) burada belirlenir.
          ✔ base(options) çağrısı ile DbContext sınıfına bu ayarlar gönderilir.*/
        /*Örnek Kullanım (Program.cs)
        services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlite("Data Source=database.db"));*/
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    /*✔ Bu metot, veritabanı modelleri oluşturulurken çalıştırılır.
      ✔ İlk başta veritabanına eklenecek verileri tanımlamak için kullanılır.*/
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>()
        .HasData(
            new Product() { ProductID = 1, ProductName = "Computer", Price = 17_000 },
            new Product() { ProductID = 2, ProductName = "Keyboard", Price = 1_000 },
            new Product() { ProductID = 3, ProductName = "Mouse", Price = 500 },
            new Product() { ProductID = 4, ProductName = "Mointor", Price = 7_000 },
            new Product() { ProductID = 5, ProductName = "Deck", Price = 1_500 }
            /*✔ modelBuilder.Entity<Product>() → Product tablosuna erişim sağlar.
              ✔ .HasData(...) → Bu tabloya başlangıç verilerini ekler.
              ✔ Yeni oluşturulan veritabanına bu 5 ürün otomatik olarak eklenecektir.*/
        );

        modelBuilder.Entity<Category>()
        .HasData(
            new Category() { CategoryId = 1, CategoryName = "Book" },
            new Category() { CategoryId = 2, CategoryName = "Electronic" }
        );
    }
}
