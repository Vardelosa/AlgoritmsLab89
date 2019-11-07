using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsLab8
{
    class Node
    {
        public Node(int value)
        {
            Data = value;
        }

        public Node left { get; set; }
        public Node right { get; set; }
        public int Data { get; private set; }

    }
}
