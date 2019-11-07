using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsLab8
{
    class BinaryTree
    {
        Node head;

        public int count;

        public void Add(int value)
        {
            if (head == null)
                head = new Node(value);

            else
                StepAdd(head, value);

            count++;
        }
        public void StepAdd(Node node, int value)
        {
            if(value<node.Data)
            {
                if(node.left == null)
                {
                    node.left = new Node(value);
                }
                else
                {
                    StepAdd(node.left, value);
                }
            }
            if(value>node.Data)
            {
                if(node.right==null)
                {
                    node.right = new Node(value);
                }
                else
                {
                    StepAdd(node.right, value);
                }
            }
        }
        public bool Contains(int value)
        {
            Node parent;

            return Find(value, out parent) != null;
        }
        private Node Find(int value, out Node parent)
        {
            Node current = head;

            parent = null;

            while(current!=null)
            {
                if(current.Data>value)//Если искомое меньше
                {
                    parent = current;
                    current = current.left;
                }
                else if(current.Data<value)//Если искомое больше
                {
                    parent = current;
                    current = current.right;
                }
                else
                {
                    break;
                }
            }

            return current;

        }
        public void Delete(int value)
        {
            Node current = head;
        }

    }
}
