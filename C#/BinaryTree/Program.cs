using System;
using System.Collections.Generic;
namespace binaryTree
{
    class Program
    {
        static void Main(string[] args)
        {

            int?[] arr = new int?[] { 50, 25, 12, null, null, 37, 30, null, null,null,
                                      75, 62, null, 70, null, null, 87, null, null};
            // int?[] arr = new int?[] { 1, 2, 4, null, null, 5, null, null, 3, null, 6, null, null };
            // { 1, 2, 4, -1, -1, 5, -1, -1, 3, -1, 6, -1, -1 }
            // { 1, 2, -1, 4, -1, -1, 3, 5, -1, -1, 6, 7, -1, -1, -1 }
            //every node has atmost 2 children
            /*
               pre = 1 2 4 5 3 6
               in = 4 2 5 1 3 6
               post = 4 5 2 6 3 1
            */
            // var root = BT.CreateBT_Iterative(arr);

            // BT.PrintNodesAtKthLevel(root, 3);
            // BT.PrintNodesAtKthLevel_Preorder_Recursive(root, 2);
            //int[] test = { 50, 25, 12, -1, -1, 37, 30, -1, -1,-1,
                             //         75, 62, -1, 70, -1, -1, 87, -1, -1};
            // Node? root = BT.BuildTree_Recursive(test);
            // System.Console.WriteLine(root!.data);
            // int[] arrForDia = { 1, 2, 3, -1, -1, 4, 5, 6,-1, -1, 7, 8, -1, 9, 10, 11, -1, -1, -1, -1, -1, 12, 13, -1, 15, 16, -1, 17, -1,
            //                     18, -1, -1, -1, 14, -1, -1, 19, -1, 20, -1, -1  };
            // int[] subtree = { 4, 5, 6,-1, -1, 7, 8, -1, 9, 10, 11, -1, -1, -1, -1, -1, 12, 13, -1, 15, 16, -1, 17, -1,
            //                     18, -1, -1, -1, 14, -1, -1 };
            // Node? root = BT.BuildTree_Recursive(arrForDia);
            // BT.index = -1;
            // Node? subtreeRoot = BT.BuildTree_Recursive(subtree);
            // System.Console.WriteLine(BT.IsSubtree(root!, subtreeRoot!));
            int[][] queries = new int[16][];
            
//[[6,2],[2,1],[0,6],[0,1],[0,4],[0,1],[5,7],[5,3],[7,6],[6,7],[0,4],[4,6],[4,2],[3,7],[4,4],[5,1]]
            queries[0] = new int[2]{6,2};
            queries[1] = new int[2]{2,1};
            queries[2] = new int[2]{0,6};
            queries[3] = new int[2]{0,1};
            queries[4] = new int[2]{5,7};
            queries[5] = new int[2]{5,3};
            queries[6] = new int[2]{7,6};
            queries[7] = new int[2]{6,7};
            queries[8] = new int[2]{0,4};
            queries[9] = new int[2]{4,6};
            queries[10] = new int[2]{4,2};
            queries[11] = new int[2]{3,7};
            queries[12] = new int[2]{4,4};
            queries[13] = new int[2]{5,1};
            ColorTheArray(8,queries);
        }
public static int[] ColorTheArray(int n, int[][] queries) {
        if(n==1) return new int[1];
        int[] nums = new int[n];
        int[] res = new int[n+1];
        for(int i=0;i<queries.GetLength(0);i++)
        {
            int index = queries[i][0];
            int color = queries[i][1];
            
            nums[index] = color;
            
            int count=0;
            for(int j=0;j<n;j++)
            {
                //Console.WriteLine(nums[j]+ " "+nums[j+1]);
                if(j+1<nums.Length && nums[j]==nums[j+1] && nums[j]!=0)
                {
                    count++;
                    
                }
            }
            res[i]=count;
        }
        
        return res;
    }
    }


    class BT
    {
        //GENERATE BINARY TREE FROM GIVEN PREORDER OR POSTORDER OR INORDER
        // Does the given larger tree contain the smaller given tree
        /*
         public static void Func(Node? root)
         {

         }
        */

        public static void SumOfNodesAtKthLevel(Node root, int k)
        {

            //int internalLevel = 1;

            Queue<Tuple<Node, int>> q = new Queue<Tuple<Node, int>>();

            q.Enqueue(new Tuple<Node, int>(root!, 1));
            int? sum = 0;

            while (q.Count>0)
            {
                var first = q.Dequeue();
                if(first.Item2==k+1) break;
                if(first.Item2==k) sum+=first.Item1.data;

                if(first.Item1.leftChild!=null)
                {
                    q.Enqueue(new Tuple<Node, int>(first.Item1.leftChild,first.Item2+1));
                }
                if(first.Item1.rightChild!=null)
                {
                    q.Enqueue(new Tuple<Node, int>(first.Item1.rightChild,first.Item2+1));
                }
            }
           
            System.Console.WriteLine("\nSum " + sum);
        }

