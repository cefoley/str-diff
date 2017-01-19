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
    }
}
