using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rest.net5.Controllers.Model;
using Rest.net5.Business.Implementations;

namespace Rest.net5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {


        private readonly ILogger<BooksController> _logger;
        private IBooksBusiness _booksBusiness;

        public BooksController(ILogger<BooksController> logger, IBooksBusiness books)
        {
            _logger = logger;
            _booksBusiness = books;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var books = _booksBusiness.FindByID(id);
            if (books == null) return NotFound();
            return Ok(books);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _booksBusiness.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Books books)
        {

            if (books == null) return BadRequest();
            return Ok(_booksBusiness.Create(books));
        }
        [HttpPut]
        public IActionResult Put([FromBody] Books books)
        {

            if (books == null) return BadRequest();
            return Ok(_booksBusiness.Update(books));
        }


        

    }
}
