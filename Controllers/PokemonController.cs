using System;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Interfaces;
using Pokemon.Models;
using AutoMapper;
using Pokemon.Dto;
using Pokemon.Repository;

namespace Pokemon.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class PokemonController : Controller
	{
		private readonly IPokemonRepository _pokemonRepository;
		private readonly IMapper _mapper;

		public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
		{
			_pokemonRepository = pokemonRepository;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Pokemons>))]

		public IActionResult GetPokemons()
		{
			var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(pokemons);
		}

		[HttpGet("{pokeId}")]
		[ProducesResponseType(200, Type = typeof(Pokemons))]
		[ProducesResponseType(400)]

		public IActionResult GetPokemon(int pokeId)
		{
			if (!_pokemonRepository.PokemonExists(pokeId))
				return NotFound();

			var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(pokemon);
		}

		[HttpPost]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		public IActionResult CreateCountry([FromBody] PokemonDto pokemonOpprett)
		{
			if (pokemonOpprett == null)
				return BadRequest(ModelState);

			var pokemon = _pokemonRepository.GetPokemons()
				.Where(c => c.Navn.Trim().ToUpper() == pokemonOpprett.Navn.TrimEnd().ToUpper())
				.FirstOrDefault();

			if (pokemon != null)
			{
				ModelState.AddModelError("", "Pokemonen finnes allerede!");
				return StatusCode(422, ModelState);

			}

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var pokemonMap = _mapper.Map<Pokemons>(pokemonOpprett);

			if (!_pokemonRepository.CreatePokemon(pokemonMap))
			{
				ModelState.AddModelError("", "Noe gikk galt under lagring");
				return StatusCode(500, ModelState);
			}

			return Ok("Pokemonen ble opprettet");
		}
	}
}
