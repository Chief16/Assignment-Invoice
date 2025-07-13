namespace LogisticsCalculations.Models;

public class Shipment
{
    public required string ShipmentId { get; set; }
    public double WeightKg { get; set; }
    public double DistanceKm { get; set; }
    public bool IsExpress { get; set; }
    public bool IsFragile { get; set; }
    public required string ClientCategory { get; set; }
}