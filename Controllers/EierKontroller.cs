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

    public class EierKontroller : Controller
    {
        private readonly IEierRepository _eierRepository;
        private readonly IMapper _mapper;

        public EierKontroller(IEierRepository eierRepository, IMapper mapper)
        {
            _eierRepository = eierRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Eier>))]

        public IActionResult GetEiere()
        {
            var eiere = _mapper.Map<List<EierDto>>(_eierRepository.GetEiere());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(eiere);
        }

        [HttpGet("{eierId}")]
        [ProducesResponseType(200, Type = typeof(Eier))]
        [ProducesResponseType(400)]

        public IActionResult GetEier(int eierId)
        {
            if (!_eierRepository.OwnerExists(eierId))
                return NotFound();

            var eier = _mapper.Map<EierDto>(_eierRepository.GetEier(eierId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(eier);
        }

        [HttpGet("{eierId}/pokemon")]
        [ProducesResponseType(200, Type = typeof(Eier))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonAvEier(int eierId)
        {
            if (!_eierRepository.OwnerExists(eierId))
            {
                return NotFound();
            }

            var eier = _mapper.Map<List<PokemonDto>>(
                _eierRepository.GetPokemonFraEier(eierId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(eier);
        }
    }
}
