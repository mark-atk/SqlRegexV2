
namespace SqlRegexV2
{
    internal class Match2Node
    {
        public int Index { get; private set; }

        public string Value1 { get; private set; }

        public string Value2 { get; private set; }

        public Match2Node(int index, string value1, string value2)
        {
            Index = index;
            Value1 = value1;
            Value2 = value2;
        }
    }
}
