using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using workshop_manager_v2.dbcontext;

public class VehicleService
{
    public static void ViewByLicensePlate()
    {
        using var connection = new Connection(new DbContextOptionsBuilder<Connection>().Options);

        Console.Write("Enter the vehicle's license plate to search: ");
        string licensePlate = Console.ReadLine();

        if (string.IsNullOrEmpty(licensePlate))
        {
            Console.WriteLine("Invalid license plate.");
            return;
        }

        var vehicle = connection.Vehicles.Find(licensePlate);
        if (vehicle != null)
        {
            Console.WriteLine("=== Vehicle Information ===");
            Console.WriteLine($"License Plate: {vehicle.LicensePlate}");
            Console.WriteLine($"Model: {vehicle.Model}");
            Console.WriteLine($"Brand: {vehicle.Brand}");
            Console.WriteLine($"Year: {vehicle.Year}");
            Console.WriteLine($"Client ID: {vehicle.CustomerId}");
        }
        else
        {
            Console.WriteLine("Vehicle not found.");
        }
    }

    public static void Add()
    {
        Console.Write("License Plate: ");
        string licensePlate = Console.ReadLine();
        Console.Write("Brand: ");
        string brand = Console.ReadLine();
        Console.Write("Model: ");
        string model = Console.ReadLine();
        Console.Write("Color: ");
        string color = Console.ReadLine();
        Console.Write("Year: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Client ID: ");
        int customerId = int.Parse(Console.ReadLine());
       
        var vehicle = new Vehicle(licensePlate, brand, model,color, year, customerId);

        using var db = new Connection();
        db.Vehicles.Add(vehicle);
        db.SaveChanges();

        db.Vehicles.Include( v => v.Customer).First();

        Console.WriteLine("Vehicle added.");
    }

    public static void View()
    {
        using var db = new Connection();
        var list = db.Vehicles.ToList();

        foreach (var v in list)
        {
            Console.WriteLine($"License Plate: {v.LicensePlate}, Brand: {v.Brand}, Model: {v.Model}, Color: {v.Color},Year: {v.Year}, Client ID: {v.CustomerId}");
        }
    }

    public static void Update()
    {
        Console.Write("License plate of the vehicle to update: ");
        string id = Console.ReadLine();

        using var db = new Connection();
        var v = db.Vehicles.Find(id);

        if (v == null)
        {
            Console.WriteLine("Vehicle not found.");
            return;
        }

        Console.Write($"Current license plate ({v.LicensePlate}). New license plate: ");
        string licensePlate = Console.ReadLine();
        v.LicensePlate = string.IsNullOrEmpty(licensePlate) ? v.LicensePlate : licensePlate;

        Console.Write($"Current brand ({v.Brand}). New brand: ");
        string brand = Console.ReadLine();
        v.Brand = string.IsNullOrEmpty(brand) ? v.Brand : brand;

        Console.Write($"Current model ({v.Model}). New model: ");
        string model = Console.ReadLine();
        v.Model = string.IsNullOrEmpty(model) ? v.Model : model;

        Console.Write($"Current model ({v.Color}). New color: ");
        string color = Console.ReadLine();
        v.Color = string.IsNullOrEmpty(color) ? v.Color : color;

        Console.Write($"Current year: {v.Year}. New year: ");
        string yearInput = Console.ReadLine();
        v.Year = int.TryParse(yearInput, out int newYear) ? newYear : v.Year;

        db.SaveChanges();
        Console.WriteLine("Vehicle updated.");
    }

    public static void Delete()
    {
        Console.Write("License plate of the vehicle to delete: ");
        string id = Console.ReadLine();

        using var db = new Connection();
        var vehicle = db.Vehicles.Find(id);

        if (vehicle == null)
        {
            Console.WriteLine("Vehicle not found.");
            return;
        }

        db.Vehicles.Remove(vehicle);
        db.SaveChanges();
        Console.WriteLine("Vehicle deleted.");
    }
}
