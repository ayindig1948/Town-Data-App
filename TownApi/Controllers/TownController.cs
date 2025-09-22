using Microsoft.AspNetCore.Mvc;
using TownDataL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TownApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownController : ControllerBase
    {
        private ITownCrud _crud;

        public TownController(ITownCrud crud)
        {
            _crud=crud;
        }
        // GET: api/<TownController>
        [HttpGet]
        public ActionResult<IEnumerable<TownDataL.Models.Town> >Get()
        {
       var rows=_crud.GetAll();
            return Ok(rows);
        }

        // GET api/<TownController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TownController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TownController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TownController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
