
using System.Text;
using System.Text.RegularExpressions;
using Calculator.Analyzers;
using Calculator.SyntaxTree;
using Calculator.Tokenizer;
using Match = Calculator.Analyzers.Match;

StringBuilder input = new("32* (6 + 2)");


List<Analyzer> Analyzers = new ()
{
    new Analyzer(TokenType.Number, 0, "[0-9]+"),
    new Analyzer(TokenType.Plus, 1, "[+]"),
    new Analyzer(TokenType.Minus, 2, "[-]"),
    new Analyzer(TokenType.Times, 3, "[*]"),
    new Analyzer(TokenType.Divided, 4, "[/]"),
    new Analyzer(TokenType.BraketOpen, 5, "[(*)]"),
    new Analyzer(TokenType.Space, 6, "[ ]"),
    new Analyzer(TokenType.Enter, 7, "[\r\n]"),
};

List<Match> sortedMatches = Analyzer.GetSortedTokens(input.ToString(), Analyzers);
List<Token> tokens = Tokenizer.GetTokens(sortedMatches);

Node nodes = Node.CreateAbstractSyntaxTree(tokens);

var v = "";
