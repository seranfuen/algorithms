namespace Algorithms
{
    public class RotateMatrix
    {
        public void RotateRight(int[][] matrix)
        {
            for (var i = 0; i < matrix.Length; i++)
            for (var j = i + 1; j < matrix.Length; j++)
            {
                if (i == j) continue;

                var temp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = temp;
            }
        }
    }
}