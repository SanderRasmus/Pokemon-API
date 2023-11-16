using System;
using Pokemon.Interfaces;
using Pokemon.Models;
using Pokemon.Data;
using AutoMapper;

namespace Pokemon.Repository
{
	public class LandRepository : ILandRepository
	{
        private readonly Datakontekst _context;
        private readonly IMapper _mapper;

		public LandRepository(Datakontekst context, IMapper mapper)
		{
            _context = context;
            _mapper = mapper;
		}

        public bool CountryExists(int id)
        {
            return _context.Land.Any(c => c.Id == id);
        }

        public ICollection<Land> GetLand()
        {
            return _context.Land.ToList();
        }

        public Land GetLand(int id)
        {
            return _context.Land.Where(c => c.Id == id).FirstOrDefault();
        }

        public Land GetLandFraEier(int eierId)
        {
            return _context.Eiere.Where(o => o.Id == eierId).Select(c => c.Land).FirstOrDefault();
        }

        public ICollection<Eier> GetEiereFraLand(int landId)
        {
            return _context.Eiere.Where(c => c.Land.Id == landId).ToList();
        }
    }
}

