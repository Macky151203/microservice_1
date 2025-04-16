using Ms1.Models;
namespace Ms1.Services;
public interface IProductService
{
    // Task<Product> AddAsync(Product product);
    Task<Product?> GetByIdAsync(int id);
    Task<List<Product>> GetAllAsync();
    // Task<Product?> UpdateAsync(Product product);
    // Task<bool> DeleteAsync(int id);
}