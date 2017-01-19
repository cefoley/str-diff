using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace str_diff
{
    [TestClass]
    public class EditDistanceTest
    {
        private void AssertMatrix(string expected, string a, string b)
        {
            EditDistance distance = new EditDistance(a, b);
            Diff diff = distance.Diff();
            string actual = DiffMatrixString(diff);
            Assert.AreEqual(expected, actual);
        }

        private string DiffMatrixString(Diff diff)
        {
            int[][] matrix = diff.Matrix();
            string joined = string.Join("|", matrix.Select(row => string.Join(",", row)));
            return "{" + joined + "}";
        }

        [TestMethod]
        public void DiffTests()
        {
            AssertMatrix("{0}", "", "");
        }
    }
}
