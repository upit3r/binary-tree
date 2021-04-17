using System;
//same like in list --> init binary tree, filled in it (add some elements), realize search procedure (is there el-t or not) and delete some elements --> show every step
namespace binarytree
{
    class Node
    {
        public int data;
        public Node parent = null;
        public Node left = null;
        public Node right = null;
        
        public Node() {}

        public Node(int data)
        {
            this.data = data;
        }
    }

    public class BinaryTree
    {
        private Node head;
        
        static void Main(string[] args) {
            BinaryTree tree = new BinaryTree();
            
            tree.add(0);
            Console.Write("add 0: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.add(9);
            Console.Write("add 9: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.add(0);
            Console.Write("add 0: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.add(8);
            Console.Write("add 8: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.add(7);
            Console.Write("add 7: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.add(14);
            Console.Write("add 14: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.add(8);
            Console.Write("add 8: ");
            tree.show(tree.head);
            Console.WriteLine();

            Node search = tree.search(14, tree.head);
            Console.Write("search 14: ");
            if (search == null) Console.WriteLine("not found");
            else Console.WriteLine("found");
            
            search = tree.search(1, tree.head);
            Console.Write("search 1: ");
            if (search == null) Console.WriteLine("not found");
            else Console.WriteLine("found");
            
            tree.remove(14);
            Console.Write("remove 14: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.remove(7);
            Console.Write("remove 7: ");
            tree.show(tree.head);
            Console.WriteLine();

            tree.remove(8);
            Console.Write("remove 8: ");
            tree.show(tree.head);
            Console.WriteLine();
        }

        private void show(Node node)
        {
            if (head == null)
            {
                Console.WriteLine("tree is empty");
                return;
            }
                
            if (node != null)
            {
                Console.Write(node.data + " ");
                show(node.left);
                show(node.right);
            }
        }
        
        private void add(int data)
        {
            if (head == null)
            {
                head = new Node(data);
                return;
            }
            
            Node current = head;
            
            while (current != null)
            {
                if (data > current.data)
                {
                    if (current.right != null)
                        current = current.right;
                    else
                    {
                        current.right = new Node(data);
                        current.right.parent = current;
                        current = current.right.right;
                    }
                }
                else
                {
                    if (current.left != null)
                        current = current.left;
                    else
                    {
                        current.left = new Node(data);
                        current.left.parent = current;
                        current = current.left.right;
                    }
                }
            }
        }

        private Node search(int data, Node node)
        {
            if (node == null || node.data == data)
                return node;

            if (data < node.data)
                return search(data, node.left);
            else
                return search(data, node.right);
        }

        private Node min(Node node)
        {
            if (node.left == null)
                return node;
            return min(node.left);
        }

        private Node next(Node node)
        {
            if (node.right != null)
                return min(node.right);
            Node parent = node.parent;
            while (parent != null && node == parent.right)
            {
                node = parent;
                parent = parent.parent;
            }

            return parent;
        }
        
        private void remove(int data)
        {
            if (head == null)
                return;

            Node node = search(data, head);
            Node parent = node.parent;

            if (node.left == null && node.right == null) 
            {
                if (parent.left == node)
                    parent.left = null;
                if (parent.right == node)
                    parent.right = null;
            } else if (node.left == null || node.right == null) 
            {
                if (node.left == null)
                {
                    if (parent.left == node)
                        parent.left = node.right;
                    else
                        parent.right = node.right;
                    node.right.parent = parent;
                }
                else
                {
                    if (parent.left == node)
                        parent.left = node.left;
                    else
                        parent.right = node.left;
                    node.left.parent = parent;
                }
            }
            else 
            {
                Node child = next(node);
                node.data = child.data;

                if (child.parent.left == child)
                {
                    child.parent.left = child.right;
                    if (child.right != null)
                        child.right.parent = child.parent;
                }
                else
                {
                    child.parent.right = child.left;
                    if (child.left != null)
                        child.right.parent = child.parent;
                }
            }
        }
        
    }
}