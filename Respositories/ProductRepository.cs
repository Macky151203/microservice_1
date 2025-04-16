using StackExchange.Redis;
using System.Text.Json;
using Ms1.Models;
namespace Ms1.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private readonly IDatabase _database;
    private const string RedisKey = "products";

    public ProductRepository(IConnectionMultiplexer redis)
    {
      _database = redis.GetDatabase();
    }

    // public async Task<Product> AddAsync(Product product)
    // {
    //   // product.id = Guid.NewGuid().GetHashCode();
    //   var json = JsonSerializer.Serialize(product);
    //   await _database.HashSetAsync(RedisKey, product.id, json);
    //   return product;
    // }

    // public async Task<bool> DeleteAsync(int id) => await _database.HashDeleteAsync(RedisKey, id);

    public async Task<Product?> GetByIdAsync(int id)
    {
      var val = await _database.HashGetAsync(RedisKey, id);
      return val.HasValue ? JsonSerializer.Deserialize<Product>(val!) : null;
    }

    // public async Task<Product?> UpdateAsync(Product product)
    // {
    //   if (!await _database.HashExistsAsync(RedisKey, product.id)) return null;
    //   await _database.HashSetAsync(RedisKey, product.id, JsonSerializer.Serialize(product));
    //   return product;
    // }

    public async Task<List<Product>> GetAllAsync()
    {
      var entries = await _database.HashGetAllAsync(RedisKey);
      return entries.Select(entry => JsonSerializer.Deserialize<Product>(entry.Value)).ToList();
    }
  }
}