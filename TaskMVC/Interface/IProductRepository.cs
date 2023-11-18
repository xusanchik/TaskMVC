using TaskMVC.Entity;

namespace TaskMVC.Interface
{
    public interface IProductRepository
    {
        public Task<Product> CreateAudit(Product entity, Product oldValue, string actionType, User user);
        public Task<Product> GetOldValueAsync(int id);
        public Task<Product> DeleteProductAsync(int Id);
        public Task<Product> UpdateProductAsync(Product entity);
        public Task<Product> CreateProductAsync(Product entity);
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product> GetProductByIdAsync(int id);

    }
}
