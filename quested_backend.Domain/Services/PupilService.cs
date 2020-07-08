using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests_DTOs.Pupil;
using quested_backend.Domain.Responses_DTOs;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Services
{
    public class PupilService : IPupilService
    {
        private readonly IPupilRepository _pupilRepository;
        private readonly IPupilMapper _pupilMapper;
        
        public PupilService(IPupilRepository pupilRepository, IPupilMapper pupilMapper)
        {
            _pupilRepository = pupilRepository;
            _pupilMapper = pupilMapper;
        }

        public async Task<IEnumerable<PupilResponse>> GetPupilsAsync()
        {
            var result = await _pupilRepository.GetAllAsync();
            return result.Select(x => _pupilMapper.Map(x));
        }

        public async Task<PupilResponse> GetPupilAsync(GetPupilRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Request is null");
            
            var result = await _pupilRepository.GetByIdAsync(request.Id);
            return _pupilMapper.Map(result);
        }
        
        public async Task<PupilResponse> ReadOnlyGetPupilAsync(GetPupilRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Request is null");
           
            var result = await _pupilRepository.ReadOnlyGetByIdAsync(request.Id);
            return _pupilMapper.Map(result);
        }

        public async Task<PupilResponse> AddPupilAsync(AddPupilRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Request is null");
            
            var pupil = _pupilMapper.Map(request);
            var result = _pupilRepository.Create(pupil);

            await _pupilRepository.UnitOfWork.SaveChangesAsync();
            return _pupilMapper.Map(result);
        }

        public async Task<PupilResponse> EditPupilAsync(EditPupilRequest request)
        {
            var existingRecord = _pupilRepository.ReadOnlyGetByIdAsync(request.Id);
            if (existingRecord == null)
            {
                throw new ArgumentException($"Pupil with ID {request.Id} does not exist in the database");
            }
            
            var entity = _pupilMapper.Map(request);
            var result = _pupilRepository.Update(entity);
            
            await _pupilRepository.UnitOfWork.SaveChangesAsync();
            return _pupilMapper.Map(await _pupilRepository.ReadOnlyGetByIdAsync(result.Id)); 
        }

        public async Task<PupilResponse> DeletePupilById(int pupilId)
        {
            var existingRecord = await _pupilRepository.DeleteById(pupilId);
            await _pupilRepository.UnitOfWork.SaveChangesAsync();
            return _pupilMapper.Map(existingRecord);
        }
    }
}