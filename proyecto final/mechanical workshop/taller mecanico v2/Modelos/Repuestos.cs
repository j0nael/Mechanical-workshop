using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class SparePart
{
    [Key]
    public int SparePartId { get; set; }

    public int? CustomerId {  get; set; }

    public int? InvoiceId { get; set; }

    public int? SellerId { get; set; }

    public string Name { get; set; }                 

    public int InitialQuantity { get; set; }         

    public int Quantity { get; set; }                

    public double UnitPrice { get; set; }            

    public double WholesalePrice { get; set; }       

    public DateTime EntryDate { get; set; } = DateTime.Now; 

  
    public List<Sale> Sales { get; set; } = new();   

    public Customer Customer { get; set; }

    public Invoice Invoice { get; set; }

    public Seller Seller { get; set; }

    public SparePart() { }

    public SparePart(int sparePartId,string name, int quantity, double unitPrice, double wholesalePrice)
    {
        this.SparePartId = sparePartId;
        this.Name = name;
        this.Quantity = quantity;
        this.InitialQuantity = quantity;
        this.UnitPrice = unitPrice;
        this.WholesalePrice = wholesalePrice;
        this.EntryDate = DateTime.Now;
    }
}
