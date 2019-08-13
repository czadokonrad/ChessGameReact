using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGameReact.Models
{
    public class Queen : ChessFigure
    {
        public Queen()
        {
            UnicodeSymbol = "♕";
            Name = "Queen";
            MoveRules = MovePattern.OneMoveEveryDirection | MovePattern.FullCross | MovePattern.Horizontal | MovePattern.Vertical;
            StartPosition = new FigurePosition(4, 1);
            CurrentPosition = StartPosition;
            IsOnStart = true;
        }

        public Queen(byte xPosition, byte yPosition)
        {
            UnicodeSymbol = "♕";
            Name = "Queen";
            MoveRules = MovePattern.OneMoveEveryDirection | MovePattern.FullCross | MovePattern.Horizontal | MovePattern.Vertical;
            StartPosition = new FigurePosition(xPosition, yPosition);
            CurrentPosition = StartPosition;
        }

        public override MovePattern MoveRules { get; }

    }
}
