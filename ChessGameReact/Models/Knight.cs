using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGameReact.Models
{
    public class Knight : ChessFigure
    {
        public Knight()
        {
            UnicodeSymbol = "♘";
            Name = "Knight";
            MoveRules = MovePattern.LPattern;
            StartPosition = new FigurePosition(2, 1);
            CurrentPosition = StartPosition;
            IsOnStart = true;
        }

        public Knight(byte xPosition, byte yPosition)
        {
            UnicodeSymbol = "♘";
            Name = "Knight";
            MoveRules = MovePattern.LPattern;
            StartPosition = new FigurePosition(xPosition, yPosition);
            CurrentPosition = StartPosition;
        }

        public override MovePattern MoveRules { get; }

    }
}
