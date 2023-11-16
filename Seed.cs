using System;
using Pokemon.Data;
using Pokemon.Models;

namespace Pokemon
{
	public class Seed
	{
		private readonly Datakontekst dataKontekst;
		public Seed(Datakontekst kontekst)
		{
			this.dataKontekst = kontekst;
		}
		public void SeedDataKontekst()
		{
			if (!dataKontekst.PokemonEiere.Any())
			{
				var pokemonEiere = new List<PokemonEier>()
				{
					new PokemonEier()
					{
						Pokemon = new Pokemons()
						{
							Navn = "Pikachu",
							Bursdag = new DateTime(1903,1,1),
							PokemonKategori = new List<PokemonKategori>()
							{
								new PokemonKategori { Kategori = new Kategori() { Navn = "Elektrisk"}}
							}
						},
						Eier = new Eier()
						{
							Fornavn = "Sander",
							Etternavn = "Rasmussen",
							Land = new Land()
							{
								Navn = "Norge"
							}
						}
					},
					new PokemonEier()
					{
						Pokemon = new Pokemons()
						{
							Navn = "Squirtle",
							Bursdag = new DateTime(1903,1,1),
							PokemonKategori = new List<PokemonKategori>()
							{
								new PokemonKategori { Kategori = new Kategori() { Navn = "Vann"}}
							}
						},
						Eier = new Eier()
						{
							Fornavn = "Viktor",
							Etternavn = "Wold",
							Land = new Land()
							{
								Navn = "Sverige"
							}
						}
					},

				};
				dataKontekst.PokemonEiere.AddRange(pokemonEiere);
				dataKontekst.SaveChanges();
			}
		}
	}
}

