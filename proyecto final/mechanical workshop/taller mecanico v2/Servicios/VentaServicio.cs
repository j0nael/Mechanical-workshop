using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using workshop_manager_v2.dbcontext;


public class SalesService
{
    public static void ViewSalesByDateRange()
    {
        using var db = new Connection();

        Console.WriteLine("Filter sales by date range");

        Console.Write("Start date (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
        {
            Console.WriteLine("Invalid start date.");
            return;
        }

        Console.Write("End date (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
        {
            Console.WriteLine("Invalid end date.");
            return;
        }

        endDate = endDate.Date.AddDays(1).AddTicks(-1);

        var sales = db.Sales
            .Include(s => s.Customer)
            .Include(s => s.Seller)
            .Include(s => s.SparePart)
            .Where(s => s.Date >= startDate && s.Date <= endDate)
            .ToList();

        if (sales.Count == 0)
        {
            Console.WriteLine("No sales found in the selected date range.");
            return;
        }

        foreach (var s in sales)
        {
            Console.WriteLine($"ID: {s.SaleId} | Customer: {s.Customer.FirstName} | Seller: {s.Seller.FirstName} | Spare Part: {s.SparePart.Name} | Quantity: {s.Quantity} | Total: {s.Total:C} | Date: {s.Date:yyyy-MM-dd}");
        }
    }

    public static void AddSale()
    {
        using var db = new Connection();

        Console.Write("Customer ID: ");
        int customerId = int.Parse(Console.ReadLine());
        var customer = db.Customers.Find(customerId);
        if (customer == null)
        {
            Console.WriteLine("Customer not found.");
            return;
        }

        Console.Write("Seller ID: ");
        int sellerId = int.Parse(Console.ReadLine());
        var seller = db.Sellers.Find(sellerId);
        if (seller == null)
        {
            Console.WriteLine("Seller not found.");
            return;
        }

        Console.Write("Spare Part ID: ");
        int sparePartId = int.Parse(Console.ReadLine());
        var sparePart = db.SpareParts.Find(sparePartId);
        if (sparePart == null)
        {
            Console.WriteLine("Spare part not found.");
            return;
        }

        Console.Write("Quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        var sale = new Sale
        {
            Customer = customer,
            Seller = seller,
            SparePart = sparePart,
            Quantity = quantity,
            UnitPrice = sparePart.UnitPrice,
            Date = DateTime.Now
        };

        db.Sales.Add(sale);
        db.SaveChanges();

        double total = sale.Total;

        Console.WriteLine("\n=== Sale successfully recorded ===");
        Console.WriteLine($"Customer: {customer.FirstName}");
        Console.WriteLine($"Seller: {seller.FirstName}");
        Console.WriteLine($"Spare Part: {sparePart.Name}");
        Console.WriteLine($"Quantity: {quantity}");
        Console.WriteLine($"Unit Price: {sale.UnitPrice}");
        Console.WriteLine($"Total to pay: {total}");
        Console.WriteLine($"Date: {sale.Date:yyyy-MM-dd HH:mm}");
    }

    public static void ViewAll()
    {
        using var db = new Connection();
        var sales = db.Sales
            .Include(s => s.Customer)
            .Include(s => s.Seller)
            .Include(s => s.SparePart)
            .ToList();

        foreach (var s in sales)
        {
            Console.WriteLine($"ID: {s.SaleId} | Customer: {s.Customer.FirstName} | Seller: {s.Seller.FirstName} | Spare Part: {s.SparePart.Name} | Quantity: {s.Quantity} | Price: {s.UnitPrice} | Total: {s.Total:C} | Date: {s.Date:yyyy-MM-dd HH:mm}");
        }
    }

    public static void ViewById()
    {
        Console.Write("Sale ID to display: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        using var db = new Connection();
        var sale = db.Sales
            .Include(s => s.Customer)
            .Include(s => s.Seller)
            .Include(s => s.SparePart)
            .FirstOrDefault(s => s.SaleId == id);

        if (sale == null)
        {
            Console.WriteLine("Sale not found.");
            return;
        }

        Console.WriteLine($"ID: {sale.SaleId}");
        Console.WriteLine($"Customer: {sale.Customer.FirstName}");
        Console.WriteLine($"Seller: {sale.Seller.FirstName}");
        Console.WriteLine($"Spare Part: {sale.SparePart.Name}");
        Console.WriteLine($"Quantity: {sale.Quantity}");
        Console.WriteLine($"Unit Price: {sale.UnitPrice}");
        Console.WriteLine($"Total: {sale.Total}");
        Console.WriteLine($"Date: {sale.Date:yyyy-MM-dd HH:mm}");
    }

    public static void Update()
    {
        Console.Write("Sale ID to update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        using var db = new Connection();
        var sale = db.Sales
            .Include(s => s.Customer)
            .Include(s => s.Seller)
            .Include(s => s.SparePart)
            .FirstOrDefault(s => s.SaleId == id);

        if (sale == null)
        {
            Console.WriteLine("Sale not found.");
            return;
        }

        Console.WriteLine($"Current Customer: {sale.Customer.FirstName} (ID: {sale.Customer.CustomerId})");
        Console.Write("New Customer ID (press enter to keep current): ");
        string customerInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(customerInput) && int.TryParse(customerInput, out int newCustomerId))
        {
            var newCustomer = db.Customers.Find(newCustomerId);
            if (newCustomer != null)
                sale.Customer = newCustomer;
            else
                Console.WriteLine("Customer not found. Not updated.");
        }

        Console.WriteLine($"Current Seller: {sale.Customer.FirstName} (ID: {sale.Seller.SellerId})");
        Console.Write("New Seller ID (press enter to keep current): ");
        string sellerInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(sellerInput) && int.TryParse(sellerInput, out int newSellerId))
        {
            var newSeller = db.Sellers.Find(newSellerId);
            if (newSeller != null)
                sale.Seller = newSeller;
            else
                Console.WriteLine("Seller not found. Not updated.");
        }

        Console.WriteLine($"Current Spare Part: {sale.Customer.FirstName} (ID: {sale.SparePart.SellerId})");
        Console.Write("New Spare Part ID (press enter to keep current): ");
        string sparePartInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(sparePartInput) && int.TryParse(sparePartInput, out int newSparePartId))
        {
            var newSparePart = db.SpareParts.Find(newSparePartId);
            if (newSparePart != null)
            {
                sale.SparePart = newSparePart;
                sale.UnitPrice = newSparePart.UnitPrice; 
            }
            else
                Console.WriteLine("Spare part not found. Not updated.");
        }

        Console.Write($"Current quantity: {sale.Quantity}. New quantity: ");
        string quantityInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(quantityInput) && int.TryParse(quantityInput, out int newQuantity))
        {
            sale.Quantity = newQuantity;
        }

        db.SaveChanges();
        Console.WriteLine("Sale updated.");
    }

    public static void Delete()
    {
        Console.Write("Sale ID to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        using var db = new Connection();
        var sale = db.Sales.Find(id);

        if (sale == null)
        {
            Console.WriteLine("Sale not found.");
            return;
        }

        db.Sales.Remove(sale);
        db.SaveChanges();
        Console.WriteLine("Sale deleted.");
    }
}
