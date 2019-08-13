using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGameReact.Models
{
    public class King : ChessFigure
    {
        public King()
        {
            UnicodeSymbol = "♔";
            Name = "King";
            MoveRules = MovePattern.OneMoveEveryDirection;
            StartPosition = new FigurePosition(4, 1);
            CurrentPosition = StartPosition;
            IsOnStart = true;
        }

        public King(byte xPosition, byte yPosition)
        {
            UnicodeSymbol = "♔";
            Name = "King";
            MoveRules = MovePattern.OneMoveEveryDirection;
            StartPosition = new FigurePosition(xPosition, yPosition);
            CurrentPosition = StartPosition;
        }

        public override MovePattern MoveRules { get; }
    }
}
