using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessGameReact.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ChessGameReact.Controllers
{
    [Route("api/chess/availablefigures")]
    public class ChessFiguresController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(Figures.All);
        }
    }
}