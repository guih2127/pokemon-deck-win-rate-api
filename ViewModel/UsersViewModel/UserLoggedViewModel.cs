using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.ViewModel
{
    public class UserLoggedViewModel
    {
        public string Token { get; set; }
        public GetUserViewModel User { get; set; }
    }
}
