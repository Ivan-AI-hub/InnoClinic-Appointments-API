﻿using AppointmentsAPI.Application.Abstraction;
using AppointmentsAPI.Application.Abstraction.AggregatesModels.AppointmentAggregate;
using AppointmentsAPI.Application.Filtrators;
using AppointmentsAPI.Domain;
using AppointmentsAPI.Domain.Interfaces;
using AutoMapper;
using FluentValidation;

namespace AppointmentsAPI.Application
{
    public class AppointmentService : BaseService, IAppointmentService
    {
        private IAppointmentRepository _appointmentRepository;
        private IValidator<CreateAppointmentModel> _createValidator;
        private IMapper _mapper;
        public AppointmentService(IAppointmentRepository appointmentRepository, IValidator<CreateAppointmentModel> createValidator, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
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

        public Task ApproveAppointmentAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _appointmentRepository.ApproveAsync(id, cancellationToken);
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

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctorAsync(Guid doctorId, CancellationToken cancellationToken = default)
        {
            var appointments = await _appointmentRepository.GetByDoctorAsync(doctorId, cancellationToken);
            return _mapper.Map<IEnumerable<AppointmentDTO>>(appointments);
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsHistoryAsync(Guid patientId, CancellationToken cancellationToken = default)
        {
            var appointments = await _appointmentRepository.GetByPatientAsync(patientId, cancellationToken);
            return _mapper.Map<IEnumerable<AppointmentDTO>>(appointments);
        }

        public Task RescheduleAppointmentAsync(Guid Id, DoctorDTO doctor, DateOnly date, TimeOnly time, CancellationToken cancellationToken = default)
        {
            return _appointmentRepository.RescheduleAsync(Id, _mapper.Map<Doctor>(doctor), date, time, cancellationToken);
        }
    }
}