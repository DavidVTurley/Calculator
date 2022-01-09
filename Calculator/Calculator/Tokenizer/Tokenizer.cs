using Calculator.Analyzers;

namespace Calculator.Tokenizer;

public class Tokenizer
{
    public static List<Token> GetTokens(List<Match> sortedMatches)
    {
        return new List<Token>(sortedMatches.Select(sortedMatch => new Token(sortedMatch.TokenType, sortedMatch.RegexMatch.Value)));
    }
}