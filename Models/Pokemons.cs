using System;
namespace Pokemon.Models
{
	public class Pokemons
	{
		public int Id { get; set; }

		public string Navn { get; set; }

		public DateTime Bursdag { get; set; }

		public ICollection<PokemonEier> PokemonEiere { get; set; }

		public ICollection<PokemonKategori> PokemonKategori { get; set; }
	}
}

