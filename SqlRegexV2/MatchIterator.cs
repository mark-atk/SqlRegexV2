using System.Collections;
using System.Text.RegularExpressions;

namespace SqlRegexV2
{
    internal class MatchIterator : IEnumerable
    {
        private readonly Regex _regex;

        private readonly string _input;

        public MatchIterator(string input, string pattern)
        {
            _regex = new Regex(pattern, UserDefinedFunctions.Options);
            _input = input;
        }

        public IEnumerator GetEnumerator()
        {
            int num = 0;
            Match match = null;
            do
            {
                match = match?.NextMatch() ?? _regex.Match(_input);
                if (match.Success)
                {
                    yield return new MatchNode(++num, match.Value);
                }
            }
            while (match.Success);
        }
    }
}
