using System.Collections;
using System.Text.RegularExpressions;

namespace SqlRegexV2
{
    class MatchGroupIterator : IEnumerable
    {
        private readonly Regex _regex;

        private readonly string _input;

        private readonly string _name;
        private readonly string _name1;
        private readonly string _name2;

        public MatchGroupIterator(string input, string pattern, string name)
        {
            _regex = new Regex(pattern, UserDefinedFunctions.Options);
            _input = input;
            _name = name;
        }

        public MatchGroupIterator(string input, string pattern, string name1, string name2)
        {
            _regex = new Regex(pattern, UserDefinedFunctions.Options);
            _input = input;
            _name1 = name1;
            _name2 = name2;
        }

        public IEnumerator GetEnumerator()
        {
            int num = 0;
            Match match = null;
            do
            {
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
                    if (_name != null)
                    {
                        yield return new MatchNode(++num, match.Groups[_name].Value);
                    }
                    
                    if(_name1 != null && _name2 !=null)
                    {
                        yield return new Match2Node(++num, match.Groups[_name1].Value, match.Groups[_name2].Value);
                    }
                }
            }
            while (match.Success);
        }
    }
}
