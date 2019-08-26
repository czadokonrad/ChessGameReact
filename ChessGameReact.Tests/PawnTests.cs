using ChessGameReact.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGameReact.Tests
{
    public class PawnTests
    {
        private Pawn _pawn;

        [SetUp]
        public void SetUp()
        {
            _pawn = new Pawn();
        }


        [Test]
        public void Pawn_AvailableMoves_FromStartPosition_AreCorrect()
        {


            List<FigurePosition> availableMovesFromStartPosition = new List<FigurePosition>
            {
                new FigurePosition(_pawn.StartPosition.XPosition, (byte)(_pawn.StartPosition.YPosition + 1)),
                new FigurePosition(_pawn.StartPosition.XPosition, (byte)(_pawn.StartPosition.YPosition + 2)),
            };


            Assert.That(availableMovesFromStartPosition, Is.EquivalentTo(_pawn.GetAvailableMoves().ToList()));
        }

        [Test]
        public void Pawn_AvailableMoves_For_2x4_AreCorrect()
        {

            List<FigurePosition> availableMovesFromPosition = new List<FigurePosition>
            {
                new FigurePosition(2, 5),
            };

            Pawn pawn = new Pawn(2, 4);

            Assert.That(availableMovesFromPosition, Is.EquivalentTo(pawn.GetAvailableMoves().ToList()));
        }

        [Test]
        public void Pawn_CanMove_ShouldReturnFalse_WhenNoMoveAvailable()
        {
            Pawn pawn = new Pawn(1, 8);

            Assert.IsFalse(pawn.CanMoveTo(1, 9));
        }

        [Test]
        [TestCase(1, 3)]
        public void Pawn_CanMove_ShouldReturnTrue_WhenMoveAvailable(byte xPosition, byte yPosition)
        {
            Pawn pawn = new Pawn(1, 2);
            Assert.IsTrue(pawn.CanMoveTo(xPosition, yPosition));
        }
    }
}
