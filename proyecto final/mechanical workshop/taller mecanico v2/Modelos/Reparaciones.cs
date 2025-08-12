using System;
using System.ComponentModel.DataAnnotations;

public class Repair
{
    [Key]
    public int RepairId { get; set; }
    public string VehicleLicensePlate { get; set; } 
    public int MechanicId { get; set; }             

    public int CustomerId {  get; set; }

    public int? InvoiceId { get; set; }

    public string Description { get; set; }         
    public double Cost { get; set; }                
    public DateTime Date { get; set; }              
    public Vehicle Vehicle { get; set; }            

    public Customer Customer { get; set; }

    public Invoice Invoice { get; set; }

    public Mechanic Mechanic { get; set; }          


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
