/*Bu sınıf, Repository Pattern (Depo Tasarım Deseni) kullanarak veritabanı işlemlerini merkezi bir noktada yönetmek için oluşturulmuştur.
IRepositoryManager arayüzünü uygular ve ProductRepository, CategoryRepository gibi bağımlılıkları yönetir.*/
using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICategoryRepository _categoryRepository;
        /*✔ _context → EF Core DbContext nesnesidir, veritabanı ile iletişimi sağlar.
          ✔ _productRepository → ProductRepository nesnesidir, ürünlerle ilgili işlemleri yönetir.
          ✔ _categoryRepository → CategoryRepository nesnesidir, kategorilerle ilgili işlemleri yönetir.
          * Bu değişkenler, bağımlılık enjeksiyonu (Dependency Injection) ile doldurulacaktır.*/
        public RepositoryManager(IProductRepository productRepository, RepositoryContext context, ICategoryRepository categoryRepository, IOrderRepository orderRepository)
        /*✔ Bu constructor, RepositoryManager oluşturulduğunda gerekli bağımlılıkları enjekte eder.
          ✔ Bu bağımlılıklar, Program.cs içinde Dependency Injection (DI) ile otomatik atanacaktır.
          Örneğin, Program.cs içinde şu şekilde tanımlanır:
          services.AddScoped<IRepositoryManager, RepositoryManager>();
          services.AddScoped<IProductRepository, ProductRepository>();
          services.AddScoped<ICategoryRepository, CategoryRepository>();*/
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
        }

        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public IOrderRepository Order => _orderRepository;

        /*✔ Bu özellikler (properties), dışarıdan ProductRepository ve CategoryRepository'ye erişimi sağlar.
✔ Repository nesneleri dış dünyaya güvenli bir şekilde sunulur.
Örneğin, dışarıdan bu şekilde kullanılabilir
var productList = _repositoryManager.Product.GetAllProducts(trackChanges: false);
var categoryList = _repositoryManager.Category.GetAllCategories();*/

        public void Save()
        /*✔ Bu metot, DbContext nesnesini kullanarak yapılan değişiklikleri veritabanına kaydeder.
          ✔ Repository içinde Add, Update, Delete işlemleri yapıldıktan sonra Save() çağrılarak veritabanına işlenir.*/
        {
            _context.SaveChanges();
        }
    }
}