using System;
using Pokemon.Models;
using Pokemon.Data;
using Pokemon.Repository;
namespace Pokemon.Interfaces
{
	public interface IEierRepository
	{
		ICollection<Eier> GetEiere();

		Eier GetEier(int eierId);

		ICollection<Eier> GetEierFraPokemon(int pokeId);

		ICollection<Pokemons> GetPokemonFraEier(int eierId);

		bool OwnerExists(int eierId);
	}
}

