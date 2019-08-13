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

            List<(byte xPosition, byte yPosition)> availableMovesFromPosition = new List<(byte xPosition, byte yPosition)>
            {
                (1, 2),
                (2, 3),
                (3, 4),
                (3, 6),
                (2, 7),
                (1, 8),
                (5, 4),
                (6, 3),
                (7, 2),
                (8, 1),
                (5, 6),
                (6, 7),
                (7, 8)
            };

            Bishop bishop = new Bishop(4, 5);

            Assert.That(availableMovesFromPosition, Is.EquivalentTo(bishop.GetAvailableMoves().ToList()));
        }
    }
}
