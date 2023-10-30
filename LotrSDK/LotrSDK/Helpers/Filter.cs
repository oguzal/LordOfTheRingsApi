namespace LotrSDK.Helpers
{
    public class Filter
    {
        public string Value { get; set; }
        public string OperatorString { get; set; }
        public string Field { get; set; }
        public Filter(string value, Operator op, string field)
        {
            Value = value;
            OperatorString = OperatorType[op.ToString()];
            Field = field;
        }
        public string FilterAsString
        {
            get
            {
                return $"{Field}{OperatorString}{Value}";
            }
        }

        public enum Operator { Equal, NotEqual, GreaterThan, GreaterThanOrEqual, LessThan, LessThanOrEqual }

        public static Dictionary<string, string> OperatorType = new Dictionary<string, string>()
            {
                { "Equal", "=" },
                { "Not Equal", "!=" },
                { "GreaterThan", ">" },
                { "GreaterThanOrEqual", ">=" },
                { "LessThan", "<" },
                { "LessThanOrEqual", "<=" },
            };


    }
}
