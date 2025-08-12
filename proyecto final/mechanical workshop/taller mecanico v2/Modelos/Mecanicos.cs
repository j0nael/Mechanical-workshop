using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Mechanic
{
    [Key]
    public int MechanicId { get; set; }
    public string FirstName { get; set; }       // Nombre
    public string Specialty { get; set; }       // Especialidad

    public List<Repair> Repairs { get; set; }   // Reparaciones

    public Mechanic(int mechanicId,string firstName, string specialty)
    {
        this.MechanicId = mechanicId;
        this.FirstName = firstName;
        this.Specialty = specialty;
    }

    public Mechanic() { }
}
