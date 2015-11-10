using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class CellBoard
    {
        private List<Cell> currentBoard = new List<Cell>();
        private List<Cell> nextBoard = new List<Cell>();
        private int size;

        public CellBoard(bool[,] start)
        {
            Cell current;
            size = start.GetLength(1);
            for (int i = 0; i < start.GetLength(0); i++)
            {
                for (int j = 0; j < start.GetLength(1); j++)
                {
                    current = new Cell(start[i,j]);
                    currentBoard.Add(current);
                    if (j == 0)
                    {
                        current.Left = null;
                        current.TopLeft = null;

                        try { currentBoard[currentBoard.Count - 2].Right = null; }
                        catch (ArgumentOutOfRangeException) { }

                        try { currentBoard[currentBoard.Count - start.GetLength(1) - 2].BottomRight = null; }
                        catch (ArgumentOutOfRangeException) { }
                    }
                    else
                    {
                        try { current.Left = currentBoard[currentBoard.Count - 2]; }
                        catch (Exception) { }

                        try { current.TopLeft = currentBoard[currentBoard.Count - start.GetLength(1) - 2]; }
                        catch (ArgumentOutOfRangeException) { current.TopLeft = null; }

                        try { currentBoard[currentBoard.Count - 2].Right = current; }
                        catch (ArgumentOutOfRangeException) { }

                        try { currentBoard[currentBoard.Count - start.GetLength(1) - 2].BottomRight = current; }
                        catch (ArgumentOutOfRangeException) { }
                    }

                    if (j == start.GetLength(1) - 1)
                    {
                        current.TopRight = null;

                        try { currentBoard[currentBoard.Count - start.GetLength(1)].BottomLeft = null; }
                        catch (ArgumentOutOfRangeException) { }
                    }
                    else
                    {
                        try { current.TopRight = currentBoard[currentBoard.Count - start.GetLength(1)]; }
                        catch (ArgumentOutOfRangeException) { }

                        try { currentBoard[currentBoard.Count - start.GetLength(1)].BottomLeft = current; }
                        catch (ArgumentOutOfRangeException) { }
                    }

                    try { current.Top = currentBoard[currentBoard.Count - start.GetLength(1) - 1]; }
                    catch (ArgumentOutOfRangeException) { }

                    try { currentBoard[currentBoard.Count - start.GetLength(1) - 1].Bottom = current; }
                    catch (ArgumentOutOfRangeException) { }
                }
            }
        }

        public List<List<bool>> ToList()
        {
            List<List<bool>> list = new List<List<bool>>();
            for (int i = 0; i < currentBoard.Count / size; i++)
            {
                List<bool> temp = new List<bool>();
                for (int j = 0; j < size; j++)
                {
                    temp.Add(currentBoard.ElementAt(j + (size * i)).Alive);
                }

                list.Add(temp);
            }
            return list;
        }
        public void Tick()
        {

            for(int i = 0; i < currentBoard.Count; i++) { CheckRules(currentBoard[i]); }
            for(int i = 0; i < currentBoard.Count; i++)
            {
                currentBoard[i].Alive = currentBoard[i].Next;
                currentBoard[i].Next = false;
            }
        }

        private void CheckRules(Cell cell)
        {
            int alive = 0;
            try { alive = cell.Top.Alive ? alive + 1 : alive; } catch (NullReferenceException) { }
            try { alive = cell.TopRight.Alive ? alive + 1 : alive; } catch (NullReferenceException) { }
            try { alive = cell.Right.Alive ? alive + 1 : alive; } catch (NullReferenceException) { }
            try { alive = cell.BottomRight.Alive ? alive + 1 : alive; } catch (NullReferenceException) { }
            try { alive = cell.Bottom.Alive ? alive + 1 : alive; } catch (NullReferenceException) { }
            try { alive = cell.BottomLeft.Alive ? alive + 1 : alive; } catch (NullReferenceException) { }
            try { alive = cell.Left.Alive ? alive + 1 : alive; } catch (NullReferenceException) { }
            try { alive = cell.TopLeft.Alive ? alive + 1 : alive; } catch (NullReferenceException) { }
            
            if (cell.Alive)
            {
                if (alive < 2)
                {
                    cell.Next = false;
                }
                else if (alive < 4)
                {
                    cell.Next = true;
                }
                else
                {
                    cell.Next = false;
                }
            }
            else
            {
                if (alive == 3)
                {
                    cell.Next = true;
                }
                else
                {
                    cell.Next = false;
                }
            }
        }

        public List<Cell> CurrentBoard { get { return currentBoard; } }
    }
}
