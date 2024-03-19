class Program
{
    static void Main(string[] args)
    {

        // int[][] grid = new int[3][];

        // grid[0] = new int[] { 1, 2, 3 };
        // grid[1] = new int[] { 4, 5, 6 };
        // // grid[2] = new int[] { 4, 2, 1 };

        // System.Console.WriteLine(minPathSum(grid));
        // TreeNode root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
        // TreeNode r = new TreeNode(1, new TreeNode(2,new TreeNode(4)), new TreeNode(3, null, new TreeNode(5)));
        
        // var res = LevelOrder(r);

        // foreach(var l in res)
        // {
        //     foreach (var item in l)
        //     {
        //         System.Console.Write(item + " ");
        //     }
        //     System.Console.WriteLine();
        // }
    
        System.Console.WriteLine(String.Join(", ", FindFrequentTreeSum(new TreeNode(-1))));
        
    }
static int outputArraySize=3;
    public static int[] FindFrequentTreeSum(TreeNode root) {
        Dictionary<int,int> d = new();
        int maxSum=0;
        d.Add(1,0);
        d.Add(2,0);
        d.Add(3,0);
        int[] res = new int[outputArraySize];
        //helper(d,root, ref maxSum);
        int index=0;

        foreach(var i in d)
        {
            if(i.Value==maxSum) 
            {
                res[index]=i.Key;
                //Console.WriteLine(index);
                index++;

            }
        }
        
        return res;
    }

    public static int helper(Dictionary<int,int> d, TreeNode root, ref int maxSum)
    {
        if(root == null) return 0;

        int leftSum = helper(d,root.left, ref maxSum);        
        int rightSum = helper(d,root.right, ref maxSum);        

        int sum = leftSum+rightSum+root.val;

        if(!d.ContainsKey(sum)) d.Add(sum,1);
        else d[sum]++;

        if(d[sum]>maxSum) 
        {
            maxSum=d[sum];
            outputArraySize=1;
        }else if(d[sum]==maxSum)
        {
            outputArraySize++;
        }


        return sum;
    }
public static ListNode ReverseKGroup(ListNode head, int k) {
       ListNode dummy = new ListNode(-1,head),curr=dummy.next,h1=dummy;
       ListNode t = head;
    for(int i=1;i<k && t!=null;i++)
            {
                t=t.next;
            }

            dummy.next=t;
        while(curr!=null)
        {
            var first = curr;

            for(int i=1;i<=k;i++)
            {
                if(curr==null) break;
                curr=curr.next;
            }

            var pair = Rev(first,curr);
            
            pair.Item2.next = curr;
            //Console.WriteLine("curr " + curr.val);
            //break;
            //curr = pair.Item1;
            //curr=curr.next;
        }
        // ListNode c = dummy.next;

        // while(c!=null)
        // {
        //     Console.WriteLine("cal " + c.val);
        //     c=c.next;
        // } 

       return dummy.next;
    }
    public static (ListNode, ListNode) Rev(ListNode head, ListNode upto)
    {
        ListNode prev = null, curr=head,next;

        while(curr!=upto && curr!=null)
        {
            next = curr.next;

            curr.next = prev;
            prev=curr;
            curr=next;
        }

        Console.WriteLine(prev.val + " " +head.val);
        return (prev,head); //first and last
    }

    public static IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> ans = new List<IList<int>>();
        BFS2(root, ans);
        return ans;
    }
static void BFS2(TreeNode root, IList<IList<int>> finalDs){
        var q = new Queue<TreeNode?>();

        q.Enqueue(root);
        while(q.Count!=0)
        {
            var size = q.Count;
            IList<int> l = new List<int>();
            
            for(int i=0;i<size;i++)
            {
                var first = q.Dequeue();
                l.Add(first.val);
                if(first.left!=null)
                {
                    q.Enqueue(first.left);
                }
                if(first.right!=null)
                {
                    q.Enqueue(first.right);
                }
            }
            finalDs.Add(new List<int>(l));
            
        }
    }
    static void BFS(TreeNode root, IList<int> tempDs, IList<IList<int>> finalDs){
        var q = new Queue<TreeNode?>();

        q.Enqueue(root);
        q.Enqueue(null);

        // tempDs.Add(root.val);
        // finalDs(new List<int>(tempDs));
        // tempDs.Remove(root.val);

        while(q.Count!=0){

            var first = q.Dequeue();

            if(first!=null)
            {
                tempDs.Add(first.val);

                if(first.left!=null)
                {
                    q.Enqueue(first.left);
                }
                if(first.right!=null)
                {
                    q.Enqueue(first.right);
                }
                
                //q.Enqueue(null);
            }else
            {
                if(tempDs.Count!=0)
                {
                    finalDs.Add(new List<int>(tempDs));
                    tempDs.Clear();
                }

                if(q.Count==0) break;
                else q.Enqueue(null);
            }
        }
    }

    public static int minPathSum(int[][] grid)
    {
        int ans = int.MaxValue;
        
        bool[][] visited = new bool[grid[0].Length][];

        for (int i = 0; i < grid[0].Length; i++)
        {
            visited[i] = new bool[grid[0].Length];
        }
        // visited[0] = new bool[3];
        // visited[1] = new bool[3];
        // visited[2] = new bool[3];

        f(grid, 0, 0, 0, ref ans, visited);
        return ans;
    }

    public static void f(int[][] grid, int x, int y, int sum, ref int ans, bool[][] visited)
    {
        if (x >= grid[0].Length || y >= grid[0].Length || visited[x][y] == true)
        {
            return;
        }

        if (x == grid[0].Length - 1 && y == grid[0].Length - 1)
        {
            sum += grid[x][y];
            ans = Math.Min(ans, sum);
            return;
        }

        visited[x][y] = true;

        f(grid, x + 1, y, sum + grid[x][y], ref ans, visited);
        f(grid, x , y + 1, sum + grid[x][y], ref ans, visited);

        visited[x][y] = false;


    }

    public static int LengthOfLongestSubstring(string s)
    {

        HashSet<char> hs = new();
        int res = 0;
        int count = 0;
        foreach (char c in s)
        {
            if (hs.Contains(c))
            {
                res = Math.Max(res, count);
                count = 0;
            }
            {
                hs.Add(c);
                count++;
            }
        }
        res = Math.Max(res, count);

        return res;
    }

}
public class TreeNode {
      public int val;
      public TreeNode? left;
      public TreeNode? right;
      public TreeNode(int val=0, TreeNode? left=null, TreeNode? right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }

  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }
  