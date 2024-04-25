namespace Pokedex.Library.Models
{
    public class PokemonBasicInfo
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Habitat { get; set; }
        public bool? IsLegendary { get; set; }

        public PokemonBasicInfo(string name, string description, string habitat, bool isLegendary)
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
        }
    }
}
