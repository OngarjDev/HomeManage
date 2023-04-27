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
                _db.Products.Add(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error AddData To Database");
                return false;
            }
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

        public async Task<IEnumerable<ProductLocationItemInnerJoin>> SearchProduct(string KeywordSearch)
        {
            int.TryParse(KeywordSearch, out int IdPosition);
            DateTime.TryParse(KeywordSearch, out DateTime DatePosition);
            var query = from Product in _db.Set<Product>().Where(p =>
                p.IdProduct == IdPosition ||
                p.NameProduct.Contains(KeywordSearch) ||
                p.DateBuyProduct == DatePosition ||
                p.DateEndInsureProduct == DatePosition ||
                p.PositionProduct == IdPosition
            )
                        join LocationItem in _db.Set<LocationItem>()
                            on Product.PositionProduct equals LocationItem.IdLocationItem
                        select new ProductLocationItemInnerJoin
                        {
                            IdProduct = Product.IdProduct,
                            NameProduct = Product.NameProduct,
                            DateBuyProduct = DateOnly.FromDateTime(Product.DateBuyProduct.GetValueOrDefault()),
                            DateEndProduct = DateOnly.FromDateTime(Product.DateEndInsureProduct.GetValueOrDefault()),
                            NoteProduct = Product.NoteProduct ?? string.Empty,
                            NameLocationItem = LocationItem.NameLocationItem + " (ID : " + LocationItem.IdLocationItem + ")"
                        };
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<ProductLocationItemInnerJoin>> JoinLocationitemTableGetAll()
        {
            var query = from Product in _db.Set<Product>()
                        join LocationItem in _db.Set<LocationItem>()
                            on Product.PositionProduct equals LocationItem.IdLocationItem
                        select new ProductLocationItemInnerJoin
                        {
                            IdProduct = Product.IdProduct,
                            NameProduct = Product.NameProduct,
                            DateBuyProduct = DateOnly.FromDateTime(Product.DateBuyProduct.GetValueOrDefault()),
                            DateEndProduct = DateOnly.FromDateTime(Product.DateEndInsureProduct.GetValueOrDefault()),
                            NoteProduct = Product.NoteProduct ?? string.Empty,
                            NameLocationItem = LocationItem.NameLocationItem + " (ID : " + LocationItem.IdLocationItem + ")"
                        };
            return await query.ToListAsync();
        }

        public async Task<Product?> GetProductById(int Id_Product)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.IdProduct == Id_Product) ?? null;
        }
    }
}
