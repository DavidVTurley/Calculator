using System.Text.RegularExpressions;
using Calculator.Tokenizer;

namespace Calculator.Analyzers;

public class Analyzer
{
    public System.Text.RegularExpressions.Regex Regex { get; }
    public TokenType TokenType { get; }
    public Int32 Precidence { get; }
    public Analyzer(TokenType tokenTypeType, Int32 precidence, String regularExpression)
    {
        TokenType = tokenTypeType;
        Regex = new Regex(regularExpression, RegexOptions.Compiled);
        Precidence = precidence;
    }

    static List<(MatchCollection matchCollection, Analyzers.TokenType type)> GetMatchCollections(String input, List<Analyzer> analyzers)
    {
        List<(MatchCollection matchCollection, Analyzers.TokenType type)> matches = new();
        foreach (Analyzer analyzer in analyzers)
        {
            matches.Add((analyzer.Regex.Matches(input), analyzer.TokenType));
        }

        return matches;
    }

    public static List<Match> GetSortedTokens(String input, List<Analyzer> analyzers)
    {
        List<(MatchCollection matchCollection, Analyzers.TokenType type)> matches = GetMatchCollections(input, analyzers);

        List<Match> sortedMatches = new();
        foreach ((MatchCollection? matchCollections, TokenType type) in matches)
        {
            foreach (System.Text.RegularExpressions.Match match in matchCollections)
            {
                sortedMatches.Add(new Match(match, type));
            }
        }

        return SortMatches(sortedMatches);
    }

    public static List<Match> SortMatches(List<Match> matches)
    {
        Int32 listSize = matches.Count;
        Boolean sortHappend = true;
        while (sortHappend)
        {
            sortHappend = false;
            for (Int32 i = 0; i < listSize; i++)
            {
                if (i + 1 != listSize)
                {
                    if (matches[i].RegexMatch.Index < matches[i + 1].RegexMatch.Index) continue;

                    (matches[i + 1], matches[i]) = (matches[i], matches[i + 1]);
                    sortHappend = true;
                }
                else
                {
                    break;
                }
            }
        }

        return matches;
    }

















    //public Match MatchString(String input)
    //{
    //     Match match = Regex.Match(input);
         
    //     return match;
    //}

    //public static List<Match> StartAnalasys(String input, List<Analyzer> analyzers)
    //{
    //    Boolean matchFound = false;
    //    List<Match> matchCollection = new(input.Length);
    //    foreach (Char character in input.ToString())
    //    {
    //        matchFound = false;
    //        foreach (Analyzer analyzer in analyzers)
    //        {
    //            Match match = analyzer.MatchString(character.ToString());
                
    //            match.
    //            if (!match.Success) continue;
    //            matchCollection.Add(match);
    //            matchFound = true;
    //            break;
    //        }

    //        if (matchFound) continue;

    //        Console.WriteLine($"Error found in your input: {character}");
    //        Console.ReadKey();
    //        Environment.Exit(0);
    //        return new List<Match>(0);
    //    }

    //    return matchCollection;

    //}
}