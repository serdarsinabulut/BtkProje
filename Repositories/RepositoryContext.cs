/*Bu sınıf, Entity Framework Core (EF Core) kullanılarak veritabanı ile iletişimi sağlayan DbContext sınıfından türetilmiştir.
DbContext, veritabanı bağlantısını yönetir ve veritabanı tablolarını temsil eden DbSet<T> koleksiyonlarını içerir.*/

using System.Reflection;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Config;
namespace Repositories;
public class RepositoryContext : DbContext
/*✔ RepositoryContext sınıfı, EF Core'un DbContext sınıfından türetilmiştir.
  ✔ Bu sınıf, veritabanı bağlantısını yönetir ve tabloları tanımlar.*/
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders{get;set;}
    /*✔ DbSet<Product> → Product tablosunu temsil eder.
      ✔ DbSet<Category> → Category tablosunu temsil eder.
      ✔ EF Core, bu tanımları kullanarak SQL'de ilgili tabloları oluşturur.*/

    public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
        
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.ApplyConfiguration(new ProductConfig());
        //modelBuilder.ApplyConfiguration(new CategoryConfig());

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
