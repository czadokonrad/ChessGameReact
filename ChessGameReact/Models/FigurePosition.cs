using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGameReact.Models
{
    public struct FigurePosition
    {
        public byte XPosition { get; private set; }
        public byte YPosition { get; private set; }
        public FigurePosition(byte xPosition, byte yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }
    }
}
