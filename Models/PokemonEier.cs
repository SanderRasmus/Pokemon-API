using System;
namespace Pokemon.Models
{
	public class PokemonEier
	{
		public int PokemonId { get; set; }

		public int EierId { get; set; }

		public Pokemons Pokemon { get; set; }

		public Eier Eier { get; set; }
	}
}

