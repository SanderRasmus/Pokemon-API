using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Dto;
using Pokemon.Interfaces;
using Pokemon.Models;
using Pokemon.Repository;

namespace Pokemon.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class KategoriKontroller : Controller
	{
		private readonly IKategoriRepository _kategoriRepository;
		private readonly IMapper _mapper;

		public KategoriKontroller(IKategoriRepository kategoriRepository, IMapper mapper)
		{
			_kategoriRepository = kategoriRepository;
			_mapper = mapper;
		}

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Kategori>))]

        public IActionResult GetCategories()
        {
            var kategorier = _mapper.Map<List<KategoriDto>>(_kategoriRepository.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(kategorier);
        }


        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Kategori))]
        [ProducesResponseType(400)]
        public IActionResult GetKategori(int categoryId)
        {
            if (!_kategoriRepository.CategoryExists(categoryId))
                return NotFound();

            var kategori = _mapper.Map<KategoriDto>(_kategoriRepository.GetCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(kategori);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemons>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategory(int categoryId)
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(
                _kategoriRepository.GetPokemonByCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(pokemons);

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] KategoriDto kategoriOpprett)
        {
            if (kategoriOpprett == null)
                return BadRequest(ModelState);

            var kategori = _kategoriRepository.GetCategories()
                .Where(c => c.Navn.Trim().ToUpper() == kategoriOpprett.Navn.TrimEnd().ToUpper())
                .FirstOrDefault();

            if(kategori != null)
            {
                ModelState.AddModelError("", "Kategorien finnes allerede");
                return StatusCode(422, ModelState);

            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var kategoriMap = _mapper.Map<Kategori>(kategoriOpprett);

            if(!_kategoriRepository.CreateCategory(kategoriMap))
            {
                ModelState.AddModelError("", "Noe gikk galt under lagring");
                return StatusCode(500, ModelState);
            }

            return Ok("Kategorien ble opprettet");
        }
    
    }
}

