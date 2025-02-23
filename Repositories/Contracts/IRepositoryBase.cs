/*Bu arayüz, tüm repository'ler için genel işlemleri tanımlayan bir "temel repository" (Base Repository) arayüzüdür.*/

using System.Linq.Expressions;
/*Expression<Func<T,bool>> gibi ifadeler kullanmamıza olanak tanır.
Bu ne işe yarar?
LINQ ifadelerini (where gibi) dinamik olarak oluşturmamızı sağlar.*/

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    /*Bu bir generic (<T>) repository arayüzüdür.
    T, burada bir model sınıfı olabilir (Product, Category gibi).
    Bu sayede, her model için ayrı repository yazmak yerine, ortak metotları burada tanımlayabiliriz.
    Örneğin, ProductRepository ve CategoryRepository bu arayüzü kullanabilir.*/
    {
        IQueryable<T> FindAll(bool trackChanges);
        /*Bu metot, veritabanındaki tüm kayıtları getirir.
        Döndürdüğü tür IQueryable<T> olduğu için LINQ sorguları yazılabilir.*/
        T? FindByCondition(Expression<Func<T,bool>> expression, bool trackChanges);
        /*Bu metot, belirli bir koşula uyan tek bir nesneyi döndürür.
        Expression<Func<T,bool>> ile LINQ sorgularında kullanılabilecek dinamik koşullar yazılabilir.
        örneğin
        var product = _productRepository.FindByCondition(p => p.Id == 10, false);*/
    }
}