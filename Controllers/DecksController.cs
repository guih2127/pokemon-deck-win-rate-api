using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonDeckWinRateAPI.DTOs;
using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Controllers
{
    [ApiController]
    public class DecksController : ControllerBase
    {
        private readonly IDeckService _deckService;
        private readonly IMapper _mapper;

        public DecksController(IDeckService deckService, IMapper mapper)
        {
            _deckService = deckService;
            _mapper = mapper;
        }

        [Route("/decks")]
        [HttpGet]
        public async Task<IActionResult> GetDecksAsync()
        {
            try
            {
                var decks = await _deckService.GetDecksAsync();
                var decksViewModel = _mapper.Map<IEnumerable<Deck>, IEnumerable<GetDeckViewModel>>(decks);

                return Ok(decks);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/decks")]
        [HttpPost]
        public async Task<IActionResult> InsertDeckAsync(InsertDeckViewModel deckViewModel)
        {
            try
            {
                var deck = _mapper.Map<InsertDeckViewModel, Deck>(deckViewModel);
                var deckInserted = await _deckService.InsertDeckAsync(deck);

                return Ok(deckInserted);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}