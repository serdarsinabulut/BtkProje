/*Bu dosya, tüm repository’leri yönetmek için kullanılan bir arayüzdür.
Amaç: Repository bağımlılıklarını tek bir merkezde toplamak ve Save() metodu ile veritabanına değişiklikleri kaydetmeyi sağlamak.*/

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    /*Bu satır, IRepositoryManager adında bir arayüz tanımlar.
    Bu arayüz, tüm repository nesnelerini tek bir yerde toplamayı amaçlar.
    Amaç: Servis katmanlarında (Service sınıflarında) her repository’yi ayrı ayrı çağırmak yerine, tek bir IRepositoryManager nesnesi üzerinden tüm repository'lere erişmektir.*/
    {
        IProductRepository Product {get;}
        /*Bu, IProductRepository türünde bir property'dir.
        Amaç: ProductRepository nesnesine erişmek için kullanılır.
        örneğin
        _repositoryManager.Product.GetAllProducts(false);*/
        ICategoryRepository Category {get;}
        void Save();
        /*Bu metot, veritabanındaki değişiklikleri kaydetmek için kullanılır.
        Repository deseni kullanıldığında, veritabanına yapılan değişikliklerin (Ekleme, Güncelleme, Silme) işlem sonunda Save() ile kaydedilmesi gerekir.*/
    }
}