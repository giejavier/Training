using System.Collections.Generic;
using NyFTraining.Controllers;

namespace NyFTraining
{
    public interface ISchoolService
    {
        List<School> GetAll();
        School GetSchool(int id);
        School AddSchool(string name);
        School EditSchool(int id, string newName);
        bool DeleteSchool(int id);
    }
}
