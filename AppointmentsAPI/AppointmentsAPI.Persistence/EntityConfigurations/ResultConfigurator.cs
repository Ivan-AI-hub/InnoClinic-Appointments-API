using AppointmentsAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentsAPI.Persistence.EntityConfigurations
{
    internal class ResultConfigurator : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.HasOne(x => x.Appointment);
            builder.HasIndex(x => x.AppointmentId).IsUnique();
        }
    }
}
