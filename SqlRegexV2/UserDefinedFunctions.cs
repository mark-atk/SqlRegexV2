using Microsoft.SqlServer.Server;
using System.Collections;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace SqlRegexV2
{
    public static class UserDefinedFunctions
    {
        public static readonly RegexOptions Options = RegexOptions.Singleline;

        [SqlFunction]
        public static SqlBoolean RegexMatch(SqlString input, SqlString pattern)
        {
            Regex regex = new Regex(pattern.Value, UserDefinedFunctions.Options);
            return regex.IsMatch(input.Value);
        }

        [SqlFunction]
        public static SqlString RegexGroup(SqlString input, SqlString pattern, SqlString name)
        {
            Regex regex = new Regex(pattern.Value, UserDefinedFunctions.Options);
            Match match = regex.Match(input.Value);
            return match.Success ? new SqlString(match.Groups[name.Value].Value) : SqlString.Null;
        }

        [SqlFunction(FillRowMethodName = "FillMatchRow", TableDefinition = "[Index] int,[Text] nvarchar(max)")]
        public static IEnumerable RegexGroups(SqlString input, SqlString pattern, SqlString name)
        {
            return new MatchGroupIterator(input.Value, pattern.Value, name.Value);
        }

        [SqlFunction(FillRowMethodName = "FillMatch2Rows", TableDefinition = "[Index] int, [Text1] nvarchar(max), [Text2] nvarchar(max)")]
        public static IEnumerable RegexGroups2(SqlString input, SqlString pattern, SqlString name1, SqlString name2)
        {
            return new MatchGroupIterator(input.Value, pattern.Value, name1.Value, name2.Value);
        }

        [SqlFunction(FillRowMethodName = "FillMatchRow", TableDefinition = "[Index] int,[Text] nvarchar(max)")]
        public static IEnumerable RegexMatches(SqlString input, SqlString pattern)
        {
            return new MatchIterator(input.Value, pattern.Value);
        }

        public static void FillMatchRow(object data, out SqlInt32 index, out SqlChars text)
        {
            MatchNode matchNode = (MatchNode)data;
            index = new SqlInt32(matchNode.Index);
            text = new SqlChars(matchNode.Value.ToCharArray());
        }

        public static void FillMatch2Rows(object data, out SqlInt32 index, out SqlChars text1, out SqlChars text2)
        {
            Match2Node match2Node = (Match2Node)data;
            index = new SqlInt32(match2Node.Index);
            text1 = new SqlChars(match2Node.Value1.ToCharArray());
            text2 = new SqlChars(match2Node.Value2.ToCharArray());
        }
    }
}
