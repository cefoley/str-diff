using System;
using System.Text;

namespace str_diff
{
    class EditStringBuilder
    {
        private readonly int[][] matrix;
        private readonly string a;
        private readonly string b;

        private int i;
        private int j;
        private StringBuilder result;

        public EditStringBuilder(int[][] matrix, string a, string b)
        {
            this.matrix = matrix;
            this.a = a;
            this.b = b;
            i = matrix.Length - 1;
            j = matrix[0].Length - 1;
            result = new StringBuilder();
        }

        public string EditStringA()
        {
            while (IsNotAtEdgeOfMatrix())
                RecordOperationsFromMiddleOfMatrix();

            RecordRemainingDeletes();
            RecordRemainingInserts();

            return EditString();
        }

        private bool IsNotAtEdgeOfMatrix()
        {
            return HasCellsAbove() && HasCellsLeft();
        }

        private void RecordOperationsFromMiddleOfMatrix()
        {
            if (IsSame())
                RecordSame();
            else if (IsInsert())
                RecordInsert();
            else if (IsDelete())
                RecordDelete();
        }

        private void RecordRemainingDeletes()
        {
            while (HasCellsAbove())
                RecordDelete();
        }

        private void RecordRemainingInserts()
        {
            while (HasCellsLeft())
                RecordInsert();
        }

        private string EditString()
        {
            Reverse(result);
            return result.ToString();
        }

        private bool IsSame()
        {
            return ValueDiagonal() == ValueHere() && ValueHere() <= NextMin();
        }

        private bool IsInsert()
        {
            return ValueLeft() == NextMin();
        }

        private bool IsDelete()
        {
            return ValueAbove() == NextMin();
        }

        private int NextMin()
        {
            return Math.Min(ValueAbove(), ValueLeft());
        }

        private bool HasCellsAbove()
        {
            return i > 0;
        }

        private bool HasCellsLeft()
        {
            return j > 0;
        }

        private int ValueAbove()
        {
            return matrix[i - 1][j];
        }

        private int ValueLeft()
        {
            return matrix[i][j - 1];
        }

        private int ValueDiagonal()
        {
            return matrix[i - 1][j - 1];
        }

        private int ValueHere()
        {
            return matrix[i][j];
        }

        private void RecordSame()
        {
            result.Append("=");
            MoveUp();
            MoveLeft();
        }

        private void RecordDelete()
        {
            result.Append("-");
            MoveUp();
        }

        private void MoveUp()
        {
            i--;
        }

        private void RecordInsert()
        {
            result.Append("+");
            MoveLeft();
        }

        private void MoveLeft()
        {
            j--;
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
