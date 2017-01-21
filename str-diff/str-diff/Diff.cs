using System.Collections.Generic;
using System.Text;

namespace str_diff
{
    public class Diff
    {
        private int[][] matrix;
        private string a;
        private string b;

        public Diff(int[][] matrix, string a, string b)
        {
            this.matrix = matrix;
            this.a = a;
            this.b = b;
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
            return new EditStringBuilder(matrix, a, b).EditStringA();
        }

        public string EditStringB()
        {
            StringBuilder result = new StringBuilder();
            foreach(char c in EditStringA())
            {
                if (c == '+')
                    result.Append('-');
                else if (c == '-')
                    result.Append('+');
                else
                    result.Append(c);
            }
            return result.ToString();
        }

        public InDel InDel()
        {
            Queue<char> edit = new Queue<char>(EditStringA().ToCharArray());
            Queue<char> a = new Queue<char>(this.a.ToCharArray());
            Queue<char> b = new Queue<char>(this.b.ToCharArray());

            IList<Edit> edits = new List<Edit>();

            while (edit.Count > 0)
            {
                char thisOp = edit.Peek();
                if (thisOp == '=')
                    AppendEquals(edit, a, b, edits);
                else
                    AppendChange(edit, a, b, edits);
            }

            return new InDel(edits);
        }

        private static void AppendEquals(Queue<char> edit, Queue<char> a, Queue<char> b, IList<Edit> edits)
        {
            StringBuilder same = new StringBuilder();
            while (edit.Count > 0 && edit.Peek() == '=')
            {
                edit.Dequeue();
                same.Append(a.Dequeue());
                b.Dequeue();
            }
            edits.Add(new Edit("=", same.ToString()));
        }

        private static void AppendChange(Queue<char> edit, Queue<char> a, Queue<char> b, IList<Edit> edits)
        {
            StringBuilder insert = new StringBuilder();
            StringBuilder delete = new StringBuilder();
            while (edit.Count > 0 && edit.Peek() != '=')
            {
                char op = edit.Dequeue();
                if (op != '-')
                    insert.Append(b.Dequeue());
                if (op != '+')
                    delete.Append(a.Dequeue());
            }
            if (delete.Length > 0)
                edits.Add(new Edit("-", delete.ToString()));
            if (insert.Length > 0)
                edits.Add(new Edit("+", insert.ToString()));
        }
    }
}
