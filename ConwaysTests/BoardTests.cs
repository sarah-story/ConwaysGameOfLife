using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;

namespace ConwaysTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void BoardCanBeCreated()
        {
            ConwaysBoard board = new ConwaysBoard(new bool[,] { { false } } );
            Assert.IsNotNull(board);
        }

        [TestMethod]
        public void LiveCellFewerThanTwoNeighborsDies()
        {
            ConwaysBoard board = new ConwaysBoard(new bool[,] { { true, false }, { false, false } });
            board.Tick();
            bool[,] expected = new bool[,] { { false, false }, { false, false } }; 
            CollectionAssert.AreEqual(expected, board.CurrentBoard);
        }

        [TestMethod]
        public void LiveCellTwoOrThreeNeighborsLives()
        {
            ConwaysBoard board = new ConwaysBoard(new bool[,] { { true, false, false }, { false, true, false }, { false, false, true } });
            board.Tick();
            bool[,] expected = new bool[,] { { false, false, false }, { false, true, false }, { false, false, false } };
            CollectionAssert.AreEqual(expected, board.CurrentBoard);
        }

        [TestMethod]
        public void LiveCellMoreThanThreeNeighborsDies()
        {
            ConwaysBoard board = new ConwaysBoard(new bool[,] { { false, true, false }, { true, true, true }, { false, true, false } });
            board.Tick();
            bool[,] expected = new bool[,] { { true, true, true }, { true, false, true }, { true, true, true } };
            CollectionAssert.AreEqual(expected, board.CurrentBoard);
        }

        [TestMethod]
        public void DeadCellWithThreeNeighborsLives()
        {
            ConwaysBoard board = new ConwaysBoard(new bool[,] { { true, true }, { true, false } });
            board.Tick();
            bool[,] expected = new bool[,] { { true, true }, { true, true } };
            CollectionAssert.AreEqual(expected, board.CurrentBoard);
        }

        [TestMethod]
        public void Blinker()
        {
            ConwaysBoard board = new ConwaysBoard(new bool[,] { { false, true, false }, { false, true, false }, { false, true, false } });
            board.Tick();
            bool[,] expected = new bool[,] { { false, false, false }, { true, true, true }, { false, false, false } };
            CollectionAssert.AreEqual(expected, board.CurrentBoard);
        }

        [TestMethod]
        public void Block()
        {
            ConwaysBoard board = new ConwaysBoard(new bool[,] { { true, true }, { true, true } });
            board.Tick();
            bool[,] expected = new bool[,] { { true, true }, { true, true } };
            CollectionAssert.AreEqual(expected, board.CurrentBoard);
        }
    }
}
