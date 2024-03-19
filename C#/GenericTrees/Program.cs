class Program
{
    
    static void Main(string[] args)
    {
        int[] arr1 = { 10, 20, 40, 100, -1, -1, 50, -1, -1, 30, 180, 70, -1, 80, -1, 90, -1, -1, -1, 110, -1, -1 };
        int[] arr2 = { 1, 2, -1, 3, 8, 11, -1, 10, -1, 9, -1, -1, -1, 4, 7, -1, 5, 6, -1, -1, -1, -1 };
        int[] arr3 = { 10, 20, -40, 100, -1, -1, 50, -1, -1, 30, 180, -70, -1, -80, -1, 90, -1, -1, -1, 110, -1, -1 };
        TreeNode root1 = GenericTree.CreateGenericTree(arr1);
        TreeNode root2 = GenericTree.CreateGenericTree(arr2);
        TreeNode root3 = GenericTree.CreateGenericTree(arr3);
        // System.Console.WriteLine(GenericTree.AreTreesMirrorImages(root1, root2));
    }
    //      static bool ValidParenthesis(string str){
    //         bool valid = true;
    //             Stack<char> st =  new Stack<char>(str);

    //             foreach(var c in str)
    //             {
    //                 if(c=='{' || c=='[' || c=='(')
    //                 {
    //                     st.Push(c);
    //                     System.Console.WriteLine("Pushed" + c);
    //                 }
    //                 else if(c=='}')
    //                 {
    //                     char tempC = st.Pop();
    //                     System.Console.WriteLine("Popped" + tempC);

    //                     if(tempC!='{') return false;
    //                 }else if(c==']')
    //                 {
    //                     char tempC = st.Pop();
    //                     System.Console.WriteLine("Popped" + tempC);
    //                     if(tempC!='[') return false;
    //                 }
    //                 else if(c==')')
    //                 {
    //                     char tempC = st.Pop();
    //                     System.Console.WriteLine("Popped" + tempC);
    //                     if(tempC!='(') return false;
    //                 }
    //             }
    //             if(st.Count!=0) return false;
    //         return valid;
    //     }

}
class GenericTree
{
    //top view of a tree, bottom view of a tree, left/right view of a tree
    //iterative preorder should mimic the function-call-stack using a Stack
    // and try this with other traversals also
    /*
    public static void FName(TreeNode root)
    {

    }
    */
    public static int DiameterOfTree(TreeNode root)
    {
        return -1;
    }

    public static int MaxSubtreeSum(TreeNode root)
    {
        // if(root.children.Count==0){
        //     return root.data;
        // }

        return -1;
    }
    public static void KthLargestElement(TreeNode root, int k)
    {
        //after completion start optimizing it, try priority Queue
    }
    public static bool AreTreesMirrorImages(TreeNode root1, TreeNode root2)
    {
        //dont check data, just compare design of tree
        if (root1.children.Count != root2.children.Count)
        {
            return false;
        }

        for (int i = 0; i < root1.children.Count; i++)
        {
            var ans = AreTreesMirrorImages(root1.children[i], root2.children[root1.children.Count - i - 1]);
            if (ans == false) return false;
        }
        return true;
    }
    public static bool AreTreesSimilarInShape(TreeNode root1, TreeNode root2)
    {
        if (root1.children.Count != root2.children.Count)
        {
            return false;
        }

        var result = true;
        for (int i = 0; i < root1.children.Count; i++)
        {
            var ans = AreTreesSimilarInShape(root1.children[i], root2.children[i]);
            if (ans == false) return false;//could be written as --> if(!ans) return ans;
        }
        return result;
    }

    public static int DistanceBetweenTwoNodes_totalEdges(TreeNode root, int num1, int num2)
    {
        var pathForNum1 = NodeToRootPath(root, num1);
        var pathForNum2 = NodeToRootPath(root, num2);

        int i = pathForNum1.Count - 1;
        int j = pathForNum2.Count - 1;

        while (j >= 0 && i >= 0 && pathForNum1[i] == pathForNum2[j])
        {
            //when we reach the first uncommon elements between both lists, we break
            i--;
            j--;
        }
        // now we increment the indices to reach the index of last common ancestor
        i++;
        j++;
        //at this point pathForNum1[i] == pathForNum2[j] which is the last common ancestor
        return i + j;
    }

