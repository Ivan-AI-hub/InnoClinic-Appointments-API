using AppointmentsAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentsAPI.Persistence.EntityConfigurations
{
    internal class AppointmentConfigurator : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasOne(x => x.Doctor);
            builder.HasOne(x => x.Patient);
            builder.HasOne(x => x.Service);
        }
    }
}
