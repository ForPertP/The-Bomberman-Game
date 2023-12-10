using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'bomberMan' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. STRING_ARRAY grid
     */
    public static void Detonate(List<string> currentGrid, List<string> previousGrid)
    {
        int rows = currentGrid.Count;
        int cols = currentGrid[0].Length;

        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                if (previousGrid[i][j] == 'O')
                {
                    currentGrid[i] = currentGrid[i].Remove(j, 1).Insert(j, ".");
                    if (i + 1 < rows) currentGrid[i + 1] = currentGrid[i + 1].Remove(j, 1).Insert(j, ".");
                    if (i - 1 < rows && i - 1 >= 0) currentGrid[i - 1] = currentGrid[i - 1].Remove(j, 1).Insert(j, ".");
                    if (j + 1 < cols) currentGrid[i] = currentGrid[i].Remove(j + 1, 1).Insert(j + 1, ".");
                    if (j - 1 < cols && j - 1 >= 0) currentGrid[i] = currentGrid[i].Remove(j - 1, 1).Insert(j - 1, ".");
                }
            }
        }
    }
    
    public static List<string> bomberMan(int n, List<string> grid)
    {
        List<string> currentGrid = new List<string>(grid);
        List<string> fullyBombedGrid = new List<string>(grid);
        List<string> detonationPattern;

        int rows = grid.Count;
        int cols = grid[0].Length;

        // Set all cells to 'O' initially
        for (int i = 0; i < rows; ++i)
            currentGrid[i] = new string('O', cols);

        // Set all cells to 'O' for fully bombed grid
        fullyBombedGrid = new List<string>(currentGrid);

        // Detonate initial grid
        Detonate(currentGrid, grid);

        // Save detonation pattern
        detonationPattern = new List<string>(currentGrid);

        // Set all cells to 'O' for the next detonation
        for (int i = 0; i < rows; ++i)
            currentGrid[i] = new string('O', cols);

        // Detonate the next pattern
        Detonate(currentGrid, detonationPattern);

        int patternNumber = n % 4;

        if (n == 1)
            return grid;

        if (patternNumber == 0 || patternNumber == 2)
            return fullyBombedGrid;
        else if (patternNumber == 3)
            return detonationPattern;

        return currentGrid;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r = Convert.ToInt32(firstMultipleInput[0]);

        int c = Convert.ToInt32(firstMultipleInput[1]);

        int n = Convert.ToInt32(firstMultipleInput[2]);

        List<string> grid = new List<string>();

        for (int i = 0; i < r; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Result.bomberMan(n, grid);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
