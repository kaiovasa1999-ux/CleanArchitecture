namespace TopCodingMatrixs;

public class LuckyNumbersTask
{
    public List<int> LuckyNumbers (int[][] matrix) {
        
        var luckyNumbers = new List<int>();
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int cell = matrix[row][col];
                int minimumInRow = SmallestInRow(matrix, row, cols);
                int biggestInColl = BiggestInColl(matrix, rows, col);

                if (cell <= minimumInRow && cell >= biggestInColl)
                {
                    luckyNumbers.Add(cell);
                }
            }
        }
        return luckyNumbers;
    }

    private int BiggestInColl(int[][] matrix, int rows, int col)
    {
        int res = 0;
        
        for (int row = 0; row < rows; row++)
        {
            int cell = matrix[row][col];
            if (res < cell)
            {
                res = cell;
            }
        }
        
        return res;
    }

    private int SmallestInRow(int[][] matrix, int row, int cols)
    {
        int min = int.MaxValue;
        for (int col = 0; col < cols; col++)
        {
            int cell = matrix[row][col];
            if (min > cell)
            {
                min = cell;
            }
        }

        return min;
    }
}