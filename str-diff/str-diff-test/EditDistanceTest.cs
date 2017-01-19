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
        [TestMethod]
        public void MatrixTest()
        {
            AssertMatrix("{0}", "", "");
            AssertMatrix("{0,1|1,0}", "a", "a");
            AssertMatrix("{0,1|1,1}", "a", "b");
            AssertMatrix("{0,1,2|1,0,1|2,1,0}", "ab", "ab");
            AssertMatrix("{0,1,2|1,0,1|2,1,1}", "ab", "ac");
            AssertMatrix("{0,1,2|1,1,2|2,2,1}", "ab", "xb");
            AssertMatrix("{0,1,2|1,1,2|2,2,2}", "ab", "xy");
            AssertMatrix("{0,1|1,0|2,1}", "ab", "a");
            AssertMatrix("{0,1,2|1,0,1}", "a", "ab");
        }

        private void AssertMatrix(string expected, string a, string b)
        {
            string message = string.Format("Diff {0} & {1}", a, b);
            EditDistance distance = new EditDistance(a, b);
            Diff diff = distance.Diff();
            string actual = DiffMatrixString(diff);
            Assert.AreEqual(expected, actual, message);
        }

        private string DiffMatrixString(Diff diff)
        {
            int[][] matrix = diff.Matrix();
            string joined = string.Join("|", matrix.Select(row => string.Join(",", row)));
            return "{" + joined + "}";
        }

    }
}
