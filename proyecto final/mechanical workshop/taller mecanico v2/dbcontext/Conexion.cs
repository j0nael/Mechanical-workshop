using Microsoft.EntityFrameworkCore;

namespace workshop_manager_v2.dbcontext
{
    public class Connection : DbContext
    {
        public Connection() { }
        public Connection(DbContextOptions<Connection> options) : base(options) { }

        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Persist Security Info=False;Trusted_Connection=True;database=Mechanic;server=(local);TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Customer)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(v => v.CustomerId);

            modelBuilder.Entity<Repair>()
                .HasOne(r => r.Vehicle)
                .WithMany(v => v.Repairs)
                .HasForeignKey(r => r.VehicleLicensePlate);

            modelBuilder.Entity<Repair>()
                .HasOne(r => r.Mechanic)
                .WithMany(m => m.Repairs)
                .HasForeignKey(r => r.MechanicId);
            modelBuilder.Entity<SparePart>()
    .HasOne(sp => sp.Invoice)
    .WithMany(i => i.SpareParts)
    .HasForeignKey(sp => sp.InvoiceId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>()
    .HasOne(v => v.Invoice)
    .WithMany(i => i.Vehicles)
    .HasForeignKey(v => v.InvoiceId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Customer)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(v => v.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Seller)
                .WithMany(s => s.Vehicles)
                .HasForeignKey(v => v.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Sale>()
    .HasOne(s => s.SparePart)
    .WithMany(sp => sp.Sales)
    .HasForeignKey(s => s.SparePartId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Repair>()
    .HasOne(r => r.Invoice)
    .WithMany(i => i.Repairs)
    .HasForeignKey(r => r.InvoiceId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Repair>()
    .HasOne(r => r.Vehicle)
    .WithMany(v => v.Repairs)
    .HasForeignKey(r => r.VehicleLicensePlate)
    .OnDelete(DeleteBehavior.Restrict); 



        }
    }
}
