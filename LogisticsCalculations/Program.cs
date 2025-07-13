using System.Text.Json;
using LogisticsCalculations.Models;
using LogisticsCalculations.Services;

string inputJson = File.ReadAllText("input.json");

var shipments = JsonSerializer.Deserialize<List<Shipment>>(inputJson);

var invoices = new List<InvoiceSummary>();

if (shipments != null) invoices.AddRange(shipments.Select(shipment => InvoiceCalculator.Calculate(shipment)));

string outputJson = JsonSerializer.Serialize(invoices, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText("../../../output.json", outputJson);
Console.WriteLine("Invoice calculation completed. Check output.json");