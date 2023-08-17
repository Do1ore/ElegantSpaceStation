using Domain.Entities;

namespace Infrastructure.Abstractions;

public interface IRoverLocationRepository
{
    Task<RoverLocation> GetLastLocationAsync();
    Task AddLocationAsync(RoverLocation location);
}