namespace TopCodingMatrixs;

public class LandPerimeter
{
    public int IslandPerimeter(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int bordar = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int cel = grid[row][col];
                if (cel == 1)
                {
                    bordar += 4;
                    if (row > 0 && grid[row - 1][col] == 1)
                    {
                        bordar--;
                    }

                    if (row < rows - 1 && grid[row + 1][col] == 1)
                    {
                        bordar--;
                    }

                    if (col > 0 && grid[row][col - 1] == 1)
                    {
                        bordar--;
                    }

                    if (col < cols - 1 && grid[row][col + 1] == 1)
                    {
                        bordar--;
                    }
                }

           
            }
        }
    
        return bordar;
    }
}