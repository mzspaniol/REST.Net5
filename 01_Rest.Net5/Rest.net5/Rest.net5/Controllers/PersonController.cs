using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rest.net5.Controllers.Model;
using Rest.net5.Business.Implementations;
using Rest.net5.Data.VO;

namespace Rest.net5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personVO)
        {
            _logger = logger;
            _personBusiness = personVO;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));
        }
           [HttpPut]
        public IActionResult Put([FromBody] PersonVO person)
        {
            
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));
        }
    }
}
