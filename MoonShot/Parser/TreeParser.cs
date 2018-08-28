using MoonShot.Models;
using MoonShot.Models.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace MoonShot.Parser
{
    public class TreeParser<TNode, TValue> where TNode : INode<TValue>, new() where TValue : IConvertible
    {
        public BinaryTree<TValue> Parse(string filepath, bool canHaveMultipleParents = false)
        {
            var text = File.ReadAllLines(filepath).ToList();
            var rowsOfNodes = text.Select(s => s.Split(' ')).ToArray();
            return new BinaryTree<TValue>(ParseNode(0, 0, rowsOfNodes, canHaveMultipleParents));
        }

        private TNode ParseNode(int i, int j, string[][] rowsOfNodes, bool canHaveMultipleParents)
        {
            var value = (TValue)Convert.ChangeType(rowsOfNodes[i][j], typeof(TValue));
            var newNode = new TNode
            {
                Value = value
            };

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
