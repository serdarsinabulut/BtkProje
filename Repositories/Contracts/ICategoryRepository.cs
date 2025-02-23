using Entities.Models;

namespace Repositories.Contracts
/*Repositories.Contracts, genellikle repository arayüzlerini (interfaces) içeren bir klasördür.
"Contracts" kelimesi, burada bir sözleşme (contract) anlamına gelir. Yani bu dosya, repository'nin ne yapması gerektiğini belirtir ancak uygulama içermez.
*/

{
    public interface ICategoryRepository : IRepositoryBase<Category>
    /*ICategoryRepository bir arayüzdür (interface).
    : işareti, ICategoryRepository'nin IRepositoryBase<Category> arayüzünden kalıtım aldığını (miras aldığını) gösterir.
    IRepositoryBase<Category> içinde genel CRUD (Create, Read, Update, Delete) işlemleri olabilir.
    ICategoryRepository, IRepositoryBase<Category>'yi genişleterek sadece Category nesnesine özel işlemleri tanımlayabilir.*/
    {
        /*Bu süslü parantezler {} arayüzün içeriğini belirler.
        Şu an boş olduğu için, IRepositoryBase<Category> içindeki metotları olduğu gibi kullanır ve yeni bir metot tanımlamaz.*/
    }
}