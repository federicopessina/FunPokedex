using System.Net.WebSockets;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Library.Enums;
using Pokedex.Library.Models;
using Pokedex.Library.Processors;

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
        public async Task<PokemonBasicInfo> GetBasicInfo(string name)
        {
            try
            {
                var pokemon = await PokemonProcessor.LoadPokemon(name); // NOTE We need the pokemon ID to get the species.
                var species = await PokemonProcessor.LoadSpecies(pokemon.id);
                
                var resultName = pokemon.name;
                var resultDescription = species.flavor_text_entries[0].flavor_text
                    .Replace("\n", " ")     // NOTE We need to replace the newline character with a space.
                    .Replace("\f", "");     // NOTE We need to replace the \f escape character with an empty character. 
                var resultHabitat = species.habitat.name;
                var resultIsLegendary = species.is_legendary;

                return new PokemonBasicInfo(name, resultDescription, resultHabitat, resultIsLegendary);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{name}/{translator}")]
        public async Task<PokemonBasicInfo> GetBasicInfoTranslated(string name, string translator)
        {
            try
            {
                var pockemon = await PokemonProcessor.LoadPokemon(name);
                var species = await PokemonProcessor.LoadSpecies(pockemon.id);

                var resultName = pockemon.name;
                var resultDescription = species.flavor_text_entries[0].flavor_text
                    .Replace("\n", " ")
                    .Replace("\f", "");
                var resultHabitat = species.habitat.name;
                var resultIsLegendary = species.is_legendary;

                var translatedDescription = await TranslatorProcessor.LoadTranslation(resultDescription, translator);

                return new PokemonBasicInfo(name, translatedDescription.contents.translated, resultHabitat, resultIsLegendary);
            }
            catch (Exception)
            {

                throw;
            }
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
