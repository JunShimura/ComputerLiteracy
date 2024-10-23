using System;
using System.Diagnostics;

namespace BinaryTree
{
    internal class BinaryTreeSystem
    {

        class TreeNode
        {
            public int Value;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(int value)
            {
                Value = value;
            }
        }

        class BinaryTree
        {
            public TreeNode Root;

            public void Insert(int value)
            {
                if (Root == null)
                {
                    Root = new TreeNode(value);
                }
                else
                {
                    InsertRecursively(Root, value);
                }
            }

            private void InsertRecursively(TreeNode node, int value)
            {
                if (value < node.Value)
                {
                    if (node.Left == null)
                    {
                        node.Left = new TreeNode(value);
                    }
                    else
                    {
                        InsertRecursively(node.Left, value);
                    }
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new TreeNode(value);
                    }
                    else
                    {
                        InsertRecursively(node.Right, value);
                    }
                }
            }

            public int FindRandomNode()
            {
                Random rand = new Random();
                int randValue = rand.Next(1, 10000);
                return FindNode(Root, randValue);
            }

            public int FindNode(TreeNode node, int value)
            {
                if (node == null)
                {
                    throw new Exception("Node not found");
                }

                if (value == node.Value)
                {
                    return node.Value;
                }
                else if (value < node.Value)
                {
                    return FindNode(node.Left, value);
                }
                else
                {
                    return FindNode(node.Right, value);
                }
            }
        }

        static void Main()
        {
            int[] array = new int[1000];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 10000);
            }

            BinaryTree tree = new BinaryTree();
            foreach (int value in array)
            {
                tree.Insert(value);
            }

            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                //int foundValue = tree.FindRandomNode();
                int foundValue = tree.FindNode(tree.Root, array[rand.Next(0,array.Length)]);
                Console.WriteLine($"Found Value: {foundValue}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sw.Stop();
            Console.WriteLine($"Time to find a random node: {sw.ElapsedMilliseconds} ms");
        }
    }
}
