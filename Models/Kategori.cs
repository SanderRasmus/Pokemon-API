using System;
namespace Pokemon.Models
{
	public class Kategori
	{
		public int Id { get; set; }

		public string Navn { get; set; }

		public ICollection<PokemonKategori> PokemonKategori { get; set; }
	}
}

