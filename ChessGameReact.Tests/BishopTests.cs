using ChessGameReact.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGameReact.Tests
{
    public class BishopTests
    {
        [Test]
        public void Bishop_AvailableMoves_For_4x5_AreCorrect()
        {

            List<FigurePosition> availableMovesFromPosition = new List<FigurePosition>
            {
                new FigurePosition(1, 2),
                new FigurePosition(2, 3),
                new FigurePosition(3, 4),
                new FigurePosition(3, 6),
                new FigurePosition(2, 7),
                new FigurePosition(1, 8),
                new FigurePosition(5, 4),
                new FigurePosition(6, 3),
                new FigurePosition(7, 2),
                new FigurePosition(8, 1),
                new FigurePosition(5, 6),
                new FigurePosition(6, 7),
                new FigurePosition(7, 8)
            };

            Bishop bishop = new Bishop(4, 5);

            Assert.That(availableMovesFromPosition, Is.EquivalentTo(bishop.GetAvailableMoves().ToList()));
        }
    }
}
