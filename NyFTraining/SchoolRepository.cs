using System.Collections.Generic;
using NyFTraining.Controllers;
using System.Linq;

namespace NyFTraining
{
    public class SchoolRepository : ISchoolRepository
    {
        private static List<School> Schools = new List<School>();
        private static int LatestId = 1;

        public List<School> GetSchools()
        {
            return Schools;
        }

        public School GetSchool(int id)
        {
            var school = Schools.Where(x => x.Id == id).FirstOrDefault();
            return school;
        }

        public School AddSchool(string name)
        {
            var school = new School() { Id = LatestId, Name = name };
            Schools.Add(school);
            LatestId++;

            return school;
        }

        public School EditSchool(int id, string newName)
        {
            var school = Schools.Where(x => x.Id == id).FirstOrDefault();

            if (school == null)
            {
                return null;
            }

            school.Name = newName;
            return school;
        }

        public bool DeleteSchool(int id)
        {
            var isDeleted = false;
            var school = Schools.Where(x => x.Id == id).FirstOrDefault();

            if (school == null)
            {
                return isDeleted;
            }

            return Schools.Remove(school);
        }
    }
}
