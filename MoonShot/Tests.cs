using MoonShot.Models;
using MoonShot.Models.Interfaces;
using MoonShot.Parser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MoonShot
{
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// Test for parsing input.txt into a tree or graph structure and finding the path with the largest sum
        /// Please note: I initially assumed that notes in a binary tree only could have a single parent,
        /// but I found that this assumption didn't resonate with task description & examples.
        /// Hence I have added the "canHaveMultipleParents" bool to toggle this on and off.
        /// </summary>
        [Test]
        public void Tree()
        {
            var parser = new TreeParser<Node, int>();
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "input.txt");
            var tree = parser.Parse(path, canHaveMultipleParents: true);
            bool isOptimalPath(List<INode<int>> l1, List<INode<int>> l2) => l1.Sum(w => w.Value) > l2.Sum(w => w.Value);
            bool canTraverse(INode<int> n1, INode<int> n2)
            {
                var n1IsEven = n1.Value % 2 == 0;
                var n2IsEven = n2.Value % 2 == 0;
                return n1IsEven && !n2IsEven || !n1IsEven && n2IsEven;
            }

            tree.Traverse(isOptimalPath, canTraverse);
            Console.WriteLine($"(Sum: {tree.CurrentOptimalPath.Sum(s => s.Value)}) { string.Join(" ", tree.CurrentOptimalPath.Select(s => s.Value.ToString()))}");
        }
    }
}
