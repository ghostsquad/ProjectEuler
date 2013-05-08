using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace ProjectEuler 
{
    /// <summary>
    //In the 2020 grid below, four numbers along a diagonal line have been marked in red.

    //08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08
    //49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00
    //81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65
    //52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91
    //22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80
    //24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50
    //32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70
    //67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21
    //24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72
    //21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95
    //78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92
    //16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57
    //86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58
    //19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40
    //04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66
    //88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69
    //04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36
    //20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16
    //20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54
    //01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48
    //The product of these numbers is 26  63  78  14 = 1788696.

    //What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 2020 grid?
    /// </summary>
    class Problem11
    {
        private static ulong answer = 0;
        private static string GridFileName = "Grid.txt";
        private static List<List<int>> Grid;
        private static List<GridCoordinate> FinalCoordinates = new List<GridCoordinate>();
        private static string FinalDirection = DirectionType.NoDirection;

        static void Main(string[] args)
        {
            Problem11.InitGrid();

            /*
             * strategies
             * 1. skip if
             *      any number is 0
             * 2. store result in answer. only update answer if greater
             * 3. try to touch each number as few times as possible
             *      instead of checking each horizontal, vertical, diagonal possibility
             *          for each number, do right and down and diagonal down left/right, where possible, starting at the top left number.             
             */

            int GridWidth = 20;
            int GridHeight = 20;
            ulong tempProduct = 0;
          
            //setup the 4 numbers that were multiplied together to get us our answer
            FinalCoordinates.Add(new GridCoordinate());
            FinalCoordinates.Add(new GridCoordinate());
            FinalCoordinates.Add(new GridCoordinate());
            FinalCoordinates.Add(new GridCoordinate());            

            //we will need to keep track of coordinates as we loop, in case the product of numbers is > answer
            List<GridCoordinate> tempCoordinates = new List<GridCoordinate>();
            tempCoordinates.Add(new GridCoordinate());
            tempCoordinates.Add(new GridCoordinate());
            tempCoordinates.Add(new GridCoordinate());
            tempCoordinates.Add(new GridCoordinate());

            bool moveOn = false;

            for (int rowNum = 0; rowNum < GridHeight; rowNum++)
            {

                for (int colNum = 0; colNum < GridWidth; colNum++)
                {
                    moveOn = false;

                    //go right
                    if (GridWidth - 1 - colNum >= 4)
                    {
                        tempProduct = 1;
                        for (int i = colNum; i < colNum + 4; i++)
                        {
                            int newNum = Problem11.Grid[rowNum][i];
                            tempCoordinates[i - colNum].Num = newNum;
                            tempCoordinates[i - colNum].Point = new Point(rowNum, i);

                            if (newNum == 0)
                            {
                                moveOn = true;
                                break;
                            }
                            else
                            {
                                tempProduct *= (ulong)newNum;
                            }
                        }

                        if (!moveOn)
                        {
                            SaveProductCoordinates(tempProduct, tempCoordinates, DirectionType.Right);
                        }
                    }                        

                    moveOn = false;
                    
                    //go down
                    if (GridHeight - 1 - rowNum >= 4)
                    {
                        tempProduct = 1;
                        for (int i = rowNum; i < rowNum + 4; i++)
                        {
                            int newNum = Problem11.Grid[i][colNum];
                            tempCoordinates[i - rowNum].Num = newNum;
                            tempCoordinates[i - rowNum].Point = new Point(i, colNum);

                            if (newNum == 0)
                            {
                                moveOn = true;
                                break;
                            }
                            else
                            {
                                tempProduct *= (ulong)newNum;
                            }
                        }

                        if (!moveOn)
                        {
                            SaveProductCoordinates(tempProduct, tempCoordinates, DirectionType.Down);
                        }
                    }                     

                    moveOn = false;

                    //go diagonal right                    
                    if (GridHeight - 1 - rowNum >= 4 && GridWidth - 1 - colNum >= 4)
                    {
                        tempProduct = 1;
                        for (int i = 0; i < 4; i++)
                        {                            
                            //increase row num
                            int newRow = rowNum + i;
                            //increate col num
                            int newCol = colNum + i;

                            int newNum = Problem11.Grid[newRow][newCol];
                            tempCoordinates[i].Num = newNum;
                            tempCoordinates[i].Point = new Point(newRow, newCol);

                            if (newNum == 0)
                            {
                                moveOn = true;
                                break;
                            }
                            else
                            {
                                tempProduct *= (ulong)newNum;
                            }
                        }                            

                        if (!moveOn)
                        {                            
                            SaveProductCoordinates(tempProduct, tempCoordinates, DirectionType.DiagonalRight);
                        }
                    }                        

                    moveOn = false;

                    //go diagonal left
                    if (GridHeight - 1 - rowNum >= 4 && colNum >= 3)
                    {
                        tempProduct = 1;
                        for (int i = 0; i < 4; i++)
                        {
                            //increase row num
                            int newRow = rowNum + i;
                            //decrease col num
                            int newCol = colNum - i;

                            int newNum = Problem11.Grid[newRow][newCol];
                            tempCoordinates[i].Num = newNum;
                            tempCoordinates[i].Point = new Point(newRow, newCol);

                            if (newNum == 0)
                            {
                                moveOn = true;
                                break;
                            }
                            else
                            {
                                tempProduct *= (ulong)newNum;
                            }
                        }

                        if (!moveOn)
                        {
                            SaveProductCoordinates(tempProduct, tempCoordinates, DirectionType.DiagonalLeft);
                        }
                    }                                            
                }
            }

            Problem11.DisplayGrid();

            Console.WriteLine("");

            Console.WriteLine(string.Format("answer: {0}", Problem11.answer.ToString()));

            //foreach (GridCoordinate coor in FinalCoordinates)
            //{
            //    Console.WriteLine("Num: " + coor.Num.ToString());
            //    Console.WriteLine(string.Format("x: {0}; y: {0}", coor.Point.X.ToString(), coor.Point.Y.ToString()));           
            //}

            Console.WriteLine("direction: " + Problem11.FinalDirection);

            Console.ReadLine();
        }

        private static void InitGrid()
        {
            Problem11.Grid = new List<List<int>>();

            using (StreamReader sr = new StreamReader(Problem11.GridFileName))
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
            if (tempProduct > Problem11.answer)
            {
                Point TempPoint;

                Problem11.answer = tempProduct;
                Problem11.FinalDirection = direction;
                for (int i = 0; i < 4; i++)
                {
                    TempPoint = TempCoordinates[i].Point;
                    Problem11.FinalCoordinates[i].Num = TempCoordinates[i].Num;
                    Problem11.FinalCoordinates[i].Point = new Point(TempPoint.X, TempPoint.Y);
                }
            }
        }

        private static void DisplayGrid()
        {
            for (int rowNum = 0; rowNum < Problem11.Grid.Count; rowNum++)
            {
                List<int> gridRow = Problem11.Grid[rowNum];
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

                    Console.Write(Problem11.Grid[rowNum][colNum].ToString().PadLeft(2, '0'));
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
