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

    public async Task<Product?> GetByIdAsync(int id)
    {
      var val = await _database.HashGetAsync(RedisKey, id);
      return val.HasValue ? JsonSerializer.Deserialize<Product>(val) : null;
    }
    public async Task<List<Product>> GetAllAsync()
    {
      var entries = await _database.HashGetAllAsync(RedisKey);
      return entries.Select(entry => JsonSerializer.Deserialize<Product>(entry.Value)).ToList();
    }
  }
}