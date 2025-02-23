using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    /*Bu satır, genel (generic) bir repository sınıfı tanımlar.
     Burada T bir jenerik türdür, yani hangi model (tablo) ile çalışacağımızı belirler.*/
    where T : class,new()
    /*Bu, generic T türü için bazı kurallar (kısıtlamalar) koyar:
    class → T bir referans tipi olmalı (Entity Framework modelleri class olmalıdır).
    new() → T nesnesi new ile oluşturulabilir olmalı (yani bir parametresiz kurucu metoda sahip olmalıdır).
    Bu sayede, RepositoryBase<T> herhangi bir veritabanı tablosuyla çalışabilir.*/
    {
        protected readonly RepositoryContext _context;
        /*Bu, Entity Framework Core’un DbContext sınıfına erişmemizi sağlar.*/

        protected RepositoryBase(RepositoryContext context)
        /*Kurucu metodumuz (constructor) RepositoryContext adlı veritabanı bağlantısını parametre olarak alıyor.
        Böylece tüm repository'ler bu context nesnesine erişebilir.
         Bu sayede DbContext bağımlılığı, Dependency Injection (IoC) ile yönetilebilir.*/
        {
            _context = context;
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges
                ? _context.Set<T>()/*(EF Core değişiklikleri takip eder)*/
                /*EF Core'un DbContext sınıfının bir özelliğidir.
                ✔ T türündeki bir varlığa (entity) karşılık gelen veritabanı tablosunu döndürür.
                ✔ O tabloyu sorgulamak ve işlemler yapmak için bir DbSet<T> nesnesi döndürür.*/
                :_context.Set<T>().AsNoTracking();/*(EF Core değişiklikleri takip etmez)*/
            /*if (trackChanges)
            {
                return _context.Set<T>();
            }
            else
            {
                return _context.Set<T>().AsNoTracking();
            }*/

        }

        /*Örneğin, Product isimli bir modelimiz olduğunu düşünelim:
        
        public class Product
        {
            public int ProductID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        Şimdi, bu Product modeline ait verileri almak için _context.Set<Product>() kullanabiliriz:

        var products = _context.Set<Product>().ToList();
*/

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        /*✔ Expression<Func<T, bool>> expression
            ➡ Burada bir Lambda ifadesi (predicate) parametre olarak alınır.
            ➡ Örnek: p => p.ProductID == 1 gibi bir filtreleme koşulu gönderilebilir.

            ✔ bool trackChanges
            ➡ Değişiklik takibi olup olmayacağını belirler.*/
        /*Bu metot, belirtilen bir koşula uyan tek bir nesneyi veritabanından çekmek için kullanılır.*/
        {
            return trackChanges
                ? _context.Set<T>().Where(expression).SingleOrDefault()
                /*✔ _context.Set<T>() → İlgili veritabanı tablosunu alır.
                ✔ .Where(expression) → Gelen koşula (expression) uyan verileri filtreler.
                ✔ .SingleOrDefault() → Tek bir kayıt döndürür (Eğer veri yoksa null döndürür).
                ✔ EF Core, bu nesneyi takip eder.*/
                : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }
    }
}