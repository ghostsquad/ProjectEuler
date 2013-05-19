using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedMath;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace ProjectEuler
{
    /// <summary>

    /// </summary>
    public static class Problem011
    {
        public static ulong Answer { get; private set; }
        public static string FinalDirection { get; private set; }
        public static List<GridCoordinate> FinalCoordinates { get; private set; }

        private static bool _solved = false;
        public static bool Solved { get { return Problem011._solved; } private set { Problem011._solved = value; } }

        private static string _marketValue = string.Empty;
        public static string MarketValue { private get { return Problem011._marketValue; } set { _marketValue = value.ToUpper(); } }

        private static string GridFileName = "ProblemFiles\\Problem011_Grid.txt";
        private static List<List<int>> Grid;

        /// <summary>
        /// What is the greatest product of four adjacent numbers in the same direction (up, down, left right, or diagonal) in the 20x20 grid?
        /// </summary>
        public static void Solve(int gridWidth)
        {
            Problem011.FinalDirection = DirectionType.NoDirection;
            Problem011.FinalCoordinates = new List<GridCoordinate>();
            Problem011.InitGrid();

            List<GridCoordinate> tempCoordinates = new List<GridCoordinate>();

            ulong tempProduct = 0;
            //setup the 4 numbers that were multiplied together to get us our answer
            //we also need a temporary set of coordinates
            for (int i = 1; i <= 4; i++)
            {
                FinalCoordinates.Add(new GridCoordinate());
                tempCoordinates.Add(new GridCoordinate());
            }

            bool moveOn = false;

            for (int rowNum = 0; rowNum < gridWidth; rowNum++)
            {

                for (int colNum = 0; colNum < gridWidth; colNum++)
                {
                    moveOn = false;

                    //go right                    

                    //go down

                    //go diagonal left

                    //go diagonal right

                }

            }

            Problem011.Solved = true;
        }

        private static List<int> GetConsecutiveNumbers(Point currentLocation, DirectionType direction)
        {
            List<int> consecutiveNumbers = new List<int>();

            return consecutiveNumbers;
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

        private static void SaveProductCoordinates(ulong tempProduct, List<GridCoordinate> TempCoordinates, string direction)
        {
            if (tempProduct > Problem011.Answer)
            {
                Point TempPoint;

                Problem011.Answer = tempProduct;
                Problem011.FinalDirection = direction;
                for (int i = 0; i < 4; i++)
                {
                    TempPoint = TempCoordinates[i].Point;
                    Problem011.FinalCoordinates[i].Num = TempCoordinates[i].Num;
                    Problem011.FinalCoordinates[i].Point = new Point(TempPoint.X, TempPoint.Y);
                }
            }
        }

        public static void DisplayGrid()
        {
            if (!Problem011.Solved)
            {
                throw new System.ApplicationException("problem needs solving before displaying grid");
            }

            for (int rowNum = 0; rowNum < Problem011.Grid.Count; rowNum++)
            {
                List<int> gridRow = Problem011.Grid[rowNum];
                for (int colNum = 0; colNum < gridRow.Count; colNum++)
                {

                    foreach (GridCoordinate gridCoor in FinalCoordinates)
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

        private class GridCoordinate
        {
            public int Num;
            public System.Drawing.Point Point;
        }

        private static class DirectionType
        {
            public static readonly string Down = "Down";
            public static readonly string Right = "Right";
            public static readonly string DiagonalRight = "Diagonal Right";
            public static readonly string DiagonalLeft = "Diagonal Left";
            public static readonly string NoDirection = "No Direction";
        }
    }
}
