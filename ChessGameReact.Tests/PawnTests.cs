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


            List<(byte xPosition, byte yPosition)> availableMovesFromStartPosition = new List<(byte xPosition, byte yPosition)>
            {
                (_pawn.StartPosition.xPostion, (byte)(_pawn.StartPosition.yPosition + 1)),
                (_pawn.StartPosition.xPostion, (byte)(_pawn.StartPosition.yPosition + 2)),
            };


            Assert.That(availableMovesFromStartPosition, Is.EquivalentTo(_pawn.GetAvailableMoves().ToList()));
        }

        [Test]
        public void Pawn_AvailableMoves_For_2x4_AreCorrect()
        {

            List<(byte xPosition, byte yPosition)> availableMovesFromPosition = new List<(byte xPosition, byte yPosition)>
            {
                (2, 5),
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
