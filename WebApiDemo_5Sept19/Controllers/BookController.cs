using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiDemo_5Sept19.Model;

namespace WebApiDemo_5Sept19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IValidator<Book> _bookValidator;

        public BookController(IValidator<Book> bookValidator)
        {
            _bookValidator = bookValidator;
        }

        // GET: api/Book
        [HttpGet]
        public ActionResult Get()
        {
            Response response = new BookService().Get();
            //JsonFileLogger.WriteLog(new Log(response.StatusCode.ToString(), response));
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
        public ActionResult Post([FromBody] Book value)
        {

            //Response response = new BookService().Post(value);
            //return StatusCode(response.StatusCode, response);
            var validationResult = _bookValidator.Validate(value);
            List<string> response_message = new List<string>();

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                    response_message.Add(error.ToString());
                return StatusCode(400, response_message);
            }
            else
            {
                Response response = new BookService().Post(value);
                return StatusCode(response.StatusCode, response);
            }
        }

        // PUT: api/Book/5
        [HttpPut]
        public ActionResult Put([FromBody] Book value)
        {
            //Response response = new BookService().Put(value);
            //return StatusCode(response.StatusCode, response);

            var validationResult = _bookValidator.Validate(value);
            List<string> response_message = new List<string>();

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                    response_message.Add(error.ToString());
                return StatusCode(400, response_message);
            }
            else
            {
                Response response = new BookService().Put(value);
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
