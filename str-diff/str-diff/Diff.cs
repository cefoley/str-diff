using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace str_diff
{
    public class Diff
    {
        private int[][] matrix;

        public Diff(int[][] matrix)
        {
            this.matrix = matrix;
        }

        public int[][] Matrix()
        {
            return matrix;
        }

        public bool AreEqual()
        {
            return matrix[matrix.Length - 1][matrix[0].Length - 1] == 0;
        }

        public string EditStringA()
        {
            StringBuilder result = new StringBuilder();
            int i = matrix.Length - 1;
            int j = matrix[0].Length - 1;
            while (i > 0 && j > 0)
            {
                int nextMin = EditDistance.Min(matrix[i - 1][j - 1], matrix[i - 1][j], matrix[i][j - 1]);
                if (matrix[i - 1][j - 1] == nextMin)
                {
                    string edit = matrix[i][j] == nextMin ? "=" : "?";
                    result.Append(edit);
                    i--;
                    j--;
                } else if (matrix[i-1][j] == nextMin)
                {
                    result.Append("-");
                    i--;
                } else
                {
                    result.Append("+");
                    j--;
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
