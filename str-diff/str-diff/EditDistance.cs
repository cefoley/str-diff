using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace str_diff
{
    public class EditDistance
    {
        private string a;
        private string b;

        public EditDistance(string a, string b)
        {
            this.a = a;
            this.b = b;
        }

        public Diff Diff()
        {
            int[][] matrix = MakeMatrix();
            return new Diff(matrix, a, b);
        }

        private int[][] MakeMatrix()
        {
            int[][] result = InitialisMatrix();
            PopulateMatrix(result);
            return result;
        }

        private int[][] InitialisMatrix()
        {
            int[][] result = new int[a.Length + 1][];
            for (int i = 0; i < result.Length; i++)
                result[i] = new int[b.Length + 1];
            for (int i = 0; i < result[0].Length; i++)
                result[0][i] = i;
            for (int i = 0; i < result.Length; i++)
                result[i][0] = i;
            return result;
        }

        private void PopulateMatrix(int[][] result)
        {
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < b.Length; j++)
                {
                    int best = Min(result[i][j], result[i + 1][j], result[i][j + 1]);
                    int delta = a[i] == b[j] ? 0 : 1;
                    result[i + 1][j + 1] = best + delta;
                }
        }

        public static int Min(int x, int y, int z)
        {
            return Math.Min(x, Math.Min(y, z));
        }
    }
}
