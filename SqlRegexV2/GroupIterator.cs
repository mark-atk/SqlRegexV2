using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace SqlRegexV2
{
    internal class GroupIterator : IEnumerable
    {
        private readonly Regex _regex;

        private readonly string _input;

        public GroupIterator(string input, string pattern)
        {
            _regex = new Regex(pattern, UserDefinedFunctions.Options);
            _input = input;
        }

        public IEnumerator GetEnumerator()
        {
            int num = 0;
            Match match = null;
            string[] groupNames = _regex.GetGroupNames();
            do
            {
                num++;

                //match = match?.NextMatch() ?? _regex.Match(_input);
                if (match != null)
                {
                    match = match.NextMatch();
                }
                if (match == null)
                {
                    match = _regex.Match(_input);
                }

                if (match.Success)
                {
                    try
                    {
                        string[] array = groupNames;
                        foreach (string text in array)
                        {
                            Group group = match.Groups[text];
                            if (@group.Success)
                            {
                                yield return new GroupNode(num, text, @group.Value);
                            }
                        }
                    }
                    finally
                    {
                    }
                }
            }
            while (match.Success);
        }
    }
}
