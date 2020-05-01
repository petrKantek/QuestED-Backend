using System.Collections.Generic;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL.Interfaces
{
    public interface ISchoolOwnsSeasonDal
    {
        int CreateSchoolOwnsSeason(SchoolOwnsSeason schoolOwnsSeasonEntity);
        SchoolOwnsSeason FindSchoolOwnsSeasonById(int id);
        ICollection<SchoolOwnsSeason> FindAllSchoolOwnsSeasons();
        void UpdateSchoolOwnsSeason(SchoolOwnsSeason schoolOwnsSeasonEntity);
        void DeleteSchoolOwnsSeason(SchoolOwnsSeason schoolOwnsSeasonEntity);
    }
}