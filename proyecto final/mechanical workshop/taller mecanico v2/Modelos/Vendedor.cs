using System;
using System.ComponentModel.DataAnnotations;

public class Seller
{
    [Key]
    public int SellerId { get; set; }
    public string FirstName { get; set; }   
    public string LastName { get; set; }    
    public string Email { get; set; }       
    public string PhoneNumber { get; set; } 

    public List<Vehicle> Vehicles{ get; set; }

    public List<Repair> Repairs { get; set; }
    public List<SparePart> SpareParts { get; set; }

    public List<Invoice> Invoices { get; set; }

    public Seller() { }

    public Seller(int sellerId, string firstName, string lastName, string email, string phoneNumber)
    {
        this.SellerId = sellerId;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
    }
}
