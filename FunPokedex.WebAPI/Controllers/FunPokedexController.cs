using FunPokedex.WebAPI.Enums;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Library.Models;
using Pokedex.Library.Processors;
using Pokedex.Library.Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FunPokedex.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunPokedexController : ControllerBase
    {
        /// <summary>
        /// Get the basic information of a Pokemon with translated description.
        /// </summary>
        /// <param name="name">Name of the Pokemon</param>
        /// <returns></returns>
        [HttpGet("translated/{name}")]
        public async Task<PokemonBasicInfo> GetBasicInfoTranslated(string name)
        {
            try
            {
                var pokemon = await PokemonProcessor.LoadPokemon(name);
                var species = await PokemonProcessor.LoadSpecies(pokemon.id);

                // Extracting the necessary information from the API response.
                var resultName = pokemon.name;
                var resultDescription = StringCleaner.RemoveEscapeSequences(species.flavor_text_entries[0].flavor_text);
                var resultHabitat = species.habitat.name;
                var resultIsLegendary = species.is_legendary;
                
                // Setting the translator based on the habitat and legendary status.
                string translator = ETranslator.Shakespeare.ToString();
                if (resultHabitat == EHabitat.Cave.ToString() || resultIsLegendary is true)
                    translator = ETranslator.Yoda.ToString();
                
                var translatedDescription = await TranslatorProcessor.LoadTranslation(resultDescription, translator);

                return new PokemonBasicInfo(pokemon.name, translatedDescription.contents.translated, resultHabitat, resultIsLegendary);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
