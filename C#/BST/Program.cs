class Program
{
    static void Main(string[] args)
    {
        // int[] arr = { 12, 25, 30, 37, 40, 50, 60, 62, 70, 75, 87 };
        int[] arr = { 1, 2, 3 };
        // TreeNode root = CreateBST(arr, 0, arr.Length - 1)!;
        // // LevelOrder(root);
        // // System.Console.WriteLine(LowestCommonAncestor(root, 6, 8));
        // IList<int> ans = new List<int>();
        // PreIter(root, ans);
        // String.Join(", ", ans);

        System.Console.WriteLine(ConstructMaximumBinaryTree(arr).val);
    }

    public static TreeNode ConstructMaximumBinaryTree(int[] nums)
    {

        PriorityQueue<int, int> pq = new(Comparer<int>.Create((a, b) => (b - a)));

        foreach (int i in nums)
        {
            pq.Enqueue(i, i);
        }

        return BuildTree(pq);
    }

    public static TreeNode BuildTree(PriorityQueue<int, int> pq)
    {
        if (pq.Count > 0)
        {
            int top = pq.Dequeue();
            TreeNode node = new TreeNode(top);

            if (pq.Count>0 && pq.Peek() < top && pq.Peek() == 0)
            {
                node.left = BuildTree(pq);
            }
            else
            {
                node.right = BuildTree(pq);
            }

            return node;
        }
        return null;
    }

    public static void PreIter(TreeNode root, IList<int> res)
    {
        if (root == null) return;

        Stack<TreeNode> st = new();
        st.Push(root);
        while (st.Count > 0)
        {
            var top = st.Pop();
            System.Console.WriteLine(top.val);

            res.Add(top.val);

            if (top.right != null) st.Push(top.right);
            if (top.left != null) st.Push(top.left);
        }
    }

    public static int[] TwoSum(int[] nums, int target)
    {

        Dictionary<int, int> d = new();

        // for(int i=0;i<nums.Length;i++)
        // {
        //     d.Add(i,nums[i]);
        // }

        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(target - nums[i]))
            {
                System.Console.WriteLine("inside");
                return new int[] { i, d[target - nums[i]] };
            }
            else
            {
                d.Add(nums[i], i);
            }
        }

        return new int[] { -1, -1 };
    }
    public static int LowestCommonAncestor(TreeNode? root, int x, int y)
    {
        if (root == null) return -1;
        // if(root.val==x || root.val ==y)
        // {
        //     return root.val;
        // }
        if (root.val > x && root.val > y)
        {
            return LowestCommonAncestor(root.left, x, y);
        }
        else if (root.val < x && root.val < y)
        {
            return LowestCommonAncestor(root.right, x, y);
        }
        else
        {
            return root.val;
        }

    }

    public static int ReplaceMaxSum(TreeNode? root, ref int sum)
    {
        if (root == null) return 0;


        if (root.right != null)
        {
            root.right.val = ReplaceMaxSum(root.right, ref sum);
        }
        sum += root.val;
        root.val = sum;
        if (root.left != null)
        {
            root.left.val = ReplaceMaxSum(root.left, ref sum);
        }


        return root.val;
    }

    public static TreeNode? RemoveNode(TreeNode? root, int data)
    {
        if (root == null) return null;

        if (root.val > data)
        {
            root.left = RemoveNode(root.left, data);
        }
        else if (root.val < data)
        {
            root.right = RemoveNode(root.right, data);
        }
        else
        {
            if (root.right != null && root.left != null)
            {
                var maxNode = MaxNode(root.left);
                root.val = maxNode.val;

                root.left = RemoveNode(root.left, maxNode.val);

            }
            else if (root.left != null)
            {
                return root.left;
            }
            else if (root.right != null)
            {
                return root.right;
            }
            else
            {
                return null;
            }

        }
        return root;
    }

    public static TreeNode AddNode2(TreeNode? root, int data)
    {
        if (root == null) return new TreeNode(data);

        if (data < root.val)
        {
            root.left = AddNode2(root.left, data);
        }
        else if (data > root.val)
        {
            root.right = AddNode2(root.right, data);
        }
        else
        {
            // do nothing
        }

        return root;
    }

    public static void AddNode(TreeNode? root, int data)
    {
        //Nodes are added at leaf

        if (root == null)
        {

            return;
        }

        if (root.left == null && root.right == null)
        {
            if (data < root.val)
            {
                root.left = new TreeNode(data);
            }
            else if (data > root.val)
            {
                root.right = new TreeNode(data);
            }
            return;
        }

        if (data < root.val)
        {
            AddNode(root.left, data);
        }
        else if (data > root.val)
        {
            AddNode(root.right, data);
        }

    }

    public static void LevelOrder(TreeNode root)
    {
        Queue<TreeNode?> q = new Queue<TreeNode?>();
        q.Enqueue(root);
        q.Enqueue(null);

        while (q.Count > 0)
        {
            var first = q.Dequeue();
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
                System.Console.Write(first.val + " ");

                if (first.left != null)
                {
                    q.Enqueue(first.left);
                }
                if (first.right != null)
                {
                    q.Enqueue(first.right);
                }
            }
        }
        System.Console.WriteLine();
    }

    public static int SizeOfTree(TreeNode? root)
    {
        if (root == null) return 0;

        int leftSize = SizeOfTree(root.left);
        int rightSize = SizeOfTree(root.right);

        return leftSize + rightSize + 1;

    }

    public static TreeNode MinNode(TreeNode root)
    {
        TreeNode curr = root;
        while (curr != null && curr.left != null)
        {
            curr = curr.left;
        }
        return curr!;
    }

    public static TreeNode MaxNode(TreeNode root)
    {
        TreeNode curr = root;
        while (curr != null && curr.right != null)
        {
            curr = curr.right;
        }
        return curr!;
    }

    public static TreeNode? CreateBST(int[] sortedArray, int low, int high)
    {
        if (low > high) return null; // low==high is also a single node tree so 
                                     // we won't return null in that case

        int mid = low + (high - low) / 2;

        TreeNode newTreeNode = new(sortedArray[mid]);

        newTreeNode.left = CreateBST(sortedArray, low, mid - 1);
        newTreeNode.right = CreateBST(sortedArray, mid + 1, high);

        return newTreeNode;
    }

    public static int SumOfAllNodes(TreeNode? root)
    {
        if (root == null) return 0;

        int sumOfAllLefts = SumOfAllNodes(root.left);
        int sumOfAllRights = SumOfAllNodes(root.right);

        return sumOfAllLefts + sumOfAllRights + root.val;
    }

    public static void InOrder(TreeNode? root)
    {
        if (root == null) return;

        InOrder(root.left);
        System.Console.Write(root.val + " ");
        InOrder(root.right);
    }

    public static void PreOrder(TreeNode? root)
    {
        if (root == null) return;

        System.Console.Write(root.val + " ");
        PreOrder(root.left);
        PreOrder(root.right);
    }
    public static void PostOrder(TreeNode? root)
    {
        if (root == null) return;

        PostOrder(root.left);
        PostOrder(root.right);
        System.Console.Write(root.val + " ");
    }


    public static bool Search(TreeNode? root, int target)
    {
        if (root == null) return false;

        if (target == root.val)
        {
            return true;
        }
        else if (target < root.val)
        {
            return Search(root.left, target);
            // if(leftStatus) return true;
        }
        else
        {
            return Search(root.right, target);
            // if(rightStatus) return true;
        }

        // return false;
    }

}

class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode
    (
        int val,
        TreeNode? left = null,
        TreeNode? right = null
    )
    {
        this.val = val;
        this.left = left;
        this.right = right;

    }
}

/*
Create BST recursively/iteratively
BST Search
Add a node to BST
Remove a node from BST

Morris Traversals In Pre (Post?)
Kth Ancestor
Kth Common Ancestor
Node to root path
kth descendent
kth common descendent
Flatten Tree into LL
Diameter of BST
*/