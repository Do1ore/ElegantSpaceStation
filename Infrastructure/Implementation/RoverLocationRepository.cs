using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation;

public class RoverLocationRepository : IRoverLocationRepository
{
    private readonly AppDbContext _db;

    public RoverLocationRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<RoverLocation> GetLastLocationAsync()
    {
        var result = await _db.RoverLocations!
            .OrderByDescending(d => d.LastLocationDateTime)
            .FirstAsync();
        return result;
    }

    public async Task AddLocationAsync(RoverLocation location)
    {
        var result = await _db.RoverLocations!.AddAsync(location);
        if (result.State != EntityState.Added)
        {
            throw new ArgumentException("Cannot add new location.");
        }

        await _db.SaveChangesAsync();
    }
}