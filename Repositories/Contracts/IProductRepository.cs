using Entities.Models;

namespace Repositories.Contracts
{   
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);
        /*Bu metot, tüm ürünleri getirmek için kullanılır.
        IQueryable<Product> döndürmesi, veritabanı sorgularında LINQ kullanmayı sağlar.
        trackChanges parametresi ne işe yarar?
        Eğer true gönderilirse, değişiklikler takip edilir (EF Core değişiklikleri izler).
        Eğer false gönderilirse, veritabanı nesneleri sadece okunur ve takip edilmez.*/
        Product? GetOneProduct(int id,bool trackChanges);
        /*Bu metot, belirli bir ürünü ID ile getirir.
        Product? → null dönebilir (eğer ID'ye sahip ürün yoksa).
        id parametresi: Hangi ürünün getirileceğini belirtir.*/

        void CreateProduct(Product product);
        void DeleteOneProduct(Product product);
    }
}