        public static bool IsSubtree(Node root1, Node root2)
        {
            // Check if the root2 tree is a subtree of root1 tree
            if (root2 == null)
            {
                return true;// a null tree is always a subtree
                //this case also covers root2==null && root1==null
            }
            if (root1 == null)
            {
                return false;
            }

            if (root1.data == root2.data)
            {
                var status = AreTreesIdentical(root1.leftChild!, root2.leftChild!);
                var status2 = AreTreesIdentical(root1.rightChild!, root2.rightChild!);
                if (status&&status2) return true;
            }

            var left = IsSubtree(root1.leftChild!, root2);
            var right = IsSubtree(root1.rightChild!, root2);

            return left || right;

        }

        public static bool AreTreesIdentical(Node root1, Node root2)
        {
            if (root1 == null && root2 == null) return true;
            if (root1 == null || root2 == null) return false;

            if (root1.data == root2.data)
            {
                bool statusLeft = AreTreesIdentical(root1.leftChild!, root2.leftChild!);
                bool statusRight = AreTreesIdentical(root1.rightChild!, root2.rightChild!);
                return statusLeft && statusRight;
            }
            return false;
        }
        public static Tuple<int, int> DiameterOfBT_Optimized(Node root)
        {
            //TC = O(N) as we are calculating height and diameter on every level instead of using the seperate height function
            if (root == null)
            {
                //item1 of tuple is diameter
                //item2 of tuple is height

                return new Tuple<int, int>(0, 0);
            }

            Tuple<int, int> diamHeightLeft = DiameterOfBT_Optimized(root.leftChild!);
            Tuple<int, int> diamHeightRight = DiameterOfBT_Optimized(root.rightChild!);

            int diamleft = diamHeightLeft.Item1;
            int diamRight = diamHeightRight.Item1;
            int heightLeft = diamHeightLeft.Item2;
            int heightRight = diamHeightRight.Item2;

            int height = Math.Max(heightLeft, heightRight) + 1;
            int diameter = Math.Max(Math.Max(diamleft, diamRight), heightLeft + heightRight + 1);

            return new Tuple<int, int>(diameter, height);
        }

        public static int DiameterOfBT(Node root)
        {

            //TC = O(N^2) as we are recusring through diameter and in every recursion we are recursing again through Height

            if (root == null)
            {
                return 0;
            }

            int diamLeftSubTree = DiameterOfBT(root.leftChild!);
            int diamRightSubTree = DiameterOfBT(root.rightChild!);
            int heightOfLeftSubtree = HeightOfBT(root.leftChild!);
            int heightOfRightSubtree = HeightOfBT(root.rightChild!);
            int diamThroughRoot = heightOfLeftSubtree + heightOfRightSubtree + 1;


            return Math.Max(Math.Max(diamLeftSubTree, diamRightSubTree), diamThroughRoot);

        }

        public static int index = -1;// drawback: cant create two trees without resetting this 
        public static Node? BuildTree_Recursive(int[] arr)
        {
            index++;
            if (arr[index] == -1)
            {
                return null;
            }

            Node newNode = new Node(arr[index]);

            newNode.leftChild = BuildTree_Recursive(arr);
            newNode.rightChild = BuildTree_Recursive(arr);

            return newNode;
        }
        public static void PrintKNodesAway(Node? root, int k)
        {
            //AMAZON
        }
        public static void PrintNodesAtKthLevel_Preorder_Recursive(Node? root, int k)
        {
            //ROOT IS AT LEVEL 0 in this approach

            if (root == null || root.data == null || k < 0)
            {
                return;
            }

            if (k == 0)
            {
                System.Console.Write(root!.data + " ");
            }

            PrintNodesAtKthLevel_Preorder_Recursive(root!.leftChild, k - 1);
            PrintNodesAtKthLevel_Preorder_Recursive(root!.rightChild, k - 1);
        }
        public static void PrintNodesAtKthLevel(Node? root, int k)
        {
            //ROOT IS AT LEVEL 1 in this approach
            if (k == 1)
            {
                System.Console.WriteLine(root!.data);
                return;
            }
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root!);
            q.Enqueue(null!);
            k--;

