using System;
using Pokemon.Models;
using Pokemon.Interfaces;
using Pokemon.Data;
using Pokemon.Dto;

namespace Pokemon.Repository
{
    public class EierRepository : IEierRepository
    {
        private readonly Datakontekst _context;

        public EierRepository(Datakontekst context)
        {
            _context = context;
        }

        public Eier GetEier(int eierId)
        {
            return _context.Eiere.Where(o => o.Id == eierId).FirstOrDefault();
        }

        public ICollection<Eier> GetEierFraPokemon(int pokeId)
        {
            return _context.PokemonEiere.Where(p => p.Pokemon.Id == pokeId).Select(o => o.Eier).ToList();
        }

        public ICollection<Eier> GetEiere()
        {
            return _context.Eiere.ToList();
        }

        public ICollection<Pokemons> GetPokemonFraEier(int eierId)
        {
            return _context.PokemonEiere.Where(p => p.Eier.Id == eierId).Select(p => p.Pokemon).ToList();
        }

        public bool OwnerExists(int eierId)
        {
            return _context.Eiere.Any(o => o.Id == eierId);
        }
    }
}

