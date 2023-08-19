using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RoverLocationController : ControllerBase
{
    private readonly IRoverLocationRepository _locationRepository;

    public RoverLocationController(IRoverLocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetLastLocation()
    {
        return Ok(await _locationRepository.GetLastLocationAsync());
    }

    [HttpPost]
    public async Task<IActionResult> AddLocation(RoverLocationDto location)
    {
        await _locationRepository.AddLocationAsync(location);
        return Ok(location);
    }
}