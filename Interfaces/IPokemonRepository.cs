using Pokemon.Models;
namespace Pokemon.Interfaces
{
    public interface IPokemonRepository
	{
		ICollection<Pokemons> GetPokemons();

		Pokemons GetPokemon(int id);

		Pokemons GetPokemon(string name);

		bool PokemonExists(int pokeId);

        bool CreatePokemon(Pokemons pokemon);

        bool Save();
    }
}

