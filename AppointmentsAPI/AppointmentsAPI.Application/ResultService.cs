using AppointmentsAPI.Application.Abstraction;
using AppointmentsAPI.Application.Abstraction.AggregatesModels.ResultAggregate;
using AppointmentsAPI.Domain;
using AppointmentsAPI.Domain.Interfaces;
using AutoMapper;
using FluentValidation;

namespace AppointmentsAPI.Application
{
    public class ResultService : BaseService, IResultService
    {
        private IResultRepository _resultRepository;
        private IValidator<CreateResultModel> _createValidator;
        private IValidator<EditResultModel> _editValidator;
        private IMapper _mapper;

        public ResultService(IResultRepository resultRepository, IValidator<CreateResultModel> createValidator,
                            IValidator<EditResultModel> editValidator, IMapper mapper)
        {
            _resultRepository = resultRepository;
            _createValidator = createValidator;
            _editValidator = editValidator;
            _mapper = mapper;
        }

        public async Task<ResultDTO> CreateResultAsync(CreateResultModel model, CancellationToken cancellationToken = default)
        {
            await ValidateModel(model, _createValidator, cancellationToken);

            var result = _mapper.Map<Result>(model);
            await _resultRepository.CreateAsync(result, cancellationToken);

            return _mapper.Map<ResultDTO>(result);
        }

        public async Task EditResultAsync(Guid id, EditResultModel model, CancellationToken cancellationToken = default)
        {
            await ValidateModel(model, _editValidator, cancellationToken);

            var result = _mapper.Map<Result>(model);
            await _resultRepository.UpdateAsync(id, result, cancellationToken);
        }

        public async Task<ResultDTO> GetResultByAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken = default)
        {
            var results = await _resultRepository.GetByAppointmentAsync(appointmentId, cancellationToken);
            return _mapper.Map<ResultDTO>(results);
        }
    }
}
