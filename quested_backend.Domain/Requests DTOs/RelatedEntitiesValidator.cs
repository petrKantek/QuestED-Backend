using System.Threading;
using System.Threading.Tasks;
using quested_backend.Domain.Requests_DTOs.Pupil;
using quested_backend.Domain.Requests_DTOs.School;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Requests_DTOs
{
    public class RelatedEntitiesValidator : IRelatedEntitiesValidator
    {
        private readonly ITeacherService _teacherService;
        private readonly IPupilService _pupilService;
        private readonly ISchoolService _schoolService;

        public RelatedEntitiesValidator(ITeacherService teacherService, IPupilService pupilService,
            ISchoolService schoolService)
        {
            _teacherService = teacherService;
            _pupilService = pupilService;
            _schoolService = schoolService;
        }
        
        public async Task<bool> TeacherExists(int teacherId, CancellationToken cancellationToken)
        {
            var teacher = await _teacherService.GetTeacherAsync(new GetTeacherRequest
            {
                Id = teacherId
            });

            return teacher != null;
        } 
        
        public async Task<bool> PupilExists(int pupilId, CancellationToken cancellationToken)
        {
            var pupil = await _pupilService.GetPupilAsync(new GetPupilRequest
            {
                Id = pupilId
            });

            return pupil != null;
        }
        
        public async Task<bool> SchoolExists(int schoolId, CancellationToken cancellationToken)
        {
            var school = await _schoolService.GetSchoolAsync(new GetSchoolRequest
            {
                Id = schoolId
            });

            return school != null;
        }
    }
}