using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;

namespace ConwaysTests
{
    [TestClass]
    public class InifiniteBoardTests
    {
        [TestMethod]
        public void BoardResizeOnCreation()
        {
            InfiniteBoard board = new InfiniteBoard(new bool[,] { { true } });
            bool[,] expected = new bool[,] { { false, false, false }, { false, true, false }, { false, false, false } };
            CollectionAssert.AreEqual(expected, board.CurrentBoard);
        }

        [TestMethod]
        public void BoardResizeOnTick()
        {
            InfiniteBoard board = new InfiniteBoard(new bool[,] { { false, false, false, false, false }, { false, true, true, true, false }, { false, false, false, false, false } });
            board.Tick();
            bool[,] expected = new bool[,] { { false, false, false, false, false, false, false }, { false, false, false, true, false, false, false }, { false, false, false, true, false, false, false }, { false, false, false, true, false, false, false }, { false, false, false, false, false, false, false } };
            CollectionAssert.AreEqual(expected, board.CurrentBoard);
        }

        [TestMethod]
        public void BoardDoesntResizeWhenNoLiveElementOnEdge()
        {
            InfiniteBoard board = new InfiniteBoard(new bool[,] { { false } });
            bool[,] expected = new bool[,] { { false } };
            CollectionAssert.AreEqual(expected, board.CurrentBoard);
        }
    }
}
