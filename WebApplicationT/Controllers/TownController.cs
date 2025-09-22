using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TownDataL;
using TownDataL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownController : ControllerBase
    {
        private readonly ITownCrud _crud;
        private readonly ILogger<TownController> _logger;

        public TownController(ITownCrud crud ,ILogger<TownController> logger) {
        
            _crud=crud;
            _logger=logger;
        }
        // GET: api/<TownController>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult< IEnumerable<Town>> Get()
        {
            try
            {
                var rows = _crud.GetAll();
                _logger.LogInformation("The Town was returnd");
                return Ok(rows);
            }
            catch (Exception ex) {
                _logger.LogCritical(ex,"The mesege was not Aproovd");
                return BadRequest(ex);
            }
        }

        // GET api/<TownController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Town>> Get(int id
            )
        {
            var rows = _crud.GeByIdt(id);
            return Ok(rows);
        }
        // POST api/<TownController>
        //[Authorize("Must be admin")]
        [AllowAnonymous]    
        [HttpPost]
        public void Post([FromBody] Town town)
        {
            _crud.creteTown(town);

        }

        // PUT api/<TownController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] int temp)
        {
            _crud.UpdatT(id, temp);
        }

        // DELETE api/<TownController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
