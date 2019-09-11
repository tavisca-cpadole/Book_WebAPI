using Microsoft.AspNetCore.Mvc;
using WebApiDemo_5Sept19.Model;

namespace WebApiDemo_5Sept19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [Route("category/{name}")]
        [HttpGet]
        public ActionResult GetWithCategory(string name)
        {
            Response response = new BookService().GetWithCategory(name);
            return StatusCode(200, response);
        }

        // GET: api/Book
        [HttpGet]
        public ActionResult Get()
        {
            Response response = new BookService().Get();
            return StatusCode(response.StatusCode, response);

        }

        //GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Book> Get(int id)
        {
            Response response = new BookService().Get(id);
            return StatusCode(response.StatusCode, response);

        }

        // POST: api/Book
        [HttpPost]
        [BookModelFilter]
        public ActionResult Post([FromBody] Book value)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.BAD_REQUEST, ModelState);
            }
            else
            {
                Response response = new BookService().Post(value);
                return StatusCode(response.StatusCode, response);
            }
        }

        // PUT: api/Book/5
        [HttpPut]
        [BookModelFilter]
        public ActionResult Put([FromBody] Book value)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.BAD_REQUEST, ModelState);
            }
            else
            {
                Response response = new BookService().Post(value);
                return StatusCode(response.StatusCode, response);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Response response = new BookService().Delete(id);
            return StatusCode(response.StatusCode, response);
        }


    }
}
