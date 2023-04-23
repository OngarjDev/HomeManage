using InsureManage.Interfaces;
using InsureManage.Models;
using Microsoft.EntityFrameworkCore;

namespace InsureManage.Services
{
    public class PositionService : IPosition
    {
        private readonly InsureManageContext _db;
        private readonly ILogger<PositionService> _logger;
        public PositionService(InsureManageContext db, ILogger<PositionService> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<bool> AddPositionAsync(Position position)
        {
            _db.Positions.Add(position);
            await _db.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<List<Position>> GetAllPositionAsync()
        {
            return await _db.Positions.ToListAsync();
        }

        public async Task<List<Position>> GetByIdPositionAsync(int IdPositio)
        {
            return await _db.Positions.Where(x => x.IdPosition == IdPositio).ToListAsync();
        }

        public async Task<bool> MovePositionAsync(Position position)
        {
            try
            {
                _db.Positions.Update(position);
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
                var product = await _db.Positions.FindAsync(IdPosition);
                if (product != null)
                {
                    _db.Positions.Remove(product);
                    await _db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    _logger.LogInformation("Position Not Found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error RemovePosition To Database");
                return false;
            }
        }
    }
}
