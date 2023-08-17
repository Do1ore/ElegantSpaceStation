using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class RoverLocation
{
    [Key] public int Id { get; set; }
    public long XPosition { get; set; }
    public long YPosition { get; set; }
    public bool IsAlive { get; set; }
    [EnumDataType(typeof(Direction))]
    public string CurrentDirection { get; set; }
    public DateTime LastLocationDateTime { get; set; }
}