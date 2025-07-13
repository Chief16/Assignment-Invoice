# Mini Invoice Calculation Engine

## 📌 Context
A simple C# console app that reads shipment data (JSON), calculates invoice charges using business rules, and outputs the invoice summary.

## ✅ Business Rules
- BaseCharge = Weight * 5 + Distance * 2
- Express: +10% of base
- Fragile: +150 flat
- Discount on (base + surcharge):
    - Gold: 15%
    - Silver: 10%
    - Bronze: 5%
- FinalCharge = Base + Surcharge - Discount (rounded to nearest rupee)

## 🔍 Assumptions
- If no category matches, discount is default to 0%.
- Express & Fragile surcharges can stack.

## ⚙️ How to Run
1. Update `input.json` with shipments data.
2. Run `dotnet run`.
3. Check `output.json` for invoice summaries.

## 🕒 Time Taken - 2 Hrs

## 🧩 Extensibility
- Surcharges use a single calculator method.
- Future surcharges (e.g., Oversize, Weekend Delivery) can be added to the `InvoiceCalculator`.

## 📤 Sample Input/Output
```json
// INPUT
[
  {
    "ShipmentId": "SHP001",
    "WeightKg": 200,
    "DistanceKm": 150,
    "IsExpress": true,
    "IsFragile": false,
    "ClientCategory": "Gold"
  }
]

// OUTPUT
[
  {
    "ShipmentId": "SHP001",
    "BaseCharge": 1300,
    "Surcharge": 130,
    "Discount": 215,
    "FinalCharge": 1216
  }
]
