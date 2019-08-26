using ChessGameReact.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGameReact.Tests
{
    public class KnightTests
    {
        [Test]
        public void Pawn_AvailableMoves_For_4x4_AreCorrect()
        {

            List<FigurePosition> availableMovesFromPosition = new List<FigurePosition>
            {
                new FigurePosition(2, 3),
                new FigurePosition(3, 2),
                new FigurePosition(2, 5),
                new FigurePosition(3, 6),
                new FigurePosition(5, 2),
                new FigurePosition(5, 6),
                new FigurePosition(6, 3),
                new FigurePosition(6, 5),
            };

            Knight knight = new Knight(4, 4);

            Assert.That(availableMovesFromPosition, Is.EquivalentTo(knight.GetAvailableMoves().ToList()));
        }
    }
}
