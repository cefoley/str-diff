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
            int[][] matrix = { new int[] { 0 } };
            return new Diff(matrix);
        }
    }
}
