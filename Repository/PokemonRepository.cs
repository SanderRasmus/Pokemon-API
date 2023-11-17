using System;
using Pokemon.Data;
using Pokemon.Models;
using Pokemon.Interfaces;
namespace Pokemon.Repository
{
	public class PokemonRepository : IPokemonRepository
	{
		private readonly Datakontekst _context;

		public PokemonRepository(Datakontekst context)
		{
			_context = context;
		}

        public Pokemons GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemons GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Navn == name).FirstOrDefault();
        }

        public ICollection<Pokemons> GetPokemons()
		{
			return _context.Pokemon.OrderBy(p => p.Id).ToList();

        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemon.Any(p => p.Id == pokeId);
        }

        public bool CreatePokemon(Pokemons pokemon)
        {
            _context.Add(pokemon);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

