//Neema Kanyi - 0810436
using System;
using System.Collections.Generic;

namespace BinaryTreeProblem3
{
    // Part B Node
    public class Node
    {
        public int data;
        public Node? left;
        public Node? right;

        public Node(int value)
        {
            data = value;
            left = null;
            right = null;
        }
    }

    public class BinaryTree
    {
        public static int maxSum = int.MinValue;

        public static int FindMaxPath(Node? root)
        {
            if (root == null)
                return int.MinValue;

            if (root.left == null && root.right == null)
                return root.data;

            int leftSum = FindMaxPath(root.left);
            int rightSum = FindMaxPath(root.right);

            if (root.left != null && root.right != null)
            {
                int total = leftSum + rightSum + root.data;
                if (total > maxSum)
                    maxSum = total;
                return Math.Max(leftSum, rightSum) + root.data;
            }

            return root.left == null ? rightSum + root.data : leftSum + root.data;
        }
    }

    // Part C TreeNode
    public class TreeNode
    {
        public int Val;
        public TreeNode? Left;
        public TreeNode? Right;

        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            Val = val;
            Left = left;
            Right = right;
        }
    }

    public class BinaryTreeWithPath
    {
        public static int maxSum = int.MinValue;
        public static List<int> maxPath = new List<int>();

        public static (int, List<int>) MaxPathSum(TreeNode? root)
        {
            maxSum = int.MinValue;
            maxPath.Clear();
            MaxPathSumHelper(root);
            return (maxSum, maxPath);
        }

        private static (int, List<int>) MaxPathSumHelper(TreeNode? root)
        {
            if (root == null)
                return (int.MinValue, new List<int>());

            if (root.Left == null && root.Right == null)
                return (root.Val, new List<int> { root.Val });

            var (leftSum, leftPath) = MaxPathSumHelper(root.Left);
            var (rightSum, rightPath) = MaxPathSumHelper(root.Right);

            if (root.Left != null && root.Right != null)
            {
                int total = leftSum + rightSum + root.Val;
                if (total > maxSum)
                {
                    maxSum = total;
                    maxPath.Clear();
                    maxPath.AddRange(leftPath);
                    maxPath.Add(root.Val);
                    maxPath.AddRange(rightPath);
                }

                if (leftSum > rightSum)
                {
                    var pathToReturn = new List<int>(leftPath);
                    pathToReturn.Add(root.Val);
                    return (leftSum + root.Val, pathToReturn);
                }
                else
                {
                    var pathToReturn = new List<int>(rightPath);
                    pathToReturn.Add(root.Val);
                    return (rightSum + root.Val, pathToReturn);
                }
            }

            if (root.Left != null)
            {
                var pathToReturn = new List<int>(leftPath);
                pathToReturn.Add(root.Val);
                return (leftSum + root.Val, pathToReturn);
            }
            else
            {
                var pathToReturn = new List<int>(rightPath);
                pathToReturn.Add(root.Val);
                return (rightSum + root.Val, pathToReturn);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // List of test cases for Part B and Part C
            var testCasesB = new List<Node?>
            {
                new Node(-15)
                {
                    left = new Node(5)
                    {
                        left = new Node(-8)
                        {
                            left = new Node(2),
                            right = new Node(6)
                        },
                        right = new Node(1)
                    },
                    right = new Node(6)
                    {
                        left = new Node(3),
                        right = new Node(9)
                    }
                },
                new Node(5)
                {
                    left = new Node(2),
                    right = new Node(3)
                },
                new Node(-11)
                {
                    left = new Node(-5),
                    right = new Node(-8)
                },
                new Node(21)
                {
                    left = new Node(14),
                    right = new Node(9)
                    {
                        right = new Node(5)
                    }
                },
                new Node(7),
                new Node(10)
                {
                    left = new Node(5)
                    {
                        left = new Node(3),
                        right = new Node(2)
                    }
                },
                new Node(4)
                {
                    right = new Node(6)
                    {
                        left = new Node(3),
                        right = new Node(-2)
                    }
                },
                new Node(1)
                {
                    left = new Node(2)
                    {
                        left = new Node(4),
                        right = new Node(5)
                    },
                    right = new Node(3)
                    {
                        left = new Node(6),
                        right = new Node(7)
                    }
                },
                new Node(0)
                {
                    left = new Node(-3)
                    {
                        left = new Node(0)
                    },
                    right = new Node(5)
                    {
                        right = new Node(2)
                    }
                },
                new Node(10)
                {
                    left = new Node(2)
                    {
                        left = new Node(20),
                        right = new Node(1)
                    },
                    right = new Node(10)
                    {
                        right = new Node(-25)
                        {
                            left = new Node(3),
                            right = new Node(4)
                        }
                    }
                }
            };

            var testCasesC = new List<TreeNode?>
            {
                // same structure as testCasesB, but TreeNode objects
                new TreeNode(-15)
                {
                    Left = new TreeNode(5)
                    {
                        Left = new TreeNode(-8)
                        {
                            Left = new TreeNode(2),
                            Right = new TreeNode(6)
                        },
                        Right = new TreeNode(1)
                    },
                    Right = new TreeNode(6)
                    {
                        Left = new TreeNode(3),
                        Right = new TreeNode(9)
                    }
                },
                new TreeNode(5)
                {
                    Left = new TreeNode(2),
                    Right = new TreeNode(3)
                },
                new TreeNode(-11)
                {
                    Left = new TreeNode(-5),
                    Right = new TreeNode(-8)
                },
                new TreeNode(21)
                {
                    Left = new TreeNode(14),
                    Right = new TreeNode(9)
                    {
                        Right = new TreeNode(5)
                    }
                },
                new TreeNode(7),
                new TreeNode(10)
                {
                    Left = new TreeNode(5)
                    {
                        Left = new TreeNode(3),
                        Right = new TreeNode(2)
                    }
                },
                new TreeNode(4)
                {
                    Right = new TreeNode(6)
                    {
                        Left = new TreeNode(3),
                        Right = new TreeNode(-2)
                    }
                },
                new TreeNode(1)
                {
                    Left = new TreeNode(2)
                    {
                        Left = new TreeNode(4),
                        Right = new TreeNode(5)
                    },
                    Right = new TreeNode(3)
                    {
                        Left = new TreeNode(6),
                        Right = new TreeNode(7)
                    }
                },
                new TreeNode(0)
                {
                    Left = new TreeNode(-3)
                    {
                        Left = new TreeNode(0)
                    },
                    Right = new TreeNode(5)
                    {
                        Right = new TreeNode(2)
                    }
                },
                new TreeNode(10)
                {
                    Left = new TreeNode(2)
                    {
                        Left = new TreeNode(20),
                        Right = new TreeNode(1)
                    },
                    Right = new TreeNode(10)
                    {
                        Right = new TreeNode(-25)
                        {
                            Left = new TreeNode(3),
                            Right = new TreeNode(4)
                        }
                    }
                }
            };

            // Run Part B
            Console.WriteLine("Part B - Max Sum Only");
            for (int i = 0; i < testCasesB.Count; i++)
            {
                BinaryTree.maxSum = int.MinValue;
                BinaryTree.FindMaxPath(testCasesB[i]);
                Console.WriteLine($"Test Case {i + 1}: Maximum sum = {BinaryTree.maxSum}");
            }

            // Run Part C
            Console.WriteLine("\nPart C - Max Sum and Path");
            for (int i = 0; i < testCasesC.Count; i++)
            {
                var (sum, path) = BinaryTreeWithPath.MaxPathSum(testCasesC[i]);
                Console.WriteLine($"Test Case {i + 1}: Maximum sum = {sum}");
                Console.WriteLine($"Path = {string.Join(" -> ", path)}\n");
            }
        }
    }
}
