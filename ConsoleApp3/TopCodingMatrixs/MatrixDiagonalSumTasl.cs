namespace TopCodingMatrixs;

public class MatrixDiagonalSumTasl
{
    public int DiagonalSum(int[][] mat)
    {
        
        int diagonalSum = 0;
        int matrixSize = mat.Length;

        for (int row = 0; row < matrixSize; row++)
        {
            diagonalSum += mat[row][row];
            diagonalSum += mat[row][matrixSize - row - 1];
        }
        

        if (matrixSize % 2 == 1)
        {
            diagonalSum -= mat[matrixSize / 2][matrixSize / 2];
        }
        return diagonalSum;
    }
}