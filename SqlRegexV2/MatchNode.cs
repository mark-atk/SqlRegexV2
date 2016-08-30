using System;

namespace SqlRegexV2
{
    internal class MatchNode
    {
        public int Index { get; private set; }

        public string Value { get; private set; }

        public MatchNode(int index, string value)
        {
            this.Index = index;
            this.Value = value;
        }
    }
}
