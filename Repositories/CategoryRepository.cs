/*Bu sınıf, kategori (Category) tablosuna özel veritabanı işlemlerini gerçekleştiren repository’dir.
Amaç: ICategoryRepository arayüzünü uygulayarak, kategori ile ilgili veritabanı işlemlerini yönetmek.*/
using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    /*Bu sınıf, RepositoryBase<Category> sınıfından miras alır.
    Yani, RepositoryBase içinde tanımlanan tüm genel metotları kullanabilir.
    Örneğin, FindAll() ve FindByCondition() gibi metotlar bu sınıfta hazır gelir.
    Aynı zamanda ICategoryRepository arayüzünü uygular.
    Bu, ICategoryRepository içinde tanımlanan ekstra metotları eklememize olanak tanır.
    Şu an ICategoryRepository içinde ek metot yok, sadece IRepositoryBase<Category>’yi miras alıyor.*/
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
            /*Bu, sınıfın constructor (yapıcı) metodudur.
            Parametre olarak RepositoryContext alır ve base (RepositoryBase) sınıfına gönderir.
            Amaç:
            EF Core’un DbContext nesnesini (context) RepositoryBase sınıfına aktarmaktır.
            Böylece, RepositoryBase içindeki metotlar Category tablosuna erişebilir.*/
        }
    }
}