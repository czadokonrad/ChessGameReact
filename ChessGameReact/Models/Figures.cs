using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGameReact.Models
{
    public static class Figures
    {
        public static List<ChessFigure> All
            = new List<ChessFigure>
            {
               new Bishop(),
               new King(),
               new Knight(),
               new Pawn(),
               new Queen(),
               new Rook()
            };
    }
}
