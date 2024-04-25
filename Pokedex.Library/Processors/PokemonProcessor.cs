using Pokedex.Library.Models;

namespace Pokedex.Library.Processors
{
    public class PokemonProcessor
    {
        private readonly string _baseUrl = "https://pokeapi.co/api/v2/pokemon/";
        public async Task<Pokemon> LoadPokemon(string name)
        {
            string url = $"{_baseUrl}/{name}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Pokemon pokemon = await response.Content.ReadAsAsync<Pokemon>();

                    return await Task.FromResult(pokemon);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
