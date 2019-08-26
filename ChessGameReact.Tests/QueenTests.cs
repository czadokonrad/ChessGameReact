using ChessGameReact.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGameReact.Tests
{
    public class QueenTests
    {
        [Test]
        public void Rook_AvailableMoves_For_4x4_AreCorrect()
        {

            List<FigurePosition> availableMovesFromPosition = new List<FigurePosition>
            {
                new FigurePosition(1, 1),
                new FigurePosition(2, 2),
                new FigurePosition(3, 3),
                new FigurePosition(3, 4),
                new FigurePosition(3, 5),
                new FigurePosition(2, 4),
                new FigurePosition(1, 4),
                new FigurePosition(1, 7),
                new FigurePosition(2, 6),
                new FigurePosition(4, 1),
                new FigurePosition(4, 2),
                new FigurePosition(4, 3),
                new FigurePosition(4, 5),
                new FigurePosition(4, 6),
                new FigurePosition(4, 7),
                new FigurePosition(4, 8),
                new FigurePosition(5, 3),
                new FigurePosition(5, 4),
                new FigurePosition(5, 5),
                new FigurePosition(6, 2),
                new FigurePosition(6, 4),
                new FigurePosition(6, 6),
                new FigurePosition(7, 1),
                new FigurePosition(7, 4),
                new FigurePosition(7, 7),
                new FigurePosition(8, 4),
                new FigurePosition(8, 8)
            };

            Queen rook = new Queen(4, 4);

            Assert.That(availableMovesFromPosition, Is.EquivalentTo(rook.GetAvailableMoves().ToList()));
        }
    }
}
