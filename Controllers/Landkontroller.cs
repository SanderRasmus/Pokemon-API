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

    public class LandController : Controller
    {
        private readonly ILandRepository _landRepository;
        private readonly IMapper _mapper;

        public LandController(ILandRepository landRepository, IMapper mapper)
        {
            _landRepository = landRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Land>))]

        public IActionResult GetLand()
        {
            var land = _mapper.Map<List<LandDto>>(_landRepository.GetLand());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(land);
        }

        [HttpGet("{landId}")]
        [ProducesResponseType(200, Type = typeof(Land))]
        [ProducesResponseType(400)]

        public IActionResult GetLands(int landId)
        {
            if (!_landRepository.CountryExists(landId))
                return NotFound();

            var land = _mapper.Map<LandDto>(_landRepository.GetLand(landId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(land);
        }

        [HttpGet("/eier/{eierId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Land))]

        public IActionResult GetLandFraEier(int eierId)
        {
            var land = _mapper.Map<LandDto>(
                _landRepository.GetLandFraEier(eierId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(land);
        }

    }
}



