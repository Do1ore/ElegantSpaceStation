using System.ComponentModel.DataAnnotations;
using Domain.DTOs;
using Domain.Enums;

namespace Domain.Entities;

public class RoverLocation
{
    [Key] public int Id { get; set; }
    public long XPosition { get; set; }
    public long YPosition { get; set; }
    public bool IsAlive { get; set; }

    public Direction CurrentDirection { get; set; }
    public DateTime LastLocationDateTime { get; set; }

    public static implicit operator RoverLocation(RoverLocationDto roverLocation)
    {
        Enum.TryParse<Direction>(roverLocation.CurrentDirection, true, out var direction);
        return new RoverLocation()
        {
            XPosition = roverLocation.XPosition,
            YPosition = roverLocation.YPosition,
            IsAlive = roverLocation.IsAlive,
            CurrentDirection = direction,
            LastLocationDateTime = roverLocation.LocationDateTime,
        };
    }
}