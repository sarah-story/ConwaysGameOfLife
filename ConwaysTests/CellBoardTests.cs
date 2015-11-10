using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;
using System.Linq;
using System.Collections.Generic;

namespace ConwaysTests
{
    [TestClass]
    public class CellBoardTests
    {
        [TestMethod]
        public void Constructor()
        {
            bool[,] grid = new bool[,] { { true, true }, { true, true } };
            CellBoard board = new CellBoard(grid);
            List<bool> row1 = new List<bool>(new bool[] { true, true });
            List<bool> row2 = new List<bool>(new bool[] { true, true });
            List<List<bool>> expected = new List<List<bool>>();
            expected.Add(row1);
            expected.Add(row2);
            CollectionAssert.AreEqual(expected, board.ToList());
        }
    }
}
