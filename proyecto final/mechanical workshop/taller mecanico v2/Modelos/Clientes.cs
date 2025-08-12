using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    public string FirstName { get; set; }      // Nombre
    public string LastName { get; set; }       // Apellido
    public string PhoneNumber { get; set; }    // Telefono
    public string Email { get; set; }          // Correo
    

    public List<Vehicle> Vehicles { get; set; } // Vehiculos

    public List<Invoice> Invoices { get; set; }

    public List<Repair> Repairs { get; set; }

    public List<SparePart> SpareParts { get; set; }

    public Customer(int customerid, string firstName, string phoneNumber, string email, string lastName)
    {
        this.CustomerId = customerid;
        this.FirstName = firstName;
        this.PhoneNumber = phoneNumber;
        this.Email = email;
        this.LastName = lastName;
    }

    public Customer() { }
}
