using System.Collections.Generic;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests.Pupil;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Mappers
{
    public class PupilMapper : IPupilMapper
    {
        public Pupil Map(AddPupilRequest request)
        {
            if (request == null) return null;

            var pupil = new Pupil
            {
                Firstname = request.Firstname,
            };

            return pupil;
        }

        public Pupil Map(EditPupilRequest request)
        {
            if (request == null) return null;

            var pupil = new Pupil
            {
                Id = request.Id,
                Firstname = request.Firstname
            };

            return pupil;
        }

        public PupilResponse Map(Pupil pupil)
        {
            if (pupil == null) return null;

            var pupilResponse = new PupilResponse
            {
                Id = pupil.Id,
                Firstname = pupil.Firstname
            };

            return pupilResponse;
        }
    }
}