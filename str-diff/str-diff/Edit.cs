namespace str_diff
{
    public class Edit
    {
        private string operation;
        private string text;

        public Edit(string operation, string text)
        {
            this.operation = operation;
            this.text = text;
        }

        public string Operation()
        {
            return operation;
        }

        public string Text()
        {
            return text;
        }
    }
}
