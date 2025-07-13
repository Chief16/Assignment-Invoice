using LogisticsCalculations.Models;

namespace LogisticsCalculations.Services;

public static class InvoiceCalculator
{
    public static InvoiceSummary Calculate(Shipment shipment)
    {
        // BaseCharge = Weight * 5 + Distance * 2
        double baseCharge = shipment.WeightKg * 5 + shipment.DistanceKm * 2;

        double surcharge = 0;

        if (shipment.IsExpress)
            surcharge += baseCharge * 0.10;

        if (shipment.IsFragile)
            surcharge += 150;

        double discountRate = GetDiscountRate(shipment.ClientCategory);
        double discount = (baseCharge + surcharge) * discountRate;

        double finalCharge = Math.Round(baseCharge + surcharge - discount, 0, MidpointRounding.AwayFromZero);

        return new InvoiceSummary
        {
            ShipmentId = shipment.ShipmentId,
            BaseCharge = Math.Round(baseCharge, 0, MidpointRounding.AwayFromZero),
            Surcharge = Math.Round(surcharge, 0, MidpointRounding.AwayFromZero),
            Discount = Math.Round(discount, 0, MidpointRounding.AwayFromZero),
            FinalCharge = finalCharge
        };
    }

    private static double GetDiscountRate(string clientCategory)
    {
        return clientCategory switch
        {
            "Gold" => 0.15,
            "Silver" => 0.10,
            "Bronze" => 0.05,
            _ => 0.0
        };
    }
}