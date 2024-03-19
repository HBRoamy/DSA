class Program
{
    static void Main(string[] args)
    {
        // int[] height={0,1,0,2,1,0,1,3,2,1,2,1};
        // System.Console.WriteLine(Trap(height));
        //int[] arr = {1,2,3,3,3,5,7,7,7,7,7,7,8,9,9,10};
        //CountOccurencesUsingBinarySearch(arr,3);
        //var ans = TopKFrequent(new int[]{4,1,-1,2,-1,2,3},2);
        // System.Console.WriteLine(String.Join(", ",ans));
        //TargetSumDP(7,new int[]{3,4,5});
        //System.Console.WriteLine(CountOperationsToEmptyArray(new int[]{3,4,-1}));
        int[][] grid = new int[5][];

        for(int i=0;i<5;i++)
        {
            grid[i] = new int[4];
        }

        bool[][] visited = new bool[grid.GetLength(0)][];
        for(int i=0;i<grid.GetLength(0);i++)
        {
            visited[i] = new bool[grid[0].Length];
        }

        foreach (var item in visited)
        {
            System.Console.WriteLine(String.Join(", ", item));
        }
        
    }
    public static long CountOperationsToEmptyArray(int[] nums) {
        long moves=0;
        PriorityQueue<int,int> pq = new();
        List<int> l = new();
        foreach(int i in nums)
        {
            l.Add(i);
            pq.Enqueue(i,i);
        }
        
        while(l.Count>0 && pq.Count>0)
        {
            if(pq.Count>0 && l[0]==pq.Peek())
            {
                l.RemoveAt(0);
                pq.Dequeue();
            }else
            {
                l.Add(l[0]);
                l.RemoveAt(0);
                System.Console.WriteLine(String.Join(", ",l));
            }
            moves++;

        }
        
        return moves;
    }
    public static void BestSumDP(int targetSum, int[] nums)
    {
        //same as targetSumDP but we want the shortest combination
        List<int>[] dp = new List<int>[targetSum+1];
        dp[0] = new List<int>();//0 can be created by not taking any number from nums[]
        List<int> shortestCombination = new();

        for (int i = 0; i <= targetSum; i++)
        {
            if(dp[i]!=null)
            {
                foreach (var num in nums)
                {
                    if(i+num<=targetSum)
                    {

                    }
                }
            }
        }
    }
    public static void TargetSumDP(int targetSum, int[] nums)
    {
        //use any number from nums array any number of times and create targetSum.
        //Print the answer array -> for targetSum=7 from nums=[3,4,5], print 3,4 or 4,3

        //elements at every index of the array represent the array of nums needed to make that number(index)
        List<int>[] dp = new List<int>[targetSum+1];
        dp[0] = new List<int>();//0 can be created by not taking any number from nums[]

        for(int i=0;i<=targetSum;i++)
        {
            if(dp[i]!=null)
            {
                foreach (var num in nums)
                {
                    if(i+num<dp.Length)
                    {
                    dp[i+num] = new List<int>(dp[i]){num};//putting the previous array in it and adding num at the end

                    //dp[i+num].Add(num);
                    }
                    
                }
            }
        }
        
        System.Console.WriteLine(String.Join(", ",dp[targetSum]));
        
    }
    public static int[] TopKFrequent(int[] nums, int k) {
        List<int> ans = new();
        IDictionary<int,int> d = new SortedDictionary<int,int>(Comparer<int>.Create((a,b) => a-b));
        Array.Sort(nums);
        for(int i=0;i<nums.Length;i++)
        {
            if(d.ContainsKey(nums[i]))
            {
                d[nums[i]]++;
            }else
            {
                d.Add(nums[i],1);
            }
        }
        //PriorityQueue<int,int> pq = new PriorityQueue<int,int>(Comparer<int>.Create((a,b) => b-a));
        foreach (var item in d)
        {
            System.Console.WriteLine(item.Key + " " + item.Value);
        }
        
        int l=0;
        while(l<k && l<d.Count)
        {
            ans.Add(d.ElementAt(l).Key);
            l++;
        }
        return ans.ToArray();
    }
    public static void CountOccurencesUsingBinarySearch(int[] arr,int toFind)
    {
        
        //count using Binary Search
        //find index of first occurence and last occurence
        //then just print last-first+1
        int mid=-1,start = 0, end=arr.Length-1,firstIndex=-1,lastIndex=-1;

        //loop for finding the first occurence
        while(start<=end)
        {
            mid=start+(end-start)/2;
            
            if(arr[mid]==toFind)
            {
                firstIndex=mid;
                end=mid-1;//after finding the element check the left half for the same element
            }else if(arr[mid]<toFind)
            {
                start=mid+1;
            }else
            {
                end=mid-1;
            }
        }
        start = 0;
        end=arr.Length-1;

        //loop for finding the last occurence

        while(start<=end)
        {
            mid=start+(end-start)/2;
            //System.Console.WriteLine(arr[mid]);
            if(arr[mid]==toFind)
            {
                lastIndex=mid;
                start=mid+1;
            }else if(arr[mid]<toFind)
            {
                start=mid+1;
            }else
            {
                end=mid-1;
            }
        }
        if(lastIndex==-1 && firstIndex==-1) System.Console.WriteLine("Not present");
        else
        Console.WriteLine($"{toFind} occured {lastIndex-firstIndex+1} times. FirstIndex = {firstIndex} & LastIndex = {lastIndex}");
    }
    public static int Trap(int[] height)
    {
        //first thought of using 2 pointers is correct

        int p1 = 0, p2 = height.Length - 1, ans = 0;

        while (p1 < p2)
        {
            if (height[p1] == 0)
            {
                p1++;
            }
            else
            {

                break;
            }
        }
        p2 = p1;
        p2++;

        while (p1 < height.Length && p2 < height.Length)
        {
            if (height[p2] < height[p1])
            {
                while (height[p2] < height[p1])
                {
                    p2++;

                    if (p2 == height.Length)
                    {
                        p1++;
                        p2 = p1 + 1;
                        break;
                    }
                }
                int min = height[p1];
                var area = (p2 - p1 - 1) * min;
                Console.WriteLine(area);
                p1 += 1;
                while (p1 < p2)
                {
                    if(height[p1]!=min)
                    area -= height[p1];
                    p1++;
                }
                ans += area;
                p1++;
                p2 += 2;

            }
            else
            {
                p2++;
            }
        }
        return ans;
    }
}