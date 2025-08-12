using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using workshop_manager_v2.dbcontext;

public class CustomerService
{
    public static void ViewById()
    {
        using var db = new Connection(new DbContextOptionsBuilder<Connection>().Options);

        Console.Write("Enter the customer ID to search: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var customer = db.Customers.Find(id);
            if (customer != null)
            {
                Console.WriteLine("=== Customer Information ===");
                Console.WriteLine($"ID: {customer.CustomerId}");
                Console.WriteLine($"First Name: {customer.FirstName}");
                Console.WriteLine($"Last Name: {customer.LastName}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    public static void Add()
    {
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("Phone Number: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();

        var customer = new Customer
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Email = email
        };

        using var db = new Connection();
        db.Customers.Add(customer);
        db.SaveChanges();

        Console.WriteLine("Customer added.");
    }

    public static void View()
    {
        try
        {
            using var db = new Connection();
            var customers = db.Customers.ToList();

            foreach (var c in customers)
            {
                Console.WriteLine($"ID: {c.CustomerId}, First Name: {c.FirstName}, Last Name: {c.LastName}, Phone Number: {c.PhoneNumber}, Email: {c.Email}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Update()
    {
        Console.Write("ID of the customer to update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        using var db = new Connection();
        var customer = db.Customers.Find(id);

        if (customer == null)
        {
            Console.WriteLine("Customer not found.");
            return;
        }

        Console.Write($"Current first name: {customer.FirstName}. New first name: ");
        string firstName = Console.ReadLine();
        customer.FirstName = string.IsNullOrEmpty(firstName) ? customer.FirstName : firstName;

        Console.Write($"Current last name: {customer.LastName}. New last name: ");
        string lastName = Console.ReadLine();
        customer.LastName = string.IsNullOrEmpty(lastName) ? customer.LastName : lastName;

        Console.Write($"Current phone number: {customer.PhoneNumber}. New phone number: ");
        string phoneNumber = Console.ReadLine();
        customer.PhoneNumber = string.IsNullOrEmpty(phoneNumber) ? customer.PhoneNumber : phoneNumber;

        Console.Write($"Current email: {customer.Email}. New email: ");
        string email = Console.ReadLine();
        customer.Email = string.IsNullOrEmpty(email) ? customer.Email : email;

        db.SaveChanges();
        Console.WriteLine("Customer updated.");
    }

    public static void Delete()
    {
        Console.Write("ID of the customer to delete: ");
        int id = int.Parse(Console.ReadLine());

        using var db = new Connection();
        var customer = db.Customers.Find(id);

        if (customer == null)
        {
            Console.WriteLine("Customer not found.");
            return;
        }

        db.Customers.Remove(customer);
        db.SaveChanges();
        Console.WriteLine("Customer deleted.");
    }
}
