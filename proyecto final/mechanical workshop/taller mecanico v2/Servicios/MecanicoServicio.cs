using Microsoft.EntityFrameworkCore;
using workshop_manager_v2.dbcontext;
using System;
using System.Linq;

namespace workshop_manager_v2
{
    public class MechanicService
    {
        public static void ServiceHistory()
        {
            using var db = new Connection();

            Console.Write("Enter the date to search: ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime filterDate))
            {
                Console.WriteLine("Invalid date.");
                return;
            }

            var history = db.Repairs
                .Include(r => r.Mechanic)
                .Include(r => r.Vehicle)
                .Where(r => r.Date.Date == filterDate.Date)
                .ToList();

            if (history.Count == 0)
            {
                Console.WriteLine("No repairs found for that date.");
                return;
            }

            foreach (var r in history)
            {
                Console.WriteLine($"Repair ID: {r.RepairId} | Mechanic: {r.Mechanic.FirstName} | Vehicle: {r.Vehicle.Brand} {r.Vehicle.Model} | Description: {r.Description} | Date: {r.Date:yyyy-MM-dd}");
            }
        }

        public static void Add()
        {
            Console.WriteLine("Enter mechanic's first name:");
            string firstName = Console.ReadLine() ?? "NoName";

            Console.WriteLine("Enter mechanic's specialty:");
            string specialty = Console.ReadLine() ?? "NoSpecialty";

            Mechanic mechanic = new Mechanic(0,firstName,specialty);

            using var db = new Connection(new DbContextOptionsBuilder<Connection>().Options);
            db.Mechanics.Add(mechanic);
            db.SaveChanges();

            Console.WriteLine("Mechanic added successfully.");
        }

        public static void ViewAll()
        {
            using var connection = new Connection(new DbContextOptionsBuilder<Connection>().Options);
            var mechanics = connection.Mechanics.ToList();

            Console.WriteLine("=== List of Mechanics ===");
            foreach (var m in mechanics)
            {
                Console.WriteLine($"ID: {m.MechanicId}, First Name: {m.FirstName}, Specialty: {m.Specialty}");
            }
        }

        public static void ViewById()
        {
            using var connection = new Connection(new DbContextOptionsBuilder<Connection>().Options);

            Console.Write("Enter the mechanic ID to consult: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var mechanic = connection.Mechanics.Find(id);
                if (mechanic != null)
                {
                    Console.WriteLine("=== Mechanic Information ===");
                    Console.WriteLine($"ID: {mechanic.MechanicId}");
                    Console.WriteLine($"First Name: {mechanic.FirstName}");
                    Console.WriteLine($"Specialty: {mechanic.Specialty}");
                }
                else
                {
                    Console.WriteLine("Mechanic not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        public static void Update()
        {
            Console.Write("Mechanic ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            using var db = new Connection();
            var mechanic = db.Mechanics.Find(id);

            if (mechanic == null)
            {
                Console.WriteLine("Mechanic not found.");
                return;
            }

            Console.Write("Current first name: {mechanic.FirstName}. New first name: ");
            string firstName = Console.ReadLine();
            mechanic.FirstName = string.IsNullOrEmpty(firstName) ? mechanic.FirstName : firstName;

            Console.Write("Current specialty: {mechanic.Specialty}. New specialty: ");
            string specialty = Console.ReadLine();
            mechanic.Specialty = string.IsNullOrEmpty(specialty) ? mechanic.Specialty : specialty;

            db.SaveChanges();
            Console.WriteLine("Mechanic updated.");
        }

        public static void Delete()
        {
            using var connection = new Connection(new DbContextOptionsBuilder<Connection>().Options);
            Console.Write("Enter the mechanic ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var mechanic = connection.Mechanics.Find(id);
                if (mechanic != null)
                {
                    connection.Mechanics.Remove(mechanic);
                    connection.SaveChanges();
                    Console.WriteLine("Mechanic deleted.");
                }
                else
                {
                    Console.WriteLine("Mechanic not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }
    }
}
