using System;
using Pokemon.Models;
using Pokemon.Data;
using Pokemon.Repository;
namespace Pokemon.Interfaces
{
	public interface IKategoriRepository
	{
		ICollection<Kategori> GetCategories();

		Kategori GetCategory(int id);

		ICollection<Pokemons> GetPokemonByCategory(int categoryId);

		bool CategoryExists(int id);
	}
}

