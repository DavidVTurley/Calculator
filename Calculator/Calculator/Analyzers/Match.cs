namespace Calculator.Analyzers;

public class Match
{
    public TokenType TokenType;
    public System.Text.RegularExpressions.Match RegexMatch;
    public Match(System.Text.RegularExpressions.Match match, TokenType tokenType)
    {
        RegexMatch = match;
        TokenType = tokenType;
    }
}