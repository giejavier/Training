using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace NyFTraining.Controllers
{
    [Route("api/schools")]
    [ApiController]
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

        [HttpPost]
        public ActionResult Add([FromBody][Required] string name)
        {
            var school = _service.AddSchool(name);

            return Created($"api/schools/{school.Id}", null);
        }

        [HttpPut]
        public ActionResult Edit([FromBody] School sc)
        {
            var school = _service.EditSchool(sc.Id, sc.Name);

            if (school == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody][Required] int id)
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
