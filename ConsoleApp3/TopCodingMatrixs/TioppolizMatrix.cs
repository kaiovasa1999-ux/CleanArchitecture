namespace TopCodingMatrixs;

public class TioppolizMatrix
{
    public bool IsToeplitzMatrix(int[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int initialRowStart = 0;
        int result = 0;
        for (int row = 0; row < rows; row++)
        {
            initialRowStart = row;
            for (int col = 0; col < cols; col++)
            {
                int cell = matrix[row][col];
                result += ValidateDiagonal(matrix,  rows, cols, initialRowStart, cell, row, col);
            }

            if (result != 0)
            {
                break;
            }
        }

        return result == 0;
    }

    private int ValidateDiagonal(int[][] matrix, int rows, int cols, int initialRowStart, int cell, int row, int col)
    {
        int diagonalCell = 0;
        if (initialRowStart + 1 < rows && col + 1 < cols)
        {
            diagonalCell = matrix[row + 1][col + 1];
            row += 1;
            col += 1;
            initialRowStart++;

            if (cell != diagonalCell)
            {
                return 1;
            }
            return ValidateDiagonal(matrix, rows, cols, initialRowStart, diagonalCell, row, col); 
        }
        return 0;
    }
}

