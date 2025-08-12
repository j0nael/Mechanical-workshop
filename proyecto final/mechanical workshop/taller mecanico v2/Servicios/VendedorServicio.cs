using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using workshop_manager_v2.dbcontext;

public class SalespersonService
{
    public static void Add()
    {
        Console.Write("Salesperson's First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Salesperson's Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("Salesperson's Email: ");
        string email = Console.ReadLine();
        Console.Write("Salesperson's Phone Number: ");
        string phoneNumber = Console.ReadLine();

        var salesperson = new Seller
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber
        };

        using var db = new Connection();
        db.Sellers.Add(salesperson);
        db.SaveChanges();

        Console.WriteLine("Salesperson added.");
    }

    public static void ViewAll()
    {
        using var db = new Connection();
        var salespersons = db.Sellers.ToList();

        foreach (var s in salespersons)
        {
            Console.WriteLine($"ID: {s.SellerId}, First Name: {s.FirstName}, Last Name: {s.LastName}, Email: {s.Email}, Phone Number: {s.PhoneNumber}");
        }
    }

    public static void ViewById()
    {
        using var db = new Connection(new DbContextOptionsBuilder<Connection>().Options);

        Console.Write("Enter the ID of the salesperson to consult: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var salesperson = db.Sellers.Find(id);
            if (salesperson != null)
            {
                Console.WriteLine("=== Salesperson Information ===");
                Console.WriteLine($"ID: {salesperson.SellerId}");
                Console.WriteLine($"First Name: {salesperson.FirstName}");
                Console.WriteLine($"Last Name: {salesperson.LastName}");
                Console.WriteLine($"Email: {salesperson.Email}");
                Console.WriteLine($"Phone Number: {salesperson.PhoneNumber}");
            }
            else
            {
                Console.WriteLine("Salesperson not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    public static void Update()
    {
        Console.Write("ID of the salesperson to update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        using var db = new Connection();
        var salesperson = db.Sellers.Find(id);

        if (salesperson == null)
        {
            Console.WriteLine("Salesperson not found.");
            return;
        }

        Console.Write($"Current First Name: {salesperson.FirstName}. New First Name: ");
        string firstName = Console.ReadLine();
        salesperson.FirstName = string.IsNullOrEmpty(firstName) ? salesperson.FirstName : firstName;

        Console.Write($"Current Last Name: {salesperson.LastName}. New Last Name: ");
        string lastName = Console.ReadLine();
        salesperson.LastName = string.IsNullOrEmpty(lastName) ? salesperson.LastName : lastName;

        Console.Write($"Current Email: {salesperson.Email}. New Email: ");
        string email = Console.ReadLine();
        salesperson.Email = string.IsNullOrEmpty(email) ? salesperson.Email : email;

        Console.Write($"Current Phone Number: {salesperson.PhoneNumber}. New Phone Number: ");
        string phoneNumber = Console.ReadLine();
        salesperson.PhoneNumber = string.IsNullOrEmpty(phoneNumber) ? salesperson.PhoneNumber : phoneNumber;

        db.SaveChanges();
        Console.WriteLine("Salesperson updated.");
    }

    public static void Delete()
    {
        Console.Write("ID of the salesperson to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        using var db = new Connection();
        var salesperson = db.Sellers.Find(id);

        if (salesperson == null)
        {
            Console.WriteLine("Salesperson not found.");
            return;
        }

        db.Sellers.Remove(salesperson);
        db.SaveChanges();
        Console.WriteLine("Salesperson deleted.");
    }
}
