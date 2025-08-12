using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Vehicle
{
    [Key]
    public string LicensePlate { get; set; }       
    public string Brand { get; set; }              
    public string Model { get; set; }              
    public string Color { get; set; }
    public int Year { get; set; }                  
    public int CustomerId { get; set; }    

    public int? SellerId{ get; set; }

    public int? InvoiceId { get; set; }

    public Invoice Invoice { get; set; }

    public Customer Customer { get; set; }

    public Seller Seller { get; set; }        

    public List<Repair> Repairs { get; set; }   

    public Vehicle(string licensePlate, string brand, string model, string color,int year, int customerId)
    {
        LicensePlate = licensePlate;
        Brand = brand;
        Model = model;
        Color = color;
        Year = year;
        CustomerId = customerId;
       
    }
}
