using System;
using AutoMapper;
using Pokemon.Dto;
using Pokemon.Models;
namespace Pokemon.Helper
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Pokemons, PokemonDto>();
			CreateMap<Kategori, KategoriDto>();
			CreateMap<KategoriDto, Kategori>();
			CreateMap<Land, LandDto>();
			CreateMap<LandDto, Land>();
			CreateMap<Eier, EierDto>();
		}
	}
}

