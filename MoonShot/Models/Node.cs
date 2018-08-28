using MoonShot.Models.Interfaces;

namespace MoonShot.Models
{
    public class Node : INode<int>
    {
        public Node()
        {

        }

        public int Value { get; set; }
        public INode<int> Left { get; set; }
        public INode<int> Right { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }
}
