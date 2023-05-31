using AppointmentsAPI.Domain;
using AppointmentsAPI.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AppointmentsAPI.Persistence
{
    public class AppointmentsContext : DbContext
    {
        public AppointmentsContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorConfigurator());
            modelBuilder.ApplyConfiguration(new AppointmentConfigurator());
            modelBuilder.ApplyConfiguration(new PatientConfigurator());
            modelBuilder.ApplyConfiguration(new ServiceConfigurator());
            modelBuilder.ApplyConfiguration(new ResultConfigurator());
        }
    }
}
