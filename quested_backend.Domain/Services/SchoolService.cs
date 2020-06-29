using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests.School;
using quested_backend.Domain.Responses;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly IRepository<School> _schoolRepository;
        private readonly ISchoolMapper _schoolMapper;

        public SchoolService(IRepository<School> schoolRepository, ISchoolMapper schoolMapper)
        {
            _schoolRepository = schoolRepository;
            _schoolMapper = schoolMapper;
        }
        
        public async Task<IEnumerable<SchoolResponse>> GetSchoolsAsync()
        {
            var result = await _schoolRepository.GetAllAsync();
            return result.Select(school => _schoolMapper.Map(school));
        }

        public async Task<SchoolResponse> GetSchoolAsync(GetSchoolRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Entity is null");
            if (request.Id <= 0) 
                throw new ArgumentException($"Entity has an invalid ID: {request.Id} ");
            var result = await _schoolRepository.GetByIdAsync(request.Id);
            return _schoolMapper.Map(result);
        }

        public async Task<SchoolResponse> ReadOnlyGetSchoolAsync(GetSchoolRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Entity is null");
            if (request.Id <= 0) 
                throw new ArgumentException($"Entity has an invalid ID: {request.Id} ");
            var result = await _schoolRepository.ReadOnlyGetByIdAsync(request.Id);
            return _schoolMapper.Map(result);
        }

        public async Task<SchoolResponse> AddSchoolAsync(AddSchoolRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Request is null");
            var pupil = _schoolMapper.Map(request);
            var result = _schoolRepository.Create(pupil);

            await _schoolRepository.UnitOfWork.SaveChangesAsync();
            return _schoolMapper.Map(result);
        }

        public async Task<SchoolResponse> EditSchoolAsync(EditSchoolRequest request)
        {
            var existingRecord = _schoolRepository.ReadOnlyGetByIdAsync(request.Id);
            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }
            
            var entity = _schoolMapper.Map(request);
            var result = _schoolRepository.Update(entity);
            
            await _schoolRepository.UnitOfWork.SaveChangesAsync();
            return _schoolMapper.Map(result); 
        }
    }
}