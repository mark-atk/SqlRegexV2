using System;

namespace SqlRegexV2
{
    internal class GroupNode
    {
        public int Index { get; }

        public string Name { get; }

        public string Value { get; }

        public GroupNode(int index, string group, string value)
        {
            this.Index = index;
            this.Name = group;
            this.Value = value;
        }
    }
}
