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
        public Response Get()
        {
            return new BookService().get();
        }




        //GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public Response Get(int id)
        {
            return new BookService().get(id);

        }

        // POST: api/Book
        [HttpPost]
        public Response Post([FromBody] Book value)
        {
            return new BookService().post(value);
        }

        // PUT: api/Book/5
        [HttpPut]
        public Response Put([FromBody] Book value)
        {

            return new BookService().put(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            return new BookService().delete(id);
        }
    }
}
