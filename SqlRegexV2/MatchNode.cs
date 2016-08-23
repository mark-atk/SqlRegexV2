using System;

namespace SqlRegexV2
{
    internal class MatchNode
    {
        public int Index { get; }

        public string Value { get; }

        public MatchNode(int index, string value)
        {
            this.Index = index;
            this.Value = value;
        }
    }
}
