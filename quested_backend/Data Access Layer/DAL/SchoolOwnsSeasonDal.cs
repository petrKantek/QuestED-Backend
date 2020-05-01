using System.Collections.Generic;
using quested_backend.Data_Access_Layer.DAL.Interfaces;
using quested_backend.Entities;

namespace quested_backend.Data_Access_Layer.DAL
{
    public class SchoolOwnsSeasonDal : ISchoolOwnsSeasonDal
    {
        private QuestedContext questedContext;
        
        public int CreateSchoolOwnsSeason(SchoolOwnsSeason schoolOwnsSeasonEntity)
        {
            throw new System.NotImplementedException();
        }

        public SchoolOwnsSeason FindSchoolOwnsSeasonById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<SchoolOwnsSeason> FindAllSchoolOwnsSeasons()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateSchoolOwnsSeason(SchoolOwnsSeason schoolOwnsSeasonEntity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSchoolOwnsSeason(SchoolOwnsSeason schoolOwnsSeasonEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}