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

            List<(byte xPosition, byte yPosition)> availableMovesFromPosition = new List<(byte xPosition, byte yPosition)>
            {
                (2, 3),
                (3, 2),
                (2, 5),
                (3, 6),
                (5, 2),
                (5, 6),
                (6, 3),
                (6, 5),
            };

            Knight knight = new Knight(4, 4);

            Assert.That(availableMovesFromPosition, Is.EquivalentTo(knight.GetAvailableMoves().ToList()));
        }
    }
}
