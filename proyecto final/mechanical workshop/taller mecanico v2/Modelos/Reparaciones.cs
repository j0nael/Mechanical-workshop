using System;
using System.ComponentModel.DataAnnotations;

public class Repair
{
    [Key]
    public int RepairId { get; set; }
    public string VehicleLicensePlate { get; set; } // PlacaVehiculo
    public int MechanicId { get; set; }              // IdMecanico

    public int CustomerId {  get; set; }

    public int? InvoiceId { get; set; }

    public string Description { get; set; }         // Descripcion
    public double Cost { get; set; }                 // Costo
    public DateTime Date { get; set; }               // Fecha
    public Vehicle Vehicle { get; set; }             // Vehiculo

    public Customer Customer { get; set; }

    public Invoice Invoice { get; set; }

    public Mechanic Mechanic { get; set; }           // Mecanico


    public Repair() { }

    public Repair(int id, int CustomerId,string vehicleLicensePlate, int mechanicId, string description, double cost, DateTime date)
    {
        this.RepairId= id;
        this.CustomerId = CustomerId;
        this.VehicleLicensePlate = vehicleLicensePlate;
        this.MechanicId = mechanicId;
        this.Description = description;
        this.Cost = cost;
        this.Date = date;
    }
}
