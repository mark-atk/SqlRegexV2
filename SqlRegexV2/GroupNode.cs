using System;

namespace SqlRegexV2
{
    internal class GroupNode
    {
        public int Index { get; private set; }

        public string Name { get; private set; }

        public string Value { get; private set; }

        public GroupNode(int index, string group, string value)
        {
            this.Index = index;
            this.Name = group;
            this.Value = value;
        }
    }
}
