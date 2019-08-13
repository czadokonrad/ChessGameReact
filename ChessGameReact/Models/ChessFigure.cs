using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGameReact.Models
{
    public abstract class ChessFigure
    {
        private const byte MAX_X = 8;
        private const byte MAX_Y = 8;

        private List<FigurePosition> _chessMapCoordinates;

        public enum MovePattern : byte
        {
            OneMoveEveryDirection = 1,
            FullCross = 2,
            LPattern = 7,
            Vertical = 17,
            Horizontal = 37,
            OneForward = 45,
            TwoForwardOnStart = 59
        }


        public ChessFigure()
        {
            _chessMapCoordinates = new List<FigurePosition>(64);

            for (byte x = 1; x <= MAX_X; x++)
            {
                for (byte y = 1; y <= MAX_Y; y++)
                {
                    _chessMapCoordinates.Add(new FigurePosition(x,y));
                }
            }
        }

        public FigurePosition StartPosition { get; protected set; }
        public FigurePosition CurrentPosition { get; protected set; }
        public bool IsOnStart { get; protected set; }
        public string Name { get; protected set; }
        public string UnicodeSymbol { get; protected set; }
        public abstract MovePattern MoveRules { get; }

        public virtual void SetPosition(byte xPosition, byte yPosition)
        {
            if (CanMoveTo(xPosition, yPosition))
            {
                CurrentPosition = new FigurePosition(xPosition, yPosition);
                IsOnStart = false;
            }
            else
                throw new InvalidOperationException($"{GetType().Name} cannot perform move to coordinates X: {xPosition}, Y: {yPosition} from " +
                    $"X: {CurrentPosition.XPosition}, Y: {CurrentPosition.YPosition}");
        }

        public virtual bool CanMoveTo(byte xPosition, byte yPosition)
        {
            if (xPosition > MAX_X || yPosition > MAX_Y) return false;

            switch (MoveRules)
            {

                case MovePattern.OneMoveEveryDirection:
                    return FitsInOneEveryDirection(xPosition, yPosition);
                case MovePattern.OneForward | MovePattern.TwoForwardOnStart:
                    return FitsOneForwardTwoForwardOnStart(xPosition, yPosition);
                case MovePattern.Horizontal | MovePattern.Vertical:
                    return FitsInHorizontalVertical(xPosition, yPosition);
                case MovePattern.FullCross:
                    return FitsInFullCross(xPosition, yPosition);
                case MovePattern.OneMoveEveryDirection | MovePattern.FullCross | MovePattern.Horizontal | MovePattern.Vertical:
                    return (FitsInFullCross(xPosition, yPosition) || FitsInHorizontalVertical(xPosition, yPosition) || FitsInOneEveryDirection(xPosition, yPosition));
                case MovePattern.LPattern:
                    return FitsInLPattern(xPosition, yPosition);
  
                default:
                    throw new NotSupportedException(MoveRules.ToString());
            }
        }

        private bool FitsOneForwardTwoForwardOnStart(byte xPosition, byte yPosition)
        {
            if (yPosition != CurrentPosition.YPosition && yPosition > CurrentPosition.YPosition && yPosition <= MAX_Y &&
                ((IsOnStart && yPosition > CurrentPosition.YPosition && (yPosition - CurrentPosition.YPosition) <= 2 && (xPosition == CurrentPosition.XPosition))
                || (!IsOnStart && yPosition > CurrentPosition.YPosition && (yPosition - CurrentPosition.YPosition) == 1 && (xPosition == CurrentPosition.XPosition))))
                return true;
            else
                return false;
        }

        private bool FitsInOneEveryDirection(byte xPosition, byte yPosition)
        {
            if ((xPosition != CurrentPosition.XPosition || yPosition != CurrentPosition.YPosition) &&
                ((Math.Abs(xPosition - CurrentPosition.XPosition) == 1 && Math.Abs(yPosition - CurrentPosition.YPosition) == 0)//left right
                || (Math.Abs(yPosition - CurrentPosition.YPosition) == 1 && Math.Abs(xPosition - CurrentPosition.XPosition) == 0) //up down
                || (Math.Abs(yPosition - CurrentPosition.YPosition) == 1 && Math.Abs(xPosition - CurrentPosition.XPosition) == 1)))//cross

                return true;
            else
                return false;
        }

        private bool FitsInHorizontalVertical(byte xPosition, byte yPosition)
        {
            if ((xPosition == CurrentPosition.XPosition && yPosition != CurrentPosition.YPosition) ||
                (yPosition == CurrentPosition.YPosition && xPosition != CurrentPosition.XPosition))
                return true;
            else
                return false;
        }

        private bool FitsInFullCross(byte xPosition, byte yPosition)
        {
            if ((xPosition != CurrentPosition.XPosition && yPosition != CurrentPosition.YPosition) &&
                (Math.Abs(xPosition - CurrentPosition.XPosition) == Math.Abs(yPosition - CurrentPosition.YPosition)))
                return true;
            else
                return false;
        }

        private bool FitsInLPattern(byte xPosition, byte yPosition)
        {
            if ((xPosition != CurrentPosition.XPosition && yPosition != CurrentPosition.YPosition) &&
                (Math.Abs(xPosition - CurrentPosition.XPosition) == 2 && Math.Abs(yPosition - CurrentPosition.YPosition) == 1 ||
                Math.Abs(yPosition - CurrentPosition.YPosition) == 2 && Math.Abs(xPosition - CurrentPosition.XPosition) == 1))
                return true;
            else
                return false;
        }

        public virtual IEnumerable<FigurePosition> GetAvailableMoves()
        {
            for (byte i = 0; i < _chessMapCoordinates.Count; i++)
            {
                if (CanMoveTo(_chessMapCoordinates[i].XPosition, _chessMapCoordinates[i].YPosition))
                {
                    yield return _chessMapCoordinates[i];
                }
                else
                    continue;
            }
        }
    }
}
