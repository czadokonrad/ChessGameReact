using ChessGameReact.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGameReact.Tests
{
    public class RookTests
    {
        private Rook _rook;

        [SetUp]
        public void SetUp()
        {
            _rook = new Rook();
        }


        [Test]
        public void Rook_AvailableMoves_For_4x5_AreCorrect()
        {

            List<FigurePosition> availableMovesFromPosition = new List<FigurePosition>
            {
                new FigurePosition(1, 5),
                new FigurePosition(2, 5),
                new FigurePosition(3, 5),
                new FigurePosition(4, 1),
                new FigurePosition(4, 2),
                new FigurePosition(4, 3),
                new FigurePosition(4, 4),
                new FigurePosition(4, 6),
                new FigurePosition(4, 7),
                new FigurePosition(4, 8),
                new FigurePosition(5, 5),
                new FigurePosition(6, 5),
                new FigurePosition(7, 5),
                new FigurePosition(8, 5)
            };

            Rook rook = new Rook(4, 5); 

            Assert.That(availableMovesFromPosition, Is.EquivalentTo(rook.GetAvailableMoves().ToList()));
        }
    }
}
