using System;

namespace Algorithms
{
    public class RotateMatrixElement
    {
        public void Rotate(int[][] matrix)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
            if (matrix.Length <= 1) return;
            var col = 0;
            var row = 0;
            var maxRow = matrix.Length - 1;
            var maxCol = matrix[0].Length - 1;

            if (maxCol == 0) return; // dimension is less than 2 for columns

            while (col <= maxCol && row <= maxRow)
            {
                var previous = matrix[row + 1][col];

                // shift first row to the right once
                for (var i = col; i <= maxCol; i++)
                {
                    var current = matrix[row][i];
                    matrix[row][i] = previous;
                    previous = current;
                }

                row++;

                // shift last column down once
                for (var j = row; j <= maxRow; j++)
                {
                    var current = matrix[j][maxCol];
                    matrix[j][maxCol] = previous;
                    previous = current;
                }

                maxCol--;

                // shift last row to the left once
                for (var i = maxCol; i >= col; i--)
                {
                    var current = matrix[maxRow][i];
                    matrix[maxRow][i] = previous;
                    previous = current;
                }

                maxRow--;

                // shift first column elements up one place
                for (var j = maxRow; j >= row; j--)
                {
                    var current = matrix[j][col];
                    matrix[j][col] = previous;
                    previous = current;
                }

                col++;
            }
        }
    }
}