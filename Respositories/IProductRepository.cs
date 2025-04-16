using Ms1.Models;

namespace Ms1.Repositories;

public interface IProductRepository
{
    // Task<Product> AddAsync(Product product);
    Task<Product?> GetByIdAsync(int id);
    Task<List<Product>> GetAllAsync();
    // Task<Product?> UpdateAsync(Product product);
    // Task<bool> DeleteAsync(int id);
}
