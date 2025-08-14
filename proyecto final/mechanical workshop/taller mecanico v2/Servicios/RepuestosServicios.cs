using System;
using System.Linq;
using workshop_manager_v2.dbcontext;

public class SparePartService
{
    public static void ViewSparePartsHistory()
    {
        using var db = new Connection();

        var spareParts = db.SpareParts.ToList();

        if (!spareParts.Any())
        {
            Console.WriteLine("No spare parts registered.");
            return;
        }

        Console.WriteLine("=== SPARE PARTS HISTORY ===");

        foreach (var sparePart in spareParts)
        {
            var sales = db.Sales.Where(v => v.SparePart.SparePartId == sparePart.SparePartId).ToList();
            int soldQuantity = sales.Sum(v => v.Quantity);
            double totalSoldValue = sales.Sum(v => v.Total);
            double inventoryValue = sparePart.Quantity * sparePart.UnitPrice;

            Console.WriteLine($"\nSpare Part: {sparePart.Name}");
            Console.WriteLine($"- In Stock: {sparePart.Quantity}");
            Console.WriteLine($"- Unit Price: {sparePart.UnitPrice}");
            Console.WriteLine($"- Wholesale Price: {sparePart.WholesalePrice}");
            Console.WriteLine($"- Sold Quantity: {soldQuantity}");
            Console.WriteLine($"- Inventory Value: {inventoryValue}");
            Console.WriteLine($"- Total Sold Value: {totalSoldValue}");
        }
    }

    public static void Add()
    {
        Console.Write("Spare part name: ");
        string name = Console.ReadLine();
        Console.Write("Quantity: ");
        int quantity = int.Parse(Console.ReadLine());
        Console.Write("Unit price: ");
        double unitPrice = double.Parse(Console.ReadLine());
        Console.Write("Wholesale price: ");
        double wholesalePrice = double.Parse(Console.ReadLine());

        var sparePart = new SparePart(0, name, quantity, unitPrice, wholesalePrice);

        using var db = new Connection();
        db.SpareParts.Add(sparePart);
        db.SaveChanges();

        Console.WriteLine("Spare part added.");
    }

    public static void View()
    {
        using var db = new Connection();

        var repuestos = db.SpareParts
                          .Select(r => new
                          {
                              r.SparePartId,
                              r.Name,
                              Stock = r.Quantity, // Usar stock real directamente
                              r.UnitPrice,
                              r.WholesalePrice
                          })
                          .Where(r => r.Stock > 0)
                          .ToList();

        if (!repuestos.Any())
        {
            Console.WriteLine("No spare parts available in stock.");
            return;
        }

        Console.WriteLine("=== Repuestos disponibles ===");
        foreach (var repuesto in repuestos)
        {
            Console.WriteLine($"ID: {repuesto.SparePartId}, Name: {repuesto.Name}, Stock: {repuesto.Stock}, Unit Price: {repuesto.UnitPrice}, Wholesale Price: {repuesto.WholesalePrice}");
        }
    }

    public static void Update()
    {
        Console.Write("ID of the spare part to update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        using var db = new Connection();
        var sparePart = db.SpareParts.Find(id);

        if (sparePart == null)
        {
            Console.WriteLine("Spare part not found.");
            return;
        }

        Console.Write($"Current name: {sparePart.Name}. New name: ");
        string name = Console.ReadLine();
        sparePart.Name = string.IsNullOrEmpty(name) ? sparePart.Name : name;

        Console.Write($"Current quantity: {sparePart.Quantity}. New quantity: ");
        string qtyInput = Console.ReadLine();
        if (int.TryParse(qtyInput, out int newQty))
            sparePart.Quantity = newQty;

        Console.Write($"Current unit price: {sparePart.UnitPrice}. New unit price: ");
        string unitPriceInput = Console.ReadLine();
        if (double.TryParse(unitPriceInput, out double newUnitPrice))
            sparePart.UnitPrice = newUnitPrice;

        Console.Write($"Current wholesale price: {sparePart.WholesalePrice}. New wholesale price: ");
        string wholesaleInput = Console.ReadLine();
        if (double.TryParse(wholesaleInput, out double newWholesale))
            sparePart.WholesalePrice = newWholesale;

        db.SaveChanges();
        Console.WriteLine("Spare part updated.");
    }

    public static void Delete()
    {
        Console.Write("ID of the spare part to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        using var db = new Connection();
        var sp = db.SpareParts.Find(id);

        if (sp == null)
        {
            Console.WriteLine("Spare part not found.");
            return;
        }

        db.SpareParts.Remove(sp);
        db.SaveChanges();
        Console.WriteLine("Spare part deleted.");
    }
}
