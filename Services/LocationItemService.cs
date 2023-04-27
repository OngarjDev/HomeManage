using InsureManage.Interfaces;
using InsureManage.Models;
using Microsoft.EntityFrameworkCore;

namespace InsureManage.Services
{
    public class LocationItemService : ILocationitem
    {
        private readonly InsureManageContext _db;
        private readonly ILogger<LocationItemService> _logger;
        public LocationItemService(InsureManageContext db, ILogger<LocationItemService> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<bool> AddPositionAsync(LocationItem position)
        {
            _db.LocationItems.Add(position);
            await _db.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<List<LocationItem>> GetAllPositionAsync()
        {
            return await _db.LocationItems.ToListAsync();
        }

        public async Task<LocationItem?> GetByIdPositionAsync(int IdPosition)
        {
            return await _db.LocationItems.FirstOrDefaultAsync(p => p.IdLocationItem == IdPosition) ?? null;
        }

        public async Task<bool> MovePositionAsync(LocationItem position)
        {
            try
            {
                _db.LocationItems.Update(position);
                await _db.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error MovePosition To Database");
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> RemovePositionAsync(int IdPosition)
        {
            try
            {
                var product = await _db.LocationItems.FindAsync(IdPosition);
                if (product != null)
                {
                    _db.LocationItems.Remove(product);
                    await _db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    _logger.LogInformation("LocationItem Not Found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error RemovePosition To Database");
                return false;
            }
        }

        public async Task<List<LocationItem>> SearchLocationitemAsync(String KeyWordSearch)
        {
            int.TryParse(KeyWordSearch, out int IdPosition);
            return await _db.LocationItems.Where(p =>
            p.IdLocationItem == IdPosition ||
            p.NameLocationItem.Contains(KeyWordSearch)
            ).ToListAsync();
        }
    }
}
