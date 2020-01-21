using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Minesweeper.Shared.Models;

namespace Minesweeper.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {

        private readonly ILogger<GamesController> _logger;


        public GamesController(ILogger<GamesController> logger)
        {
            _logger = logger;
        }
    }
}
