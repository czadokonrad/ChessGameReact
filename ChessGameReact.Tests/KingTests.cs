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
            List<FigurePosition> availableMovesFromStartPosition = new List<FigurePosition>
            {
                new FigurePosition(3, 1),
                new FigurePosition(5, 1),
                new FigurePosition(3, 2),
                new FigurePosition(4, 2),
                new FigurePosition(5, 2)
            };


            Assert.That(availableMovesFromStartPosition, Is.EquivalentTo(_king.GetAvailableMoves().ToList()));
        }

        [Test]
        public void King_AvailableMoves_For_6x5_AreCorrect()
        {

            List<FigurePosition> availableMovesFromPosition = new List<FigurePosition>
            {
                new FigurePosition(5, 4),
                new FigurePosition(5, 5),
                new FigurePosition(5, 6),
                new FigurePosition(6, 4),
                new FigurePosition(6, 6),
                new FigurePosition(7, 4),
                new FigurePosition(7, 5),
                new FigurePosition(7, 6)
            };

            King king = new King(6, 5);

            Assert.That(availableMovesFromPosition, Is.EquivalentTo(king.GetAvailableMoves().ToList()));
        }

    }
}