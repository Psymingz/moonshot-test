using MoonShot.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonShot.Models
{
    public class Node : INode<int>
    {
        public int Value { get; set; }
        public INode<int> Left { get; set; }
        public INode<int> Right { get; set; }

        public bool IsEven
        {
            get
            {
                return Value % 2 == 0;
            }
        }

        public Node(int value)
        {
            Value = value;
        }
    }
}
