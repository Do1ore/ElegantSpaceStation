using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.Abstractions;

public interface IRoverLocationRepository
{
    Task<RoverLocationDto> GetLastLocationAsync();
    Task AddLocationAsync(RoverLocation location);
}