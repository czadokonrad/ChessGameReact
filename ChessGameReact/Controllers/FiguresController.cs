using ChessGameReact.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ChessGameReact.Controllers
{
    [Route("api/figures")]
    public class FiguresController : ControllerBase
    {
        [HttpGet("availablemoves")]
        public IActionResult GetAvailableMoves([FromQuery] string figureName, byte xPosition, byte yPosition)
        {
            List<Type> chessFigureTypes  = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(ChessFigure))
                .ToList();

            Type requestedType = chessFigureTypes.Single(t => t.Name.Equals(figureName, StringComparison.OrdinalIgnoreCase));

            ChessFigure chessFigure = (ChessFigure)Activator.CreateInstance(requestedType, new object[] { xPosition, yPosition }, null);

            return Ok(chessFigure.GetAvailableMoves());
        }


        [HttpGet("canmoveto")]
        public IActionResult CanMoveTo([FromQuery]string figureName, 
                                       [FromQuery]byte fromX, 
                                       [FromQuery]byte toX, 
                                       [FromQuery]byte fromY, 
                                       [FromQuery]byte toY)
        {
            List<Type> chessFigureTypes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(ChessFigure))
               .ToList();

            Type requestedType = chessFigureTypes.Single(t => t.Name.Equals(figureName, StringComparison.OrdinalIgnoreCase));

            ChessFigure chessFigure = (ChessFigure)Activator.CreateInstance(requestedType, new object[] { fromX, fromY}, null);

            bool canMoveTo = chessFigure.CanMoveTo(toX, toY);

            return Ok(canMoveTo);
        }
    }
}
