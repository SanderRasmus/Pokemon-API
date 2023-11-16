using System;
namespace Pokemon.Models
{
	public class Eier
	{
		public int Id { get; set; }

		public string Fornavn { get; set; }

		public string Etternavn { get; set; }

		public Land Land { get; set; }

		public ICollection<PokemonEier> PokemonEier { get; set; }
	
	}
}

