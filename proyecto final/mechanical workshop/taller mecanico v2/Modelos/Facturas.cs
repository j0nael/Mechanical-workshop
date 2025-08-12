using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Invoice
{
    [Key]
    public int InvoiceId { get; set; }

    public int CustomerId {  get; set; }

    public int SellerId { get; set; }

    public Customer Customer { get; set; }       
    public Seller Seller { get; set; }           

    public DateTime Date { get; set; }           

    public List<Sale> SaleDetails { get; set; }  

    public List<Vehicle> Vehicles { get; set; }

    public List<SparePart> SpareParts { get; set; }

    public List<Repair> Repairs { get; set; }



    public double Total
    {
        get
        {
            double total = 0;
            foreach (var sale in SaleDetails)
            {
                total += sale.Total;
            }
            return total;
        }
    }

    public Invoice()
    {
        SaleDetails = new List<Sale>();
        Date = DateTime.Now;
    }

    public Invoice(int InvoiceId, Customer customer, Seller seller)
    {
        this.InvoiceId = InvoiceId;
        this.Customer = customer;
        this.Seller = seller;
        this.Date = DateTime.Now;
        this.SaleDetails = new List<Sale>();
    }

    public void AddSale(Sale sale)
    {
        SaleDetails.Add(sale);
    }

    public string ShowInvoice()
    {
        string details = $"--- INVOICE #{InvoiceId} ---\n" +
                         $"Date: {Date}\n" +
                         $"Customer: {Customer.FirstName}\n" +
                         $"Seller: {Seller.FirstName}\n\n" +
                         $"DETAILS:\n";

        foreach (var sale in SaleDetails)
        {
            details += $"- {sale.Quantity} x {sale.SparePart.Name} @ {sale.SparePart.UnitPrice:C} = {sale.Total:C}\n";
        }

        details += $"\nTOTAL: {Total:C}";

        return details;
    }
}
