using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class ConwaysBoard : Board
    {
        private bool[,] currentBoard;
        private bool[,] nextBoard;

        public ConwaysBoard(bool[,] start)
        {
            currentBoard = start;
            nextBoard = new bool[start.GetLength(0), start.GetLength(1)];
        }

        public List<List<bool>> ToList()
        {
            List<List<bool>> list = new List<List<bool>>();
            for (int i = 0; i < currentBoard.GetLength(0); i++)
            {
                List<bool> temp = new List<bool>();
                for (int j = 0; j < currentBoard.GetLength(1); j++)
                {
                    temp.Add(currentBoard[i, j]);
                }

                list.Add(temp);
            }
            return list;
        }
        public void Tick()
        {
            for (int i = 0; i < currentBoard.GetLength(0); i++)
            {
                Parallel.For(0, currentBoard.GetLength(1), index => CheckRules(i, index));
            }
            currentBoard = nextBoard;
            nextBoard = new bool[currentBoard.GetLength(0), currentBoard.GetLength(1)];
        }

        private void CheckRules(int i, int j)
        {
            int alive = 0;
            alive = Above(i, j) ? alive + 1 : alive;
            alive = Below(i, j) ? alive + 1 : alive;
            alive = Right(i, j) ? alive + 1 : alive;
            alive = Left(i, j) ? alive + 1 : alive;
            alive = TopLeft(i, j) ? alive + 1 : alive;
            alive = TopRight(i, j) ? alive + 1 : alive;
            alive = BottomLeft(i, j) ? alive + 1 : alive;
            alive = BottomRight(i, j) ? alive + 1 : alive;
            if (currentBoard[i,j] == true )
            {
                if (alive < 2)
                {
                    nextBoard[i, j] = false;
                }
                else if (alive < 4)
                {
                    nextBoard[i, j] = true;
                }
                else
                {
                    nextBoard[i, j] = false;
                }
            }
            else
            {
                if (alive == 3)
                {
                    nextBoard[i, j] = true;
                }
                else
                {
                    nextBoard[i, j] = false;
                }
            }
        }

        private bool Left(int i, int j)
        {
            try
            {
                return currentBoard[i, j - 1];
            }
            catch (Exception)
            {

                return false;
            }
        }

        private bool Right(int i, int j)
        {
            try
            {
                return currentBoard[i, j + 1];
            }
            catch(Exception)
            {
                return false;
            }            
        }

        private bool Above(int i, int j)
        {
            try
            {
                return currentBoard[i + 1, j];
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        private bool Below(int i, int j)
        {
            try
            {
                return currentBoard[i - 1, j];
            }
            catch (Exception)
            {

                return false;
            }
        }

        private bool TopLeft(int i, int j)
        {
            try
            {
                return currentBoard[i - 1, j - 1];
            }
            catch (Exception)
            {

                return false;
            }
        }
        private bool TopRight(int i, int j)
        {
            try
            {
                return currentBoard[i - 1, j + 1];
            }
            catch (Exception)
            {

                return false;
            }
        }

        private bool BottomLeft(int i, int j)
        {
            try
            {
                return currentBoard[i + 1, j - 1];
            }
            catch (Exception)
            {

                return false;
            }
        }

        private bool BottomRight(int i, int j)
        {
            try
            {
                return currentBoard[i + 1, j + 1];
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool[,] CurrentBoard { get { return currentBoard; } }
    }
}
