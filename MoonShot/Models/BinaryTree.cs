using MoonShot.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoonShot.Models
{
    public class BinaryTree<T>
    {
        public List<INode<T>> CurrentOptimalPath = new List<INode<T>>();
        private Func<INode<T>, INode<T>, bool> CanTraverse = (INode<T> n1, INode<T> n2) => true;
        private Func<List<INode<T>>, List<INode<T>>, bool> IsOptimalPath = (List<INode<T>> l1, List<INode<T>> l2) => false;

        public BinaryTree(INode<T> root)
        {
            Root = root;
        }

        private INode<T> Root { get; set; }

        public void Traverse(Func<List<INode<T>>, List<INode<T>>, bool> isOptimalPath = null, 
            Func<INode<T>, INode<T>, bool> canTraverse = null)
        {
            CanTraverse = canTraverse ?? CanTraverse;
            IsOptimalPath = isOptimalPath ?? IsOptimalPath;
            Traverse(Root, new List<INode<T>>());
        }

        private void Traverse(INode<T> node, List<INode<T>> path)
        {
            path.Add(node);
            var returnList = new List<List<INode<T>>>();
            if (node.Left != null && CanTraverse(node, node.Left))
            {
                var leftList = new List<INode<T>>(path);
                returnList.Add(leftList);
                Traverse(node.Left, leftList);
            }

            if (node.Right != null && CanTraverse(node, node.Right))
            {
                var rightList = new List<INode<T>>(path);
                returnList.Add(rightList);
                Traverse(node.Right, rightList);
            }

            if (IsOptimalPath(path, CurrentOptimalPath))
            {
                CurrentOptimalPath = path;
            }
        }
    }
}
