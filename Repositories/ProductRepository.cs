using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateProduct(Product product) => Create(product);

        public void DeleteOneProduct(Product product) => Remove(product);

        public IQueryable<Product>/*-->Bu, bir Product koleksiyonunu (liste) temsil eder.*/ GetAllProducts(bool trackChanges) => FindAll(trackChanges);
        
        public Product? GetOneProduct(int id,bool trackChanges)
        {
            return FindByCondition(p=> p.ProductID.Equals(id),trackChanges);     
            /*Amaç: Belirli bir id değerine sahip ürünü getirmek.
            FindByCondition() çağrısı ile RepositoryBase sınıfındaki FindByCondition() metodunu kullanır.
            Parametreler:
            id → Aranacak ürünün kimliği (ID).
            trackChanges → EF Core’un değişiklikleri takip edip etmeyeceğini belirler.*/  
        }

        public void UpdateOneProduct(Product entity) => Update(entity);
    }
}