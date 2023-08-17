using Domain.Enums;

namespace Domain.Entities;

public class RoverLocation
{
    public long XPosition { get; set; }
    public long YPosition { get; set; }
    public bool IsAlive { get; set; }
    public Direction CurrentDirection { get; set; }
    public DateTime LastLocationDateTime { get; set; }
}