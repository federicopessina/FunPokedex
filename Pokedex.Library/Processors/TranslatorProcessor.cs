using Translation = Pokedex.Library.Models.Translation.Rootobject;

namespace Pokedex.Library.Processors
{
    public class TranslatorProcessor
    {
        public static async Task<Translation> LoadTranslation(string text, string translation)
        {
            const string _baseUrl = "https://api.funtranslations.com/translate";
            string url = $"{_baseUrl}/{translation}.json?text={text}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Translation result = await response.Content.ReadAsAsync<Translation>();

                    return await Task.FromResult(result);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }   
    }
}
