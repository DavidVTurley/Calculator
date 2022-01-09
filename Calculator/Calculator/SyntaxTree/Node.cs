using Calculator.Tokenizer;

namespace Calculator.SyntaxTree;

public class Node
{
    public Node Parent { get; }
    public List<Node> Children { get; }


    public static Node CreateAbstractSyntaxTree(List<Token> tokens)
    {
        throw new NotImplementedException();
    }
}