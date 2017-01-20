using Microsoft.VisualStudio.TestTools.UnitTesting;
using str_diff;

namespace str_diff_test
{
    [TestClass]
    public class IndelHtmlConverterTest
    {
        [TestMethod]
        public void IndelToHtml()
        {
            AssertHtml("");
            AssertHtml("<span class=\"same\">abc</span>", new Edit("=", "abc"));
            AssertHtml("<span class=\"delete\">abc</span>", new Edit("-", "abc"));
            AssertHtml("<span class=\"insert\">abc</span>", new Edit("+", "abc"));

            string html = "<span class=\"same\">abc</span><span class=\"delete\">abc</span><span class=\"insert\">abc</span>";
            AssertHtml(html, new Edit("=", "abc"), new Edit("-", "abc"), new Edit("+", "abc"));
        }

        [TestMethod]
        public void InnerHtmlIsEncoded()
        {
            AssertHtml("<span class=\"same\">&lt;br&gt;</span>", new Edit("=", "<br>"));
        }

        private static void AssertHtml(string expected, params Edit[] edits)
        {
            InDel indel = new InDel(edits);
            IndelHtmlConverter toHtml = new IndelHtmlConverter();
            string actual = toHtml.Convert(indel);
            Assert.AreEqual(expected, actual);
        }
    }
}
