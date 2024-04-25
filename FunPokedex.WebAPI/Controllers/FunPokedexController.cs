using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FunPokedex.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunPokedexController : ControllerBase
    {
        // GET: api/<FunPokedexController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FunPokedexController>/5
        [HttpGet("{name}")]
        public string Get(string name)
        {
            return "Fun Pokedex value";
        }

        // POST api/<FunPokedexController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FunPokedexController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FunPokedexController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
