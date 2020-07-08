using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests_DTOs.Class;
using quested_backend.Domain.Responses_DTOs;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IClassMapper _classMapper;

        public ClassService(IClassRepository classRepository, ITeacherRepository teacherRepository,
            IClassMapper classMapper)
        {
            _classRepository = classRepository;
            _teacherRepository = teacherRepository;
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
                throw new ArgumentNullException($"Request is null");
            
            var result = await _classRepository.GetByIdAsync(request.Id);
            return _classMapper.Map(result);
        }

        public async Task<ClassResponse> ReadOnlyGetClassAsync(GetClassRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Request is null");

            var result = await _classRepository.ReadOnlyGetByIdAsync(request.Id);
            return _classMapper.Map(result);
        }

        public async Task<ClassResponse> AddClassAsync(AddClassRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Request is null");
            
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
                throw new ArgumentException($"Class with {request.Id} is does not exist in the database");
            }
            
            var editedClass = _classMapper.Map(request);
            _classRepository.Update(editedClass);

            await _classRepository.UnitOfWork.SaveChangesAsync();
            return _classMapper.Map(await _classRepository.ReadOnlyGetByIdAsync(request.Id));
        }

        public async Task<ClassResponse> DeleteClassById(int classId)
        {
            var existingRecord = await _classRepository.DeleteById(classId);
            await _classRepository.UnitOfWork.SaveChangesAsync();
            return _classMapper.Map(existingRecord);
        }
    }
}