using Ms1.Models;
namespace Ms1.Services;
public interface IProductService
{
    Task<Product?> GetByIdAsync(int id);
    Task<List<Product>> GetAllAsync();
}