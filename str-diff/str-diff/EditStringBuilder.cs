using System;
using System.Text;

namespace str_diff
{
    class EditStringBuilder
    {
        private int[][] matrix;
        private string a;
        private string b;

        public EditStringBuilder(int[][] matrix, string a, string b)
        {
            this.matrix = matrix;
            this.a = a;
            this.b = b;
        }

        public string EditStringA()
        {
            StringBuilder result = new StringBuilder();
            int i = matrix.Length - 1;
            int j = matrix[0].Length - 1;
            while (i > 0 && j > 0)
            {
                int nextMin = Math.Min(matrix[i - 1][j], matrix[i][j - 1]);
                if (matrix[i - 1][j - 1] == matrix[i][j] && matrix[i][j] <= nextMin)
                {
                    result.Append("=");
                    i--;
                    j--;
                }
                else if (matrix[i][j - 1] == nextMin)
                {
                    result.Append("+");
                    j--;
                }
                else if (matrix[i - 1][j] == nextMin)
                {
                    result.Append("-");
                    i--;
                }
            }
            while (i > 0)
            {
                result.Append("-");
                i--;
            }
            while (j > 0)
            {
                result.Append("+");
                j--;
            }
            Reverse(result);
            return result.ToString();
        }

        private static void Reverse(StringBuilder result)
        {
            int i = 0;
            int j = result.Length - 1;
            while (i < j)
            {
                char temp = result[i];
                result[i] = result[j];
                result[j] = temp;
                i++;
                j--;
            }
        }

    }
}
