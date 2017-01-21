using System;
using System.Text;

namespace str_diff
{
    class EditStringBuilder
    {
        private readonly int[][] matrix;
        private readonly string source;
        private readonly string target;

        private int currentRow;
        private int currentColumn;
        private StringBuilder result;

        public EditStringBuilder(int[][] matrix, string source, string target)
        {
            this.matrix = matrix;
            this.source = source;
            this.target = target;
            currentRow = matrix.Length - 1;
            currentColumn = matrix[0].Length - 1;
            result = new StringBuilder();
        }

        public string Build()
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
            return currentRow > 0;
        }

        private bool HasCellsLeft()
        {
            return currentColumn > 0;
        }

        private int ValueAbove()
        {
            return matrix[currentRow - 1][currentColumn];
        }

        private int ValueLeft()
        {
            return matrix[currentRow][currentColumn - 1];
        }

        private int ValueDiagonal()
        {
            return matrix[currentRow - 1][currentColumn - 1];
        }

        private int ValueHere()
        {
            return matrix[currentRow][currentColumn];
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
            currentRow--;
        }

        private void RecordInsert()
        {
            result.Append("+");
            MoveLeft();
        }

        private void MoveLeft()
        {
            currentColumn--;
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
