using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGameReact.Models
{
    public class Pawn : ChessFigure
    {
        public Pawn()
        {
            UnicodeSymbol = "♙";
            Name = "Pawn";
            MoveRules = MovePattern.OneForward | MovePattern.TwoForwardOnStart;
            StartPosition = new FigurePosition(1, 2);
            CurrentPosition = StartPosition;
            IsOnStart = true;
        }

        public Pawn(byte xPosition, byte yPosition)
        {
            UnicodeSymbol = "♙";
            Name = "Pawn";
            MoveRules = MovePattern.OneForward | MovePattern.TwoForwardOnStart;
            StartPosition = new FigurePosition(xPosition, yPosition);
            CurrentPosition = StartPosition;
            IsOnStart = CurrentPosition.YPosition == (byte)2;
        }


        public override MovePattern MoveRules { get; }
    }

}
