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
            if (value < node.Data)
            {
                if (node.left == null)
                {
                    node.left = new Node(value);
                }
                else
                {
                    StepAdd(node.left, value);
                }
            }
            if (value > node.Data)
            {
                if (node.right == null)
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

            while (current != null)
            {
                if (current.Data > value)//Если искомое меньше
                {
                    parent = current;
                    current = current.left;
                }
                else if (current.Data < value)//Если искомое больше
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
        public bool Delete(int value)
        {
            Node current, parent;

            current = Find(value, out parent);

            if (current == null)
                return false;

            count--;

            if (current.right == null)
            {
                if (parent == null)
                {
                    head = current.left;
                }
                else
                {
                    if (parent.Data > current.Data)
                    {
                        parent.left = current.left;
                    }
                    else if (parent.Data < current.Data)
                    {
                        parent.right = current.left;
                    }
                }
            }
            else if (current.right.left == null)
            {
                current.right.left = current.left;

                if (parent == null)
                {
                    head = current.left;
                }
                else
                {
                    if (parent.Data > current.Data)
                    {
                        parent.left = current.right;
                    }
                    else if (parent.Data < current.Data)
                    {
                        parent.right = current.right;
                    }
                }
            }
            else
            {
                Node leftmost = current.right.left;
                Node leftmostparent = current.right;
                while (leftmost.left != null)
                {
                    leftmostparent = leftmost;
                    leftmost = leftmost.left;
                }
                leftmostparent.left = leftmost.right;

                leftmost.left = current.left;
                leftmost.right = current.right;

                if (parent == null)
                {
                    head = current.left;
                }
                else
                {
                    if (parent.Data > current.Data)
                    {
                        parent.left = leftmost;
                    }
                    else if (parent.Data < current.Data)
                    {
                        parent.right = leftmost;
                    }
                }
            }
            return true;
        }
        public void PryamoiObhodFind(int element)
        {
            Steps = 0;
            PryamoiObhodFind(element, head);
        }
        int Steps;
        private void PryamoiObhodFind(int element, Node node)
        {
            if (node != null)
            {
                if (element == node.Data)
                {
                    Console.WriteLine($"Element '{node.Data}' has been found. Steps was made: {Steps}");
                }
                Steps++;
                PryamoiObhodFind(element, node.left);
                PryamoiObhodFind(element, node.right);
            }
        }
        public void ObratniyObhodFind(int element)
        {
            Steps = 0;
            ObratniyObhodFind(element, head);
        }

        private void ObratniyObhodFind(int element, Node node)
        {
            if (node != null)
            {
                ObratniyObhodFind(element, node.left);
                ObratniyObhodFind(element, node.right);
                if (element == node.Data)
                {
                    Console.WriteLine($"Element '{node.Data}' has been found. Steps was made: {Steps}");
                }
                Steps++;
            }
        }
        public void FindTheWayPryamoi()
        {
            Steps = 0;
            FindTheWayPryamoi(head);
        }
        private void FindTheWayPryamoi(Node node)
        {
            if (node != null)
            {
                if (node.right == null & node.left == null)
                {
                    Console.WriteLine("The way: {0}", Steps);
                    Steps = 0;
                }
                Steps++;
                FindTheWayPryamoi(node.left);
                FindTheWayPryamoi(node.right);
            }
        }
        public void FindTheWayObratniy()
        {
            Steps = 0;
            FindTheWayObratniy(head);
        }
        private void FindTheWayObratniy(Node node)
        {
            if (node != null)
            {
                FindTheWayObratniy(node.left);
                FindTheWayObratniy(node.right);
                if (node.right == null & node.left == null)
                {
                    Console.WriteLine("The way: {0}", Steps);
                    Steps = 0;
                }
                Steps++;
                
            }
        }
    }
}
