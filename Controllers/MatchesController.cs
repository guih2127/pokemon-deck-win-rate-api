using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IMapper _mapper;

        public MatchesController(IMatchService matchService, IMapper mapper)
        {
            _matchService = matchService;
            _mapper = mapper;
        }

        [Route("/matches")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> InsertMatchAsync(InsertMatchViewModel insertMatchViewModel)
        {
            try
            {
                var match = _mapper.Map<InsertMatchViewModel, Match>(insertMatchViewModel);
                match.UserId = Convert.ToInt32(User.Identity.Name);

                var matchInserted = await _matchService.InsertMatchAsync(match);
                var getMatchViewModel = _mapper.Map<Match, GetMatchViewModel>(matchInserted);

                return Ok(getMatchViewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("matches/{usedDeckId}")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetMatchsByUsedDeckIdAsync(int usedDeckId)
        {
            try
            {
                var userId = Convert.ToInt32(User.Identity.Name);
                var deckMatches = await _matchService.GetMatchsByUsedDeckIdAsync(usedDeckId, userId);
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