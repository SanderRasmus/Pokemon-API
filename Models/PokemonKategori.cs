using System;
namespace Pokemon.Models
{
	public class PokemonKategori
	{
		public int PokemonId { get; set; }

		public int KategoriId { get; set; }

		public Pokemons Pokemon { get; set; }

		public Kategori Kategori { get; set; }
	}
}

