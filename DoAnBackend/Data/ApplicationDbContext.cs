using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace DoAnBackend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        #region
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceService> InvoicesServices { get; set; }
        public DbSet<InvoiceMedicine> InvoiceMedicines { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionDetail> PrescriptionDetails { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        #endregion

        #region
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())

            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType).Property<DateTime>("CreatedDate")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    modelBuilder.Entity(entityType.ClrType).Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");
                }
            }

            modelBuilder.Entity<Appointment>()
                   .Property(a => a.Status)
                   .IsRequired(false);

            // Appointment and Patient (1-to-Many)
            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

            // Appointment and Doctor (1-to-Many)
            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

            // Appointment and Nurse (1-to-Many)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Nurse)
                .WithMany(n => n.Appointments)
                .HasForeignKey(a => a.NurseId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            // Prescription and Patient (1-to-Many)
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Patient)
                .WithMany(pa => pa.Prescriptions)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            // Prescription and Doctor (1-to-Many)
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            // Prescription and Appointment (1-to-1)
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Appointment)
                .WithOne(a => a.Prescription)
                .HasForeignKey<Prescription>(p => p.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            // Invoice and Appointment (1-to-1)
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Appointment)
                .WithOne(a => a.Invoice)
                .HasForeignKey<Invoice>(i => i.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            // Invoice and Prescription (1-1)
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Prescription)
                .WithOne(p => p.Invoice)
                .HasForeignKey<Invoice>(i => i.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            // (Many-Many) between Invoice and Service through InvoiceService
            modelBuilder.Entity<InvoiceService>()
                .HasOne(ise => ise.Invoice)
                .WithMany(i => i.InvoiceServices)
                .HasForeignKey(ise => ise.InvoicedId)
                .IsRequired(false);

            modelBuilder.Entity<InvoiceService>()
                .HasOne(ise => ise.Service)
                .WithMany(s => s.InvoiceServices)
                .HasForeignKey(ise => ise.ServiceId)
                .IsRequired(false);

            // (Many-Many) between Invoice and Medicine through InvoiceMedicine
            modelBuilder.Entity<InvoiceMedicine>()
                .HasOne(im => im.Invoice)
                .WithMany(i => i.InvoiceMedicines)
                .HasForeignKey(im => im.InvoiceId)
                .IsRequired(false);

            modelBuilder.Entity<InvoiceMedicine>()
                .HasOne(im => im.Medicine)
                .WithMany(m => m.InvoiceMedicines)
                .HasForeignKey(im => im.MedicineId)
                .IsRequired(false);

            // PrescriptionDetail and Prescription (1-to-Many)
            modelBuilder.Entity<PrescriptionDetail>()
                .HasOne(pd => pd.Prescription)
                .WithMany(p => p.PrescriptionDetails)
                .HasForeignKey(pd => pd.PrescriptionId)
                .IsRequired(false);

            //  PrescriptionDetail and Medicine (Many-To-Many)
            modelBuilder.Entity<PrescriptionDetail>()
                .HasOne(pd => pd.Medicine)
                .WithMany(m => m.PrescriptionDetails)
                .HasForeignKey(pd => pd.MedicineId)
                .IsRequired(false);
            // Nurse and Shift (1-to-Many)
            modelBuilder.Entity<Shift>()
                .HasOne(s => s.Nurse)
                .WithMany(n => n.Shifts)
                .HasForeignKey(s => s.NurseId)
                .OnDelete(DeleteBehavior.Restrict);
            // Doctor and Shift (1-To-Many)
            modelBuilder.Entity<Shift>()
                .HasOne(s => s.Doctor)
                .WithMany(n => n.Shifts)
                .HasForeignKey(s => s.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // UserApplication and Role
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.HasMany(e => e.UserRoles)
                 .WithOne(e => e.User)
                 .HasForeignKey(ur => ur.UserId)
                 .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                b.HasMany(e => e.UserRoles)
                 .WithOne(e => e.Role)
                 .HasForeignKey(ur => ur.RoleId)
                 .IsRequired();
            });
        }
        #endregion
    }
}
