using ChessGameReact.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ChessFigureTests
    {
        private King _king;

        [SetUp]
        public void Setup()
        {
            _king = new King();
        }


        [Test]
        public void King_AvailableMoves_FromStartPosition_AreCorrect()
        {
            List<(byte xPosition, byte yPosition)> availableMovesFromStartPosition = new List<(byte xPosition, byte yPosition)>
            {
                (3, 1),
                (5, 1),
                (3, 2),
                (4, 2),
                (5, 2)
            };


            Assert.That(availableMovesFromStartPosition, Is.EquivalentTo(_king.GetAvailableMoves().ToList()));
        }

        [Test]
        public void King_AvailableMoves_For_6x5_AreCorrect()
        {

            List<(byte xPosition, byte yPosition)> availableMovesFromPosition = new List<(byte xPosition, byte yPosition)>
            {
                (5, 4),
                (5, 5),
                (5, 6),
                (6, 4),
                (6, 6),
                (7, 4),
                (7, 5),
                (7, 6)
            };

            King king = new King(6, 5);

            Assert.That(availableMovesFromPosition, Is.EquivalentTo(king.GetAvailableMoves().ToList()));
        }

    }
}