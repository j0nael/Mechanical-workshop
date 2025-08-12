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

        var sparePart = new SparePart(0,name, quantity, unitPrice, wholesalePrice);

        using var db = new Connection();
        db.SpareParts.Add(sparePart);
        db.SaveChanges();

        Console.WriteLine("Spare part added.");
    }

    public static void View()
    {
        using var db = new Connection();
        var list = db.SpareParts.ToList();

        foreach (var sp in list)
        {
            Console.WriteLine($"ID: {sp.SparePartId}, Name: {sp.Name}, Quantity: {sp.Quantity}, Unit Price: {sp.UnitPrice}, Wholesale Price: {sp.WholesalePrice}");
        }
    }

    public static void Update()
    {
        Console.Write("ID of the repair to update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        using var db = new Connection();
        var repair = db.Repairs.Find(id);

        if (repair == null)
        {
            Console.WriteLine("Repair not found.");
            return;
        }

        Console.Write($"Current description: {repair.Description}. New description: ");
        string description = Console.ReadLine();
        repair.Description = string.IsNullOrEmpty(description) ? repair.Description : description;

        Console.Write($"Current date: {repair.Date.ToShortDateString()}. New date (yyyy-MM-dd): ");
        string dateInput = Console.ReadLine();
        if (DateTime.TryParse(dateInput, out DateTime newDate))
            repair.Date = newDate;

        Console.Write($"Current cost: {repair.Cost}. New cost: ");
        string costInput = Console.ReadLine();
        if (double.TryParse(costInput, out double newCost))
            repair.Cost = newCost;

        db.SaveChanges();
        Console.WriteLine("Repair updated.");
    }

    public static void Delete()
    {
        Console.Write("ID of the spare part to delete: ");
        int id = int.Parse(Console.ReadLine());

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
