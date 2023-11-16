using System;
using Pokemon.Interfaces;
using Pokemon.Models;
using Pokemon.Data;

namespace Pokemon.Repository
{
    public class KategoriRepository : IKategoriRepository
    {
        private Datakontekst _context;

        public KategoriRepository(Datakontekst context)
        {
            _context = context;
        }

        public bool CategoryExists(int id)
        {
            return _context.Kategorier.Any(c => c.Id == id);
        }

        public ICollection<Kategori> GetCategories()
        {
            return _context.Kategorier.ToList();
        }

        public Kategori GetCategory(int id)
        {
            return _context.Kategorier.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemons> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonKategorier.Where(e => e.KategoriId == categoryId).Select(c => c.Pokemon).ToList();
        }
    }
}

