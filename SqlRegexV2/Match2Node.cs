
namespace SqlRegexV2
{
    internal class Match2Node
    {
        public int Index { get; }

        public string Value1 { get; }

        public string Value2 { get; }

        public Match2Node(int index, string value1, string value2)
        {
            Index = index;
            Value1 = value1;
            Value2 = value2;
        }
    }
}
