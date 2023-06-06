using AppointmentsAPI.Application.Abstraction;
using AppointmentsAPI.Application.Abstraction.Models;
using AppointmentsAPI.Application.Filtrators;
using AppointmentsAPI.Domain;
using AppointmentsAPI.Domain.Interfaces;
using AutoMapper;
using FluentValidation;
using MassTransit;
using SharedEvents.Models;

namespace AppointmentsAPI.Application
{
    public class AppointmentService : BaseService, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IValidator<CreateAppointmentModel> _createValidator;
        private readonly IMapper _mapper;
        public AppointmentService(IAppointmentRepository appointmentRepository, IPublishEndpoint publishEndpoint, IValidator<CreateAppointmentModel> createValidator, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _publishEndpoint = publishEndpoint;
            _createValidator = createValidator;
            _mapper = mapper;
        }
        public async Task<AppointmentDTO> AddAppointmentAsync(CreateAppointmentModel model, CancellationToken cancellationToken = default)
        {
            await ValidateModel(model, _createValidator, cancellationToken);

            var appointment = _mapper.Map<Appointment>(model);
            await _appointmentRepository.AddAsync(appointment, cancellationToken);

            return _mapper.Map<AppointmentDTO>(appointment);
        }

        public async Task ApproveAppointmentAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _appointmentRepository.ApproveAsync(id, cancellationToken);
            var appointment = await _appointmentRepository.GetAppointmentById(id, cancellationToken);
            await _publishEndpoint.Publish(new AppointmentApproved(appointment.PatientId,
                                                             appointment.Patient!.ToString(),
                                                             appointment.Doctor!.ToString(),
                                                             appointment.Date.ToDateTime(appointment.Time),
                                                             appointment.Service!.Name));
        }

        public Task CancelAppointmentAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _appointmentRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsAsync(int pageSize, int pageNumber, AppointmentsFiltrationModel filtrationModel, CancellationToken cancellationToken = default)
        {
            var filtrator = _mapper.Map<AppointmentFiltrator>(filtrationModel);
            var appointments = await _appointmentRepository.GetAppointmentsAsync(pageSize, pageNumber, filtrator, cancellationToken);
            return _mapper.Map<IEnumerable<AppointmentDTO>>(appointments);
        }

        public Task RescheduleAppointmentAsync(Guid Id, Guid doctorId, DateOnly date, TimeOnly time, CancellationToken cancellationToken = default)
        {
            return _appointmentRepository.RescheduleAsync(Id, doctorId, date, time, cancellationToken);
        }
    }
}
