using MoonShot.Models;
using System.IO;
using System.Linq;

namespace MoonShot.Parser
{
    public class TreeParser
    {
        public BinaryTree<int> Parse(string filepath, bool canHaveMultipleParents = false)
        {
            var text = File.ReadAllLines(filepath).ToList();
            var rowsOfNodes = text.Select(s => s.Split(' ')).ToArray();
            return new BinaryTree<int>(ParseNode(0, 0, rowsOfNodes, canHaveMultipleParents));
        }

        private Node ParseNode(int i, int j, string[][] rowsOfNodes, bool canHaveMultipleParents)
        {
            var value = int.Parse(rowsOfNodes[i][j]);
            var newNode = new Node(value);
            var nextIndex = i + 1;
            if (i + 1 < rowsOfNodes.Length)
            {
                var horizontalLeft = j * (canHaveMultipleParents ? 1 : 2);
                var horizontalRight = j * (canHaveMultipleParents ? 1 : 2) + 1;
                if (horizontalLeft < rowsOfNodes[nextIndex].Length)
                {
                    newNode.Left = ParseNode(nextIndex, horizontalLeft, rowsOfNodes, canHaveMultipleParents);
                }
                if (horizontalRight < rowsOfNodes[nextIndex].Length)
                {
                    newNode.Right = ParseNode(nextIndex, horizontalRight, rowsOfNodes, canHaveMultipleParents);
                }
            }

            return newNode;
        }
    }
}
