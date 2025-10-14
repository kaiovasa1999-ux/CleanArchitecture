namespace TopCodingMatrixs;

public class NumSpecialTask
{
    public int NumSpecial(int[][] mat)
    {
        int count = 0;

        int rows = mat.Length;
        int cols = mat[0].Length;
        int cell = 0;
        int times = 0;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                cell = mat[r][c];
                if (cell == 1)
                {
                    times++;
                    count +=ValidateCoordinates(mat, r, c);
                }
                
            }
        }

        return count;
    }

    private int ValidateCoordinates(int[][] mat, int row, int column)
    {
       int rows = mat.Length;
       int cols = mat[0].Length;
       int count = 0;
       var rowData = 0;
       var colData = 0;
       for (int r = 0; r <rows; r++)
       {
           rowData += mat[r][column];
       }

       for (int c = 0; c < cols; c++)
       {
           colData += mat[row][c];
       }
       var res  = rowData + colData;
       if (res > 2)
       {
           return 0;
       }
       return 1;
    }
}