using System;
using System.ComponentModel.DataAnnotations;

public class Sale
{
    [Key]
    public int SaleId { get; set; }

    public int SparePartId { get; set; }



    public Customer Customer { get; set; } // Cliente


    public Seller Seller { get; set; }     // Vendedor

   
    public SparePart SparePart { get; set; } // Repuesto

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; } // Cantidad

    public double UnitPrice { get; set; }  // PrecioUnitario

    public double Total => UnitPrice * Quantity;

    public DateTime Date { get; set; } // Fecha

    public Sale() { }

    public Sale(Customer customer, Seller seller, SparePart sparePart, int quantity)
    {
        Customer = customer;
        Seller = seller;
        SparePart = sparePart;
        Quantity = quantity;
        UnitPrice = sparePart.UnitPrice; // Price frozen at the time of sale
        Date = DateTime.Now;
    }

    public string ShowDetail()
    {
        return $"SALE #{SaleId} - {Date:dd/MM/yyyy HH:mm}\n" +
               $"Customer: {Customer.FirstName}\n" +
               $"Seller: {Seller.FirstName}\n" +
               $"Spare Part: {SparePart.Name}\n" +
               $"Quantity: {Quantity}\n" +
               $"Unit Price: {UnitPrice:C}\n" +
               $"Total: {Total:C}";
    }
}
