using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonShot.Models
{
    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

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
