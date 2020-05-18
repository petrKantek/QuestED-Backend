using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests.Pupil;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Services
{
    public class PupilService : IPupilService
    {
        private readonly IRepository<Pupil, int> _pupilRepository;
        private readonly IPupilMapper _pupilMapper;
        
        public PupilService(IRepository<Pupil, int>  pupilRepository, IPupilMapper pupilMapper)
        {
            _pupilRepository = pupilRepository;
            _pupilMapper = pupilMapper;
        }

        public async Task<IEnumerable<PupilResponse>> GetItemsAsync()
        {
            var result = await _pupilRepository.GetAllAsync();

            return result.Select(x => _pupilMapper.Map(x));
        }

        public async Task<PupilResponse> GetItemAsync(GetPupilRequest request)
        {
            if (request == null) throw new ArgumentNullException($"Entity is null");
            if (request.Id <= 0) throw new ArgumentException($"Entity has an invalid ID: {request.Id} ");
            var result = await _pupilRepository.GetByIdAsync(request.Id);
            return _pupilMapper.Map(result);
        }

        public async Task<PupilResponse> AddItemAsync(AddPupilRequest request)
        {
            var pupil = _pupilMapper.Map(request);
            var result = _pupilRepository.Create(pupil);

            await _pupilRepository.UnitOfWork.SaveChangesAsync();
            return _pupilMapper.Map(result);
        }

        public async Task<PupilResponse> EditItemAsync(EditPupilRequest request)
        {
            var existingRecord = _pupilRepository.GetByIdAsync(request.Id);
            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }
            
            var entity = _pupilMapper.Map(request);
            var result = _pupilRepository.Update(entity);
            
            await _pupilRepository.UnitOfWork.SaveChangesAsync();
            return _pupilMapper.Map(result); 
        }
    }
}