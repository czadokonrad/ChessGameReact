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

            List<(byte xPosition, byte yPosition)> availableMovesFromPosition = new List<(byte xPosition, byte yPosition)>
            {
                (1, 1),
                (2, 2),
                (3, 3),
                (3, 4),
                (3, 5),
                (2, 4),
                (1, 4),
                (1, 7),
                (2, 6),
                (4, 1),
                (4, 2),
                (4, 3),
                (4, 5),
                (4, 6),
                (4, 7),
                (4, 8),
                (5, 3),
                (5, 4),
                (5, 5),
                (6, 2),
                (6, 4),
                (6, 6),
                (7, 1),
                (7, 4),
                (7, 7),
                (8, 4),
                (8, 8)
            };

            Queen rook = new Queen(4, 4);

            Assert.That(availableMovesFromPosition, Is.EquivalentTo(rook.GetAvailableMoves().ToList()));
        }
    }
}
