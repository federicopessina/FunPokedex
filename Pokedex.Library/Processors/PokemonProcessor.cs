using PokemonModel = Pokedex.Library.Models.Pokemon.Rootobject;
using SpeciesModel = Pokedex.Library.Models.Species.Rootobject;

namespace Pokedex.Library.Processors
{
    public static class PokemonProcessor
    {
        public static async Task<PokemonModel> LoadPokemon(string name)
        {
            const string baseUrl = "https://pokeapi.co/api/v2/pokemon/";
            string url = $"{baseUrl}/{name}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    PokemonModel pokemon = await response.Content.ReadAsAsync<PokemonModel>();

                    return await Task.FromResult(pokemon);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<SpeciesModel> LoadSpecies(int id)
        {
            const string baseUrl = "https://pokeapi.co/api/v2/pokemon-species/";
            string url = $"{baseUrl}/{id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    SpeciesModel species = await response.Content.ReadAsAsync<SpeciesModel>();

                    return await Task.FromResult(species);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }   
    }
}