            while (q.Count > 0)
            {
                var first = q.Dequeue();

                if (first != null && first.data != null)
                {
                    if (first.leftChild != null && first.leftChild.data != null)
                    {
                        q.Enqueue(first.leftChild);
                    }
                    if (first.rightChild != null && first.rightChild.data != null)
                    {
                        q.Enqueue(first.rightChild);
                    }
                }
                else
                {
                    k--;
                    if (q.Count != 0) q.Enqueue(null!);
                }

                if (k == 0)
                {
                    while (q.Count > 0)
                    {
                        var node = q.Dequeue();

                        if (node != null && node.data != null)
                            System.Console.Write(node.data + " ");
                    }
                }
            }
            System.Console.WriteLine();
        }

        public static List<int> NodeToRootPath(Node? root, int nodeData)
        {
            if (root == null || root.data == null)
            {
                return new List<int>();
            }

            // BELOW WE ARE GOING LIKE ROOT, LEFT, RIGHT
            // WHICH IS PREORDER
            if (root!.data == nodeData)
            {
                return new List<int>() { (int)root.data };
            }

            var fromLeft = NodeToRootPath(root.leftChild, nodeData);
            if (fromLeft.Count > 0)
            {
                fromLeft.Add((int)root.data);
                return fromLeft;
            }
            var fromRight = NodeToRootPath(root.rightChild, nodeData);
            if (fromRight.Count > 0)
            {
                fromRight.Add((int)root.data);
                return fromRight;
            }
            return new List<int>();
        }

        public static void PreOrder_Iterative_NoPairClass(Node? root)
        {
            Stack<Node> st = new Stack<Node>();
            st.Push(root!);
            while (st.Count > 0)
            {
                Node top = st.Pop();
                System.Console.Write(top.data + " ");

                //pushing right child before left one in the stack so
                //the left one will stay on top of stack and will be accessed first
                //when popping from the stack
                if (top.rightChild != null && top.rightChild.data != null)
                {
                    st.Push(top.rightChild);
                }
                if (top.leftChild != null && top.leftChild.data != null)
                {
                    st.Push(top.leftChild);
                }

            }
        }

        public static void PreOrder_Iterative(Node? root)
        {
            Stack<Pair> stack = new Stack<Pair>();// Use Pair class as it
                                                  //cant be done without a variable
                                                  // that tracks if we have visited the leftchild
                                                  // or the rightchild or both. Just like Creation of tree
            stack.Push(new Pair(root!, 1));
            while (stack.Count > 0)
            {
                Pair top = stack.Peek();
                if (top.state == 1)
                {
                    System.Console.Write(top.node.data + " ");
                    if (top.node.leftChild != null && top.node.leftChild.data != null)
                    {
                        stack.Push(new Pair(top.node.leftChild, 1));
                    }
                    top.state++;
                }
                else if (top.state == 2)
                {
                    if (top.node.rightChild != null && top.node.rightChild.data != null)
                    {
                        stack.Push(new Pair(top.node.rightChild, 1));
                    }
                    top.state++;
                }
                else
                {
                    stack.Pop();
                }
            }
        }
        public static void InOrder_Iterative(Node? root)
        {
            Stack<Pair> stack = new Stack<Pair>();// Use Pair class as it
                                                  //cant be done without a variable
                                                  // that tracks if we have visited the leftchild
                                                  // or the rightchild or both. Just like Creation of tree
            stack.Push(new Pair(root!, 1));
            while (stack.Count > 0)
            {
                Pair top = stack.Peek();
                if (top.state == 1)
                {
                    if (top.node.leftChild != null && top.node.leftChild.data != null)
                    {
                        stack.Push(new Pair(top.node.leftChild, 1));
                    }
                    top.state++;
                }
                else if (top.state == 2)
                {
                    System.Console.Write(top.node.data + " ");

                    if (top.node.rightChild != null && top.node.rightChild.data != null)
                    {
                        stack.Push(new Pair(top.node.rightChild, 1));
                    }
                    top.state++;
                }
                else
                {
                    stack.Pop();
                }
            }
        }
        public static void PostOrder_Iterative(Node? root)
        {
            Stack<Pair> stack = new Stack<Pair>();// Use Pair class as it
                                                  //cant be done without a variable
                                                  // that tracks if we have visited the leftchild
                                                  // or the rightchild or both. Just like Creation of tree
            stack.Push(new Pair(root!, 1));
            while (stack.Count > 0)
            {
                Pair top = stack.Peek();
                if (top.state == 1)
                {
                    if (top.node.leftChild != null && top.node.leftChild.data != null)
                    {
                        stack.Push(new Pair(top.node.leftChild, 1));
                    }
                    top.state++;
                }
                else if (top.state == 2)
                {
                    if (top.node.rightChild != null && top.node.rightChild.data != null)
                    {
                        stack.Push(new Pair(top.node.rightChild, 1));
                    }
                    top.state++;
                }
                else
                {
                    System.Console.Write(top.node.data + " ");

                    stack.Pop();
                }
            }
        }

