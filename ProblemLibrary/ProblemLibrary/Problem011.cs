using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    /// <summary>
    /// In the 2020 grid below, four numbers along a diagonal line have been marked in red.
    /// ....
    /// The product of these numbers is 26  63  78  14 = 1788696.
    /// What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 2020 grid?
    /// </summary>
    public class Problem011
    {
        public ulong Answer { get; private set; }
        public DirectionType FinalDirection { get; private set; }
        public List<GridCoordinate> FinalCoordinates { get; private set; }

        private bool _solved = false;
        public bool Solved { get { return this._solved; } private set { this._solved = value; } }

        private static string GridFileName = "ProblemFiles\\Problem011_Grid.txt";
        private static List<List<int>> Grid;

        private int maxIndex;

        public ulong Solve(int gridWidth = 20)
        {
            this.Answer = 0;

            this.FinalDirection = DirectionType.NoDirection;
            this.FinalCoordinates = new List<GridCoordinate>();
            this.maxIndex = gridWidth - 1;
            Problem011.InitGrid();
            
            for (int i = 1; i <= 4; i++)
            {
                FinalCoordinates.Add(new GridCoordinate());                
            }

            for (int rowNum = 0; rowNum < gridWidth; rowNum++)
            {

                for (int colNum = 0; colNum < gridWidth; colNum++)
                {
                    //go right
                    GetSaveConsecutiveNumbers((new Point(rowNum, colNum)), DirectionType.Right);

                    //go down
                    GetSaveConsecutiveNumbers((new Point(rowNum, colNum)), DirectionType.Down);

                    //go diagonal left
                    GetSaveConsecutiveNumbers((new Point(rowNum, colNum)), DirectionType.DiagonalLeft);

                    //go diagonal right
                    GetSaveConsecutiveNumbers((new Point(rowNum, colNum)), DirectionType.DiagonalRight);
                }

            }

            this.Solved = true;

            return this.Answer;
        }

        private void GetSaveConsecutiveNumbers(Point currentLocation, DirectionType direction)
        {
            bool spaceRight = (this.maxIndex - currentLocation.X >= 4);
            bool spaceDown = (this.maxIndex - currentLocation.Y >= 4);
            bool spaceLeft = (currentLocation.X >= 3);

            int columnsToMove = 0;
            int rowsToMove = 0;

            bool spaceAvail = false;

            switch(direction)
            {
                case DirectionType.Right:
                    if (spaceRight)
                    {
                        spaceAvail = true;
                        columnsToMove = 4;
                    }                    

                    break;
                case DirectionType.Down:
                    if (spaceDown)
                    {
                        spaceAvail = true;
                        rowsToMove = 4;
                    }                    

                    break;
                case DirectionType.DiagonalLeft:
                    if (spaceDown && spaceLeft)
                    {
                        spaceAvail = true;
                        rowsToMove = 4;
                        columnsToMove = -4;                        
                    }

                    break;
                case DirectionType.DiagonalRight:
                    if (spaceDown && spaceRight)
                    {
                        spaceAvail = true;
                        rowsToMove = 4;
                        columnsToMove = 4;
                    }                    

                    break;
            }

            if (!spaceAvail)
            {
                return;
            }

            List<GridCoordinate> tempCoordinates = new List<GridCoordinate>();

            int columnsMoved = 0;
            int rowsMoved = 0;

            ulong newProduct = 1;

            for (int i = 0; i < 4; i++)
            {
                int newRow = currentLocation.Y;
                int newCol = currentLocation.X;

                //update row
                if (rowsToMove > rowsMoved)
                {
                    newRow = currentLocation.Y + (rowsToMove > 0 ? i : -i);
                }                
                //update column
                if (columnsToMove > columnsMoved)
                {
                    newCol = currentLocation.X + (columnsToMove > 0 ? i : -i);
                }

                int num = Grid[newRow][newCol];

                if (num == 0)
                {
                    break;
                }

                newProduct = checked(newProduct * (ulong)num);

                tempCoordinates.Add(new GridCoordinate(Grid[newRow][newCol], new Point(newRow, newCol)));
            }

            if (newProduct > this.Answer)
            {
                SaveProductCoordinates(newProduct, tempCoordinates, direction);
            }
        }

        private static void InitGrid()
        {
            Problem011.Grid = new List<List<int>>();

            using (StreamReader sr = new StreamReader(Problem011.GridFileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    List<int> GridLine = line.Split(' ').Select(c => Convert.ToInt32(c)).ToList<int>();
                    Grid.Add(GridLine);
                }
            }
        }

        private void SaveProductCoordinates(ulong tempProduct, List<GridCoordinate> TempCoordinates, DirectionType direction)
        {            
            Point TempPoint;

            this.Answer = tempProduct;
            this.FinalDirection = direction;
            for (int i = 0; i < 4; i++)
            {
                TempPoint = TempCoordinates[i].Point;
                this.FinalCoordinates[i].Num = TempCoordinates[i].Num;
                this.FinalCoordinates[i].Point = new Point(TempPoint.X, TempPoint.Y);
            }            
        }

        public void DisplayGrid()
        {
            if (!this.Solved)
            {
                throw new System.ApplicationException("problem needs solving before displaying grid");
            }

            for (int rowNum = 0; rowNum < Problem011.Grid.Count; rowNum++)
            {
                List<int> gridRow = Problem011.Grid[rowNum];
                for (int colNum = 0; colNum < gridRow.Count; colNum++)
                {

                    foreach (GridCoordinate gridCoor in this.FinalCoordinates)
                    {
                        if (gridCoor.Point.X == colNum && gridCoor.Point.Y == rowNum)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        }
                    }

                    Console.Write(Problem011.Grid[rowNum][colNum].ToString().PadLeft(2, '0'));
                    Console.ResetColor();

                    if (colNum + 1 < gridRow.Count)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(Environment.NewLine);
                    }
                }
            }
        }

        public class GridCoordinate
        {
            public int Num { get; set; }
            public System.Drawing.Point Point { get; set; }

            public GridCoordinate()
            {

            }

            public GridCoordinate(int num, Point point)
            {
                this.Num = num;
                this.Point = point;
            }
        }

        public enum DirectionType
        {           
            Down,            
            Right,            
            DiagonalRight,
            DiagonalLeft,
            NoDirection
        }
    }
}
