using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;
using Repositories.Extensions;

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

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return _context
                .Products
                .FilteredByCategoryId(p.CategoryId)
                .FilteredBySearchTerm(p.SearchTerm)
                .FilteredByPrice(p.MinPrice, p.MaxPrice,p.IsValidPrice)
                .ToPaginate(p.PageNumber, p.PageSize);
                
        }

        public Product? GetOneProduct(int id,bool trackChanges)
        {
            return FindByCondition(p=> p.ProductID.Equals(id),trackChanges);     
            /*Amaç: Belirli bir id değerine sahip ürünü getirmek.
            FindByCondition() çağrısı ile RepositoryBase sınıfındaki FindByCondition() metodunu kullanır.
            Parametreler:
            id → Aranacak ürünün kimliği (ID).
            trackChanges → EF Core’un değişiklikleri takip edip etmeyeceğini belirler.*/  
        }

        public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Where(p => p.ShowCase.Equals(true));
        }

        public void UpdateOneProduct(Product entity) => Update(entity);
    }
}