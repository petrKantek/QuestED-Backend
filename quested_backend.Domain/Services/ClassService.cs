using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests.Class;
using quested_backend.Domain.Responses;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Services
{
    public class ClassService : IClassService
    {
        private readonly IRepository< Class > _classRepository;
        private readonly IClassMapper _classMapper;

        public ClassService(IRepository<Class> classRepository, IClassMapper classMapper)
        {
            _classRepository = classRepository;
            _classMapper = classMapper;
        }
        
        public async Task<IEnumerable<ClassResponse>> GetClassesAsync()
        {
            var result = await _classRepository.GetAllAsync();
            return result.Select( x => _classMapper.Map(x));
        }

        public async Task<ClassResponse> GetClassAsync(GetClassRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Entity is null");
            if (request.Id <= 0) 
                throw new ArgumentException($"Entity has an invalid ID: {request.Id} ");
            
            var result = await _classRepository.GetByIdAsync(request.Id);
            return _classMapper.Map(result);
        }

        public async Task<ClassResponse> ReadOnlyGetClassAsync(GetClassRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Entity is null");
            if (request.Id <= 0) 
                throw new ArgumentException($"Entity has an invalid ID: {request.Id} ");
            
            var result = await _classRepository.ReadOnlyGetByIdAsync(request.Id);
            return _classMapper.Map(result);
        }

        public async Task<ClassResponse> AddClassAsync(AddClassRequest request)
        {
            var newClass = _classMapper.Map(request);
            var result = _classRepository.Create(newClass);

            await _classRepository.UnitOfWork.SaveChangesAsync();
            return _classMapper.Map(result);
        }

        public async Task<ClassResponse> EditClassAsync(EditClassRequest request)
        {
            var existingRecord = _classRepository.ReadOnlyGetByIdAsync(request.Id);
            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present in the database");
            }
            
            var editedClass = _classMapper.Map(request);
            var result = _classRepository.Update(editedClass);

            await _classRepository.UnitOfWork.SaveChangesAsync();
            return _classMapper.Map(result);
        }
    }
}