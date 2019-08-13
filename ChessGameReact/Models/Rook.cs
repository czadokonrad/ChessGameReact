using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGameReact.Models
{
    public sealed class Rook : ChessFigure
    {
        public Rook()
        {
            UnicodeSymbol = "♖";
            Name = "Rook";
            StartPosition = new FigurePosition(1, 1);
            CurrentPosition = StartPosition;
            MoveRules = MovePattern.Horizontal | MovePattern.Vertical;
            IsOnStart = true;

        }

        public Rook(byte xPosition, byte yPosition)
        {
            UnicodeSymbol = "♖";
            Name = "Rook";
            StartPosition = new FigurePosition(xPosition, yPosition);
            CurrentPosition = StartPosition;
            MoveRules = MovePattern.Horizontal | MovePattern.Vertical;
        }

        public override MovePattern MoveRules { get; }

    }
}