        public static void LevelOrder_WithoutAddingNulls(Node? root)
        {
            Queue<Node?> q = new Queue<Node?>();
            q.Enqueue(root!);

            while (q.Count > 0)
            {
                int totalNodesOnCurrentLevel = q.Count;
                //on every level, for every node, repeat this:
                // remove, print, AddItsChildren
                for (int i = 0; i < totalNodesOnCurrentLevel; i++)
                {
                    Node first = q.Dequeue()!;//remove
                    System.Console.Write(first.data + " ");//print

                    /* Add Children IFF they exist */
                    if (first.leftChild != null && first.leftChild.data != null)
                    {
                        q.Enqueue(first.leftChild);
                    }
                    if (first.rightChild != null && first.rightChild.data != null)
                    {
                        q.Enqueue(first.rightChild);
                    }
                }
                System.Console.WriteLine();
            }
        }
        public static void LevelOrder_InDifferentLines(Node? root)
        {
            Queue<Node?> q = new Queue<Node?>();
            q.Enqueue(root!);
            q.Enqueue(null);

            while (q.Count > 0)
            {
                Node? first = q.Dequeue();

                if (first == null)
                {
                    System.Console.WriteLine();
                    if (q.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        q.Enqueue(null);
                    }
                }
                else
                {
                    System.Console.Write(first.data + " ");
                    if (first.leftChild != null && first.leftChild.data != null)
                    {
                        q.Enqueue(first.leftChild);
                    }
                    if (first.rightChild != null && first.rightChild.data != null)
                    {
                        q.Enqueue(first.rightChild);
                    }
                }
            }

        }

        public static void LevelOrder_InSingleLine(Node? root)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root!);

            while (q.Count > 0)
            {
                Node first = q.Dequeue();
                System.Console.Write(first.data + " ");
                if (first.leftChild != null && first.leftChild.data != null)
                {
                    q.Enqueue(first.leftChild);
                }
                if (first.rightChild != null && first.rightChild.data != null)
                {
                    q.Enqueue(first.rightChild);
                }
            }
        }

        public static void PostOrder(Node? root)
        {
            if (root == null || root.data == null) return;

            PostOrder(root.leftChild);
            PostOrder(root.rightChild);
            System.Console.Write(root!.data + " ");
        }
        public static void InOrder(Node? root)
        {
            if (root == null || root.data == null) return;

            InOrder(root.leftChild);
            System.Console.Write(root!.data + " ");
            InOrder(root.rightChild);

        }

        public static void PreOrder(Node? root)
        {
            if (root == null || root.data == null) return;

            System.Console.Write(root!.data + " ");
            PreOrder(root.leftChild);
            PreOrder(root.rightChild);
        }

        public static int HeightOfBT(Node? root)
        {
            if (root == null || root.data == null) return 0;

            var heightOfLeftSubtree = HeightOfBT(root.leftChild);
            var heightOfRightSubtree = HeightOfBT(root.rightChild);

            return Math.Max(heightOfLeftSubtree, heightOfRightSubtree) + 1;
        }
        public static int MaxValueInBT(Node? root)
        {
            if (root == null || root.data == null) return Int32.MinValue;

            var maxFromLeftSubtree = MaxValueInBT(root.leftChild);
            var maxFromRightSubtree = MaxValueInBT(root.rightChild);

            return Math.Max(maxFromLeftSubtree, Math.Max((int)(root.data), maxFromRightSubtree));
        }
        public static int? SumOfAllNodes(Node? root)
        {
            if (root == null || root.data == null) return 0;

            int? sumOfNodesOfLeftSubtree = SumOfAllNodes(root.leftChild);
            int? sumOfNodesOfRighttSubtree = SumOfAllNodes(root.rightChild);
            int? ans = sumOfNodesOfLeftSubtree + sumOfNodesOfRighttSubtree + root.data;
            return ans;
        }
        public static int TotalNodesOfBT(Node? root)
        {
            if (root == null || root!.data == null) return 0;//root == null is written
                                                             // just for the sake of completeness
                                                             // or for a tree with just one null node  

            int totalNodesInLeftSubtree = TotalNodesOfBT(root.leftChild);
            int totalNodesInRightSubtree = TotalNodesOfBT(root.rightChild);

            return totalNodesInLeftSubtree + totalNodesInRightSubtree + 1;
        }
        public static void DisplayTreeLinearly(Node? root)
        {
            if (root!.data == null) return;
            System.Console.Write(root.data + " ");
            DisplayTreeLinearly(root.leftChild);
            DisplayTreeLinearly(root.rightChild);
        }
        public static Node CreateBT_Iterative(int?[] array)
        {
            Stack<Pair> stack = new Stack<Pair>();

            Node root = new Node(array[0]);//just to get rid of the warning
            Pair p = new Pair(root, 1);
            //1 -> push left child
            //2 -> push right child
            //3 -> pop

            stack.Push(p);

            int index = 1;//arr[0] already put in root


            //=========================================================
            while (stack.Count > 0)
            {
                Pair top = stack.Peek();
                if (top.state < 3)
                {
                    Node newNode = new Node(array[index]);

                    if (top.state == 1)
                    {
                        top.node.leftChild = newNode;
                    }
                    else if (top.state == 2)
                    {
                        top.node.rightChild = newNode;
                    }


                    if (array[index] != null)
                    {
                        stack.Push(new Pair(newNode, 1));
                    }
                    top.state++;
                    index++;

                }
                else
                {
                    stack.Pop();
                }
            }

            return root;

        }

    }
    class Node
    {
        public Node? leftChild;
        public Node? rightChild;
        public int? data;
        public Node(int? data)
        {
            this.data = data;
            leftChild = rightChild = default;
        }
    }

    class Pair
    {
        public Node node;
        public int state;//1 means no child yet
                         // 2 means only left child yet
                         // 3 both left and right present


        public Pair(Node node, int state)
        {
            this.node = node;
            this.state = state;
        }
    }
    //check if two trees are same.
    //diameter of tree
    //Level Order Traversal
    // create only a Tree, not a Binary tree
    // Binary Heap
    // BST
    // invert a BT
    // height of BT iteratively using queue
    // Iterative traversals Pre, Post , In, Morris Traversal
    // Avl tree, balanced tree, red-black tree, Splay tree, Trie, Heap
    //find sum of all nodes of a tree
}

