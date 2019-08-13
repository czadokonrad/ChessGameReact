using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGameReact.Models
{
    public class Bishop : ChessFigure
    {

        public Bishop()
        {
            UnicodeSymbol = "♗";
            Name = "Bishop";
            MoveRules = MovePattern.FullCross;
            StartPosition = new FigurePosition(3,1);
            CurrentPosition = StartPosition;
            IsOnStart = true;
        }

        public Bishop(byte xPosition, byte yPosition)
        {
            UnicodeSymbol = "♗";
            Name = "Bishop";
            MoveRules = MovePattern.FullCross;
            StartPosition = new FigurePosition(xPosition, yPosition);
            CurrentPosition = StartPosition;
        }

        public override MovePattern MoveRules { get; }

    }
}
