using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.Services.Interfaces;
using PokemonDeckWinRateAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Controllers
{
    [ApiController]
    public class MatchsController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IMapper _mapper;

        public MatchsController(IMatchService matchService, IMapper mapper)
        {
            _matchService = matchService;
            _mapper = mapper;
        }

        [Route("/matchs")]
        [HttpPost]
        public async Task<IActionResult> InsertMatchAsync(InsertMatchViewModel insertMatchViewModel)
        {
            try
            {
                var match = _mapper.Map<InsertMatchViewModel, Match>(insertMatchViewModel);
                var matchInserted = await _matchService.InsertMatchAsync(match);
                var getMatchViewModel = _mapper.Map<Match, GetMatchViewModel>(matchInserted);

                return Ok(getMatchViewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("matchs/{usedDeckId}")]
        [HttpGet]
        public async Task<IActionResult> GetMatchsByUsedDeckIdAsync(int usedDeckId)
        {
            try
            {
                var deckMatches = await _matchService.GetMatchsByUsedDeckIdAsync(usedDeckId);
                var deckMatchesViewModel = _mapper.Map<IEnumerable<Match>, IEnumerable<GetDeckMatchViewModel>>(deckMatches);

                return Ok(deckMatchesViewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}