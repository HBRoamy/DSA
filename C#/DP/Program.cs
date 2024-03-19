class Program
{
    static void Main(string[] args)
    {
        // System.Console.WriteLine(ClimbingStairs_CountTotalPaths_Memoized(10,new int[]{1,2,3},new int[11]));
        // ClimbingStairs_Tabulation(10,new int[]{1,2,3});
        int ans=0;
        List<List<int>> res = new List<List<int>>();
        CoinChange(new int[]{2,3,5},7,ref ans, new List<int>(),res);
    System.Console.WriteLine("total "+ ans);
        foreach (var item in res)
        {
            System.Console.WriteLine(String.Join(", ",item));
        }
    }


    //-------------------------------------------------------------
    static void CoinChange(int[] denominations, int target, ref int ans,List<int> list,List<List<int>> res)
    {
        //GET RID OF PERMUTATIONS
        if (target < 0) return;

        if (target == 0)
        {
            res.Add(new List<int>(list));
            ans++;
            return;
        }

        foreach(int coinValue in denominations)
        {
            list.Add(coinValue);
            CoinChange(denominations,target-coinValue,ref ans,list,res);
            list.Remove(coinValue);
        }


    }
    static int ClimbingStairs_CountTotalPaths_Memoized(int totalStairs, int[] arrOfSteps, int[] memo)
    {
        //arrOfSteps contains the allowed sizes of jumps
        if (totalStairs < 0) return 0;
        if (totalStairs == 0) return 1;
        if (memo[totalStairs] != 0)
        {
            return memo[totalStairs];
        }
        int ans = 0;
        for (int i = 0; i < arrOfSteps.Length; i++)
        {
            if (arrOfSteps[i] != 0)
                ans += ClimbingStairs_CountTotalPaths_Memoized(totalStairs - arrOfSteps[i], arrOfSteps, memo);
        }
        memo[totalStairs] = ans;
        return ans;
    }

    static void ClimbingStairs_Tabulation(int totalStairs, int[] arrOfSteps)
    {
        int[] dp = new int[totalStairs + 1];

        dp[totalStairs] = 1;//to reach n-th step from n-th step takes 1 move - that is, dont travel at all

        //assign storage and meaning to dp array
        //i-th index contains the total steps to reach n-th stair

        //find direction of movement
        //move from n to 0
        //

        //travel and solve
        for (int i = dp.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j < arrOfSteps.Length && i + arrOfSteps[j] < dp.Length; j++)
            {
                // System.Console.WriteLine($"i = {i}, j= {j}");
                dp[i] += dp[i + arrOfSteps[j]];
            }
        }

        System.Console.WriteLine(dp[0]);//steps possible from 0 to n
    }
}

/*

//     treeData = [
//   {
//     category_id: '1',
//     category_name: 'Animals',
//     subcategory: [
//       {
//         category_id: '2',
//         category_name: 'Herbivorus',
//         subcategory: [
//           {
//             category_id: '3',
//             category_name: 'Grass Eating',
//             subcategory: [
//               { id: 1, value: 'Deer' },
//               { id: 2, value: 'Elephant' },
//               { id: 3, value: 'Cow' },
//               { id: 4, value: 'Zebra' },
//             ],
//           },
//         ],
//       },
//       {
//         category_id: '4',
//         category_name: 'Carnivorus',
//         subcategory: [{
//           category_id: '5',
//           category_name: 'Prey Hunters',
//           subcategory: [
//             { id: 5, value: 'Lion' },
//             { id: 6, value: 'Tiger' },
//             { id: 7, value: 'Cheetah' },
//             { id: 8, value: 'Bat' },
//           ],
//         }],
//       },
//     ],
//   },
// ];


test a1 = new test("1", "Animals",true);
        test cof1_1 = new test("2", "Herbivorous",true);
        test cof1_2 = new test("4", "Carnivorous",true);
        test cof2_1 = new test("3", "Grass-Eating",true);
        test cof3_1 = new test("a", "deer",true);
        test cof3_2 = new test("b", "elephant",true);
        test cof3_3 = new test("c", "cow",true);
        test cof3_4 = new test("d", "zebra",true);
        test cof4_1 = new test("5", "prey-hunters",true);
        test cof5_1 = new test("e", "lion",true);
        test cof5_2 = new test("f", "tiger",true);
        test cof5_3 = new test("g", "cheetah",false);
        test cof5_4 = new test("h", "bat",true);

        a1.subcategory.Add(cof1_1);
        a1.subcategory.Add(cof1_2);
        cof1_1.subcategory.Add(cof2_1);
        cof1_2.subcategory.Add(cof4_1);
        cof2_1.subcategory.Add(cof3_1);
        cof2_1.subcategory.Add(cof3_2);
        cof2_1.subcategory.Add(cof3_3);
        cof2_1.subcategory.Add(cof3_4);
        cof4_1.subcategory.Add(cof5_1);
        cof4_1.subcategory.Add(cof5_2);
        cof4_1.subcategory.Add(cof5_3);
        cof4_1.subcategory.Add(cof5_4);


        System.Console.WriteLine(isChecked(a1));
        LevelOrder(a1);





    }

    static bool isChecked(test root)
    {
        if(!root.isSelected)
        {
            return false;
        }
        
        foreach (var item in root.subcategory)
        {
            var ans = isChecked(item);
            if(!ans) {
                root.isSelected=false;
                return false;}
        }
        return true;
    }

    static void LevelOrder(test root)
    {
        Queue<test?> q = new Queue<test?>();
        q.Enqueue(root);
        q.Enqueue(null);

        while (q.Count > 0)
        {
            var first = q.Dequeue();
            if (first != null)
            {

            System.Console.Write(first.category_name + "-->" + first.isSelected + " | ");
                foreach (var item in first.subcategory)
                {
                    q.Enqueue(item);
                }
            }
            else
            {
                System.Console.WriteLine();
                if(q.Count>0)
                {
                    q.Enqueue(null);
                }else{
                    break;
                }
            }

        }
    }


    static void preorder(test root)
    {
        if (root == null) return;

        System.Console.Write(root.category_name + " ");
        foreach (var item in root.subcategory)
        {
            preorder(item);
        }

    }

        class test
{
    public string category_id;
    public string category_name;
    public List<test> subcategory;
    public bool isSelected;

    public test(string catId, string catName,bool iss = false)
    {
        category_id = catId;
        category_name = catName;
        subcategory = new List<test>();
        isSelected=iss;
    }
}

*/