using InsureManage.Interfaces;
using InsureManage.Models;
using Microsoft.EntityFrameworkCore;

namespace InsureManage.Services
{
    public class ProductService : IProduct
    {
        private readonly InsureManageContext _db;
        private readonly ILogger<ProductService> _logger;
        public ProductService(InsureManageContext db, ILogger<ProductService> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<bool> AddProduct(Product product)
        {
            try
            {
                _db.Add(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error AddData To Database");
                return false;
            }
        }

        public async Task<List<Product>> GetDataListProduct()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            try
            {
                _db.Update(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error UpdateProduct To Database");
                return false;
            }
        }

        public async Task<bool> DeleteProduct(int id_product)
        {
            try
            {
                var product = await _db.Products.FindAsync(id_product);
                if (product != null)
                {
                    _db.Products.Remove(product);
                    await _db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    _logger.LogInformation("Product Not Found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error UpdateProduct To Database");
                return false;
            }
        }

        public async Task<List<Product>> SearchProduct(Product product)
        {
            return await _db.Products.Where(p =>
            p.NameProduct.Contains(product.NameProduct
            )).ToListAsync();
        }
    }
}
