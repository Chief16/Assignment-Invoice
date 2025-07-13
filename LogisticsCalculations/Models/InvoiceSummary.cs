namespace LogisticsCalculations.Models;

public class InvoiceSummary
{
    public required string ShipmentId { get; set; }
    public required double BaseCharge { get; set; }
    public required double Surcharge { get; set; }
    public required double Discount { get; set; }
    public required double FinalCharge { get; set; }
}