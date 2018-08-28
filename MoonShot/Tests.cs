using MoonShot.Models;
using MoonShot.Parser;
using NUnit.Framework;
using System;
using System.Diagnostics;
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
        /// Hence I have added the "canHaveMultipleParents" boolean to toggle this on and off.
        /// </summary>
        [Test]
        public void Tree()
        {
            var parser = new TreeParser();
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "input.txt");
            var tree = parser.Parse(path, canHaveMultipleParents: true);
            Func<Node, Node, bool> canTraverse = (Node n1, Node n2) => n1.IsEven && !n2.IsEven || !n1.IsEven && n2.IsEven;
            tree.Traverse(canTraverse);
            Console.WriteLine($"(Sum: {tree.CurrentLongestPath.Sum(s => s.Value)}) { string.Join(" ", tree.CurrentLongestPath.Select(s => s.Value.ToString()))}");
        }
    }
}