    public static int LowestCommonAncestor(TreeNode root, int num1, int num2)
    {

        var pathForNum1 = NodeToRootPath(root, num1);
        var pathForNum2 = NodeToRootPath(root, num2);

        int i = pathForNum1.Count - 1;
        int j = pathForNum2.Count - 1;

        while (j >= 0 && i >= 0 && pathForNum1[i] == pathForNum2[j])
        {
            //when we reach the first uncommon elements between both lists, we break

            i--;
            j--;
        }
        // now we increment the indices to reach the index of last common ancestor
        i++;// we can also just increment j and return pathForNum2[j], it will yield the same answer
        return pathForNum1[i];
    }

    public static List<int> NodeToRootPath(TreeNode head, int givenNodeData)
    {
        if (head.data == givenNodeData)
        {
            var list = new List<int>();
            list.Add(head.data);
            return list;
        }

        foreach (var child in head.children)
        {
            var list = NodeToRootPath(child, givenNodeData);
            if (list.Count > 0)
            {
                //if(list[0]==givenNodeData) return list;
                list.Add(head.data);
                return list;
            }
        }

        return new List<int>();
    }

    public static bool FindInTree(TreeNode root, int data)
    {
        if (root.data == data) return true;
        //if(root.data!=data && root.children.Count==0) return false;
        bool status = false;
        // System.Console.WriteLine("passing "+root.data);
        foreach (var child in root.children)
        {
            status = FindInTree(child, data);
            if (status == true) break;
        }
        return status;
    }

    public static bool RemoveAllLeavesFromTree(TreeNode root)
    {
        if (root.children.Count == 0)
        {
            //true means the node has no children
            return true;

        }
        // for (int i=0;i< root.children.Count;i++)
        // {
        //     // when we remove something from the list of children while 
        //     // iterating form 0 to list.length-1, the nodes shift left after deletion
        //     // because of this the some list items will be skipped as the elements will shift
        //     // backwards and iterator will move forward hence we can't work with 0 to length-1
        //     // for loop here. Solution: Just iterate in the reverse fashion as after deletion
        //     // because iterator is also moving leftwards and deletion also shifts the list leftwards.

        //     bool temp = RemoveAllLeavesFromTree(root.children[i]);
        //     if(temp==true) root.children.Remove(root.children[i]);
        // }
        for (int i = root.children.Count - 1; i >= 0; i--)
        {
            bool temp = RemoveAllLeavesFromTree(root.children[i]);
            if (temp == true) root.children.Remove(root.children[i]);
        }

        return false;// false means it has children


    }
    public static void RemoveAllLeavesFromTree2(TreeNode root)
    {
        for (int i = root.children.Count - 1; i >= 0; i--)// first removing the nodes which dont have children
        {
            if (root.children[i].children.Count == 0)
            {
                root.children.Remove(root.children[i]);
            }
        }
        //now going for the nodes which have children
        foreach (var child in root.children)
        {
            RemoveAllLeavesFromTree2(child);
        }

    }
    public static void MirrorAGivenTree(TreeNode root)
    {
        root.children.Reverse();
        foreach (var child in root.children)
        {
            MirrorAGivenTree(child);
        }
    }

