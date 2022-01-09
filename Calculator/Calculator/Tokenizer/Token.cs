using Calculator.Analyzers;

namespace Calculator.Tokenizer;

public struct Token
{
    public TokenType Type;
    public String Value;

    public Token(TokenType tokenType, String value)
    {
        Type = tokenType;
        Value = value;
    }
}