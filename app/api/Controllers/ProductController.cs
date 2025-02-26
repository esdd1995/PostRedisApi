using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostRedisApi.Data;
using PostRedisApi.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IDatabase _redis;
    private const string cacheKeyPrefix = "Products"; // Define a prefix for cache keys

    public ProductsController(AppDbContext context, IConnectionMultiplexer muxer)
    {
        _context = context;
        _redis = muxer.GetDatabase();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var cachedProduct = await GetCachedData<Product>($"{cacheKeyPrefix}:{id}");

        if (cachedProduct != null)
        {
            return Ok(cachedProduct);
        }
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        await SetCacheData($"{cacheKeyPrefix}:{id}", product, TimeSpan.FromMinutes(30));

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        // product.CreatedAt = DateTime.Now;
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            await _redis.KeyDeleteAsync($"{cacheKeyPrefix}:{id}");

        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var article = await _context.Products.FindAsync(id);

        if (article == null)
        {
            return NotFound();
        }

        _context.Products.Remove(article);
        await _context.SaveChangesAsync();
        await _redis.KeyDeleteAsync($"{cacheKeyPrefix}:{id}");
        return NoContent();
    }

    private bool ProductExists(int id)
    {
        return _context.Products.Any(e => e.Id == id);
    }

    private async Task<T> GetCachedData<T>(string cacheKey)
    {
        var cachedData = await _redis.StringGetAsync(cacheKey);
        if (!cachedData.HasValue) return default;
        return JsonSerializer.Deserialize<T>(cachedData);
    }

    private async Task SetCacheData<T>(string cacheKey, T data, TimeSpan expirationTime)
    {
        var serializedData = JsonSerializer.Serialize(data);
        await _redis.StringSetAsync(cacheKey, serializedData, expirationTime);
    }
}