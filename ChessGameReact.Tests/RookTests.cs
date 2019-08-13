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


        //[Test]
        //public void Rook_AvailableMoves_FromStartPosition_AreCorrect()
        //{
        //    List<(byte xPosition, byte yPosition)> availableMovesFromStartPosition = new List<(byte xPosition, byte yPosition)>
        //    {
        //        (3, 1),
        //        (5, 1),
        //        (3, 2),
        //        (4, 2),
        //        (5, 2)
        //    };


        //    Assert.That(availableMovesFromStartPosition, Is.EquivalentTo(_rook.GetAvailableMoves().ToList()));
        //}

        [Test]
        public void Rook_AvailableMoves_For_4x5_AreCorrect()
        {

            List<(byte xPosition, byte yPosition)> availableMovesFromPosition = new List<(byte xPosition, byte yPosition)>
            {
                (1, 5),
                (2, 5),
                (3, 5),
                (4, 1),
                (4, 2),
                (4, 3),
                (4, 4),
                (4, 6),
                (4, 7),
                (4, 8),
                (5, 5),
                (6, 5),
                (7, 5),
                (8, 5)
            };

            Rook rook = new Rook(4, 5); 

            Assert.That(availableMovesFromPosition, Is.EquivalentTo(rook.GetAvailableMoves().ToList()));
        }
    }
}
