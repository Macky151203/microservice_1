using Ms1.Models;
using Ms1.Repositories;

namespace Ms1.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;
    public ProductService(IProductRepository repo) => _repo = repo;

    public Task<List<Product>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Product?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
}
