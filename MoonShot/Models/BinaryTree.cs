using System;
using System.Collections.Generic;
using System.Linq;

namespace MoonShot.Models
{
    public class BinaryTree
    {
        public BinaryTree(Node root)
        {
            Root = root;
        }

        private Node Root { get; set; }
        private Func<Node, Node, bool> CanTraverse = (Node n1, Node n2) => true;

        public List<List<Node>> Paths = new List<List<Node>>();
        public List<Node> CurrentLongestPath = new List<Node>();

        public void Traverse(Func<Node, Node, bool> canTraverse = null)
        {
            if (canTraverse != null)
            {
                CanTraverse = canTraverse;
            }

            Traverse(Root, new List<Node>());
        }

        private void Traverse(Node node, List<Node> path)
        {
            path.Add(node);
            var returnList = new List<List<Node>>();
            if (node.Left != null && CanTraverse(node, node.Left))
            {
                var leftList = new List<Node>(path);
                returnList.Add(leftList);
                Traverse(node.Left, leftList);
            }

            if (node.Right != null && CanTraverse(node, node.Right))
            {
                var rightList = new List<Node>(path);
                returnList.Add(rightList);
                Traverse(node.Right, rightList);
            }

            if (node.Left == null || node.Right == null)
            {
                Paths.Add(path);
            }
            if (path.Sum(s => s.Value) > CurrentLongestPath.Sum(s => s.Value))
            {
                CurrentLongestPath = path;
            }
        }
    }
}
