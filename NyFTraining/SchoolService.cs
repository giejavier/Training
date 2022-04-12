using System.Collections.Generic;
using NyFTraining.Controllers;

namespace NyFTraining
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository Repository;
        //TODO: validations

        public SchoolService(ISchoolRepository repository)
        {
            Repository = repository;
        }

        public List<School> GetAll()
        {
            var schools = Repository.GetSchools();
            return schools;

        }

        public School GetSchool(int id)
        {
            var school = Repository.GetSchool(id);
            return school;

        }

        public School AddSchool(string name)
        {
            return Repository.AddSchool(name);
        }

        public School EditSchool(int id, string newName)
        {
            return Repository.EditSchool(id, newName);
        }

        public bool DeleteSchool(int id)
        {
            return Repository.DeleteSchool(id);
        }
    }
}
