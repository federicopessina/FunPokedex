using System.Reflection.Metadata.Ecma335;

namespace Pokedex.Library.Models
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Habitat { get; set; }
        public bool Rare { get; set; }
    }
}
