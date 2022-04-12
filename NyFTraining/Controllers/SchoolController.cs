using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NyFTraining.Controllers
{
    [Route("api/schools")]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _service;

        public SchoolController(ISchoolService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<School> schools = _service.GetAll();

            return Ok(schools);
        }

        [HttpGet("{id}")]
        public ActionResult GetSchool(int id)
        {
            var school = _service.GetSchool(id);

            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        [HttpPost]//request body
        public ActionResult Add(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return BadRequest("Name is null or empty.");
            }

            var school = _service.AddSchool(name);

            return Created($"api/schools/{school.Id}", school); // find way that does not return object
        }

        [HttpPut]//id -> route data, newName -> request body; find automatic way to validate (attribute validation)
        public ActionResult Edit(int id, string newName)
        {
            if (string.IsNullOrEmpty(newName))
            {
                return BadRequest("Name is null or empty.");
            }

            var school = _service.EditSchool(id, newName);

            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        [HttpDelete]//id -> route data
        public ActionResult Delete(int id)
        {
            var isDeleted = _service.DeleteSchool(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
