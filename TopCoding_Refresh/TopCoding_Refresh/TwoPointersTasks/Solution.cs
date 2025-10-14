namespace TopCoding_Refresh.TwoPointersTasks;

public class Solution
{
    private int rows = 0;
    private int cols = 0;

    public string LongestNiceSubstring(string s)
    {
        if (s.Length < 2)
        {
            return "";
        }

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (s.Contains(char.ToLower(c)) && s.Contains(char.ToUpper(c)))
            {
                continue;
            }

            string left = LongestNiceSubstring(s.Substring(0, i));
            string right = LongestNiceSubstring(s.Substring(i + 1));

            return left.Length >= right.Length ? left : right;
        }

        return s;
    }

    List<int> LuckyNumbers(int[][] matrix)
    {
        var res = new List<int>();
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int smalesetInRow = int.MaxValue;
        int bigestInCol = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int num = matrix[row][col];
                smalesetInRow = SmallestInRow(matrix, row, cols);
                bigestInCol = BiggestInColl(matrix, rows, col);

                if (num <= smalesetInRow && num >= bigestInCol)
                {
                    res.Add(num);
                }
            }
        }


        return res;
    }

    private int BiggestInColl(int[][] grid, int rows, int col)
    {
        int biggestNum = 0;

        for (int row = 0; row < rows; row++)
        {
            int n = grid[row][col];
            if (biggestNum < n)
            {
                biggestNum = n;
            }
        }

        return biggestNum;
    }

    private int SmallestInRow(int[][] grid, int row, int cols)
    {
        int min = int.MaxValue;

        for (int col = 0; col < cols; col++)
        {
            int n = grid[row][col];
            if (min > n)
            {
                min = n;
            }
        }

        return min;
    }


    public int IslandPerimeter(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var visited = new bool[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 1)
                {
                    return DFS(grid,r,c,visited);
                }
            }
        }

        return 0;
    }

    private int DFS(int[][] grid, int r, int c, bool[,] visited)
    {
        if (r < 0 || r >= rows || c < 0 || c >= cols || grid[r][c] == 0) return 1;
        if (visited[r, c]) return 0;

        visited[r, c] = true;

        int res = DFS(grid, r+1, c, visited);
        res += DFS(grid, r-1, c, visited);
        res += DFS(grid, r, c+1, visited);
        res += DFS(grid, r, c-1, visited);
        
        return res;
    }
}
