using System;
using System.Linq;
using workshop_manager_v2.dbcontext;
using Microsoft.EntityFrameworkCore;

public class ReporteServicio
{
    public static void VerVentasYServiciosPorFecha()
    {
        using var db = new Connection();

        Console.Write("Fecha inicio (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaInicio))
        {
            Console.WriteLine("Fecha inicio inválida.");
            return;
        }

        Console.Write("Fecha fin (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaFin))
        {
            Console.WriteLine("Fecha fin inválida.");
            return;
        }

        // Ajustar fechaFin para incluir todo el día
        fechaFin = fechaFin.Date.AddDays(1).AddTicks(-1);

        // Consultar ventas en rango de fechas
        var sales = db.Sales
            .Include(v => v.Customer)
            .Include(v => v.Seller)
            .Include(v => v.SparePart)
            .Where(v => v.Date >= fechaInicio && v.Date <= fechaFin)
            .ToList();

        var reparaciones = db.Repairs
            .Include(r => r.Mechanic)
            .Include(r => r.Vehicle)
            .Where(r => r.Date >= fechaInicio && r.Date <= fechaFin)
            .ToList();

        Console.WriteLine("=== VENTAS ===");
        if (sales.Count == 0)
        {
            Console.WriteLine("No se encontraron ventas en este rango.");
        }
        else
        {
            foreach (var v in sales)
            {
                double total = v.SparePart.UnitPrice * v.Quantity;
                Console.WriteLine($"ID Venta: {v.SaleId} | Cliente: {v.Customer.FirstName} {v.Customer.LastName} | Vendedor: {v.Seller.FirstName} {v.Seller.LastName}| Repuesto: {v.SparePart.Name} | Cantidad: {v.Quantity} | Total: {total} | Fecha: {v.Date:yyyy-MM-dd}");
            }
        }

        Console.WriteLine("\n=== SERVICIOS (REPARACIONES) ===");
        if (reparaciones.Count == 0)
        {
            Console.WriteLine("No se encontraron reparaciones en este rango.");
        }
        else
        {
            foreach (var r in reparaciones)
            {
                Console.WriteLine($"ID Reparación: {r.RepairId} | Mecánico: {r.Mechanic.FirstName} | Vehículo: {r.Vehicle.Brand} {r.Vehicle.Model} | Descripción: {r.Description} | Costo: {r.Cost} | Fecha: {r.Date:yyyy-MM-dd}");
            }
        }
    }
}