    public static void LevelOrderZigZag(TreeNode root)
    {
        Stack<TreeNode> parentStack = new Stack<TreeNode>();
        Stack<TreeNode> childrenStack = new Stack<TreeNode>();


    }
    public static void PreOrderUsingStack(TreeNode root)
    {

    }
    public static void LevelOrder3(TreeNode root)
    {
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count != 0)
        {
            var totalNodesInCurrentLevel = q.Count;

            for (int i = 0; i < totalNodesInCurrentLevel; i++)
            {
                var node = q.Dequeue();
                System.Console.Write(node.data + " ");
                foreach (var item in node.children)
                {
                    q.Enqueue(item);
                }
            }
            System.Console.WriteLine();
        }
    }
    public static void LevelOrder(TreeNode root)
    {
        Queue<TreeNode?> q = new Queue<TreeNode?>();
        q.Enqueue(root);
        q.Enqueue(null);
        /*
        In Level Order, After Enquing head root in the queue, we 

        while(queueIsNotEmpty)
        {
            Remove (dequeue and store the received node in a variable)
            Print (Print the dequeued node's data)
            Add (Enqueue the children (if any) of the recently dequeued node)
        }
        */
        while (q.Count != 0)
        {
            var node = q.Dequeue();
            if (node == null)
            {
                if (q.Count != 0)
                {
                    System.Console.WriteLine();
                    q.Enqueue(null);
                }

            }
            else
            {
                System.Console.Write(node.data + " ");

                foreach (var child in node.children)
                {
                    q.Enqueue(child);
                }
            }
        }
    }

    public static void LevelOrder2(TreeNode root)
    {
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Count != 0)
        {
            var node = q.Dequeue();
            System.Console.Write(node.data + " ");
            foreach (var child in node.children)
            {
                q.Enqueue(child);
            }
        }
    }
    public static TreeNode CreateGenericTree(int[] arr)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode root = new TreeNode(-1);// just to get rid of the warning
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == -1)
            {
                stack.Pop();
            }
            else
            {
                TreeNode newNode = new TreeNode(arr[i]);
                if (stack.Count == 0)
                {
                    root = newNode;
                }
                else
                {
                    var currentlyOnTopOfStack = stack.Peek();
                    currentlyOnTopOfStack.children.Add(newNode);
                }
                stack.Push(newNode);
            }

        }
        return root;
    }
    // public static TreeNode? CreateTreeRecursively(int[] arr, int index)
    // {
    //     if(arr[index]==-1) return null;
    //     TreeNode node =  new TreeNode(arr[index]);
        
    //     node.children.Add(CreateTreeRecursively(arr, ++index));
    //     return node;

    // }
    public static void DisplayTree(TreeNode root)
    {
        //This runs just fine without a base case as when there are no children, the
        // foreach loop will not run and hence we will exit the function, so it is returning by itself after
        // printing its children   
        System.Console.WriteLine(root.data);

        // if (root.children != null)
        // {
        foreach (var item in root.children)
        {
            DisplayTree(item);
        }
        //}

    }
    public static int NumberOfNodesInTree(TreeNode root)
    {
        int totalDescendents = 0;
        foreach (var item in root.children)
        {
            totalDescendents += NumberOfNodesInTree(item);
        }
        return totalDescendents + 1;
    }

    public static int MaxValueInTree(TreeNode root)
    {
        int max = root.data;// if there is just one root then foreach will not run
                            // and it will be the max automatically

        foreach (var item in root.children)
        {
            int ans = MaxValueInTree(item);
            max = Math.Max(ans, max);
        }
        return max;
    }
    public static int HeightOfTree(TreeNode root)//we are counting nodes here
    {                                            // if we count height in terms of edges
                                                 // they will be node_Wise_height-1   
        int height = 0;//put -1 here if we count height in terms of edges

        foreach (var item in root.children)
        {
            height = Math.Max(height, (HeightOfTree(item)));
        }

        return height + 1;
    }
    public static void PrintPreOrder(TreeNode root)
    {

        System.Console.WriteLine(root.data);
        foreach (var item in root.children)
        {
            System.Console.WriteLine($"edge pre {root.data} --> {item.data}");
            PrintPreOrder(item);
            System.Console.WriteLine($"edge post {root.data} --> {item.data}");
        }
    }
    public static void PrintPostOrder(TreeNode root)
    {

        foreach (var item in root.children)
        {
            PrintPostOrder(item);
        }
        System.Console.WriteLine(root.data);

    }
}
class TreeNode
{
    public int data;
    public List<TreeNode> children;

    public TreeNode(int data)
    {
        this.data = data;
        children = new List<TreeNode>();
    }
}