//dumped code
/*
 static int index = -1;

        public static Node CreateBT(int[] arr)
        {
            index++;
            if (arr[index] == -1)
            {
                return null;
            }
            Node newNode = new Node(arr[index]);
            newNode.leftChild = CreateBT(arr);
            newNode.rightChild = CreateBT(arr);
            return newNode;
        }

        public static void PreOrder(Node head)
        {

            if (head == null)
            {
                return;
            }

            System.Console.Write(head.data + " ");
            PreOrder(head.leftChild);
            PreOrder(head.rightChild);

        }
        public static void InOrder(Node head)
        {

            if (head == null)
            {
                return;
            }

            InOrder(head.leftChild);
            System.Console.Write(head.data + " ");
            InOrder(head.rightChild);

        }
        public static void PostOrder(Node head)
        {

            if (head == null)
            {
                return;
            }

            PostOrder(head.leftChild);
            PostOrder(head.rightChild);
            System.Console.Write(head.data + " ");

        }
        public static int HeightOfTree(Node root)
        {

            if (root == null)
            {
                return 0;
            }

            int heightOfLeftTree = HeightOfTree(root.leftChild);
            int heightOfRightTree = HeightOfTree(root.rightChild);
            return Math.Max(heightOfLeftTree, heightOfRightTree) + 1;
        }
        public static void BFS(Node root)
        {
            var q = new Queue<Node>();
            q.Enqueue(root);
            q.Enqueue(null);
            while (q.Count != 0)
            {
                Node tempNode = q.Dequeue();
                if (tempNode == null)
                {
                    if (q.Count == 0)
                        break;
                    else
                    {
                        System.Console.WriteLine();
                        q.Enqueue(null);
                    }
                }
                else
                {
                    System.Console.Write(tempNode.data + " ");
                    if (tempNode.leftChild != null) q.Enqueue(tempNode.leftChild);
                    if (tempNode.rightChild != null) q.Enqueue(tempNode.rightChild);
                }
            }
        }

        public static int MinDepth(Node root)
        {
            if (root == null) return 0;
            int minLeft = MinDepth(root.leftChild);
            int minRight = MinDepth(root.rightChild);
            
            return Math.Min(minLeft, minRight) + 1;

        }

        public static int MaxElementInBT(Node root)
        {

            if (root == null)
            {
                return Int32.MinValue;
            }

            int maxFromLeft = MaxElementInBT(root.leftChild);
            int maxFromRight = MaxElementInBT(root.rightChild);

            return Math.Max(maxFromLeft, Math.Max(maxFromRight, root.data));// finding max between root, its left child and its right child recursively
        }
*/