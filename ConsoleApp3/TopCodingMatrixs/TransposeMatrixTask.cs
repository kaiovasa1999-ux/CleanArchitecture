namespace TopCodingMatrixs;

public class TransposeMatrixTask
{
    public int[][] Transpose(int[][] matrix) {
            
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int[][] result = new int[cols][];

        for (int c = 0; c < cols; c++)
        {
            result[c] = new int[rows];
            for (int r = 0; r < rows; r++)
            {
                result[c][r] = matrix[r][c];
            }
        }
        
        return result;
    }
}