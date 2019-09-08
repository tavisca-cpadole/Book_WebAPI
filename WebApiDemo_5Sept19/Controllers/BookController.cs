using Microsoft.AspNetCore.Mvc;
using WebApiDemo_5Sept19.Model;

namespace WebApiDemo_5Sept19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {



        // GET: api/Book
        [HttpGet]
        public ActionResult Get()
        {
            Response response = new BookService().Get();

            return StatusCode(response.StatusCode, response);

        } // GET: api/Book
          // [Route(category / {bookName})]
        //[HttpGet]
        //[Route("api/Book/Category/{Genre}")]
        //public ActionResult Get(string genre)
        //{
        //    //Response response = new BookService().Get();

        //    return StatusCode(200, genre);

        //}




        //GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Book> Get(int id)
        {
            Response response = new BookService().Get(id);
            return StatusCode(response.StatusCode, response);

        }

        // POST: api/Book
        [HttpPost]
        public ActionResult Post([FromBody] Book value)
        {

            Response response = new BookService().Post(value);
            return StatusCode(response.StatusCode, response);
        }

        // PUT: api/Book/5
        [HttpPut]
        public ActionResult Put([FromBody] Book value)
        {
            Response response = new BookService().Put(value);
            return StatusCode(response.StatusCode, response);
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
