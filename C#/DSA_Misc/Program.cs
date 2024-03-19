using System;
using System.Collections.Generic;

namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 3, 1, 2 }; // we find subseq of this array
            int[] arr2 = new int[] { 3, 1, 2, 6 }; // we find subseq of this array
            int[] arr3 = new int[] { 3, 1, 2, 6, 4, 1, 2 }; // we find subseq of this array
            int[] arr4 = new int[] { 3, 1, 2, 6, 4, -1 }; // we find subseq of this array
            List<int> list = new List<int>(); // we store the temp subsequences here to print

            // // CombinationSumReal(arr3, res, 6, 0, list, arr3.Length);
            // var abc = WrapperToCS(arr3, 6);
            // System.Console.WriteLine("Count is : " + abc.Count());
            // // System.Console.WriteLine(abc[0]);
            // // foreach (var item in abc)
            // // {
            // //     System.Console.WriteLine("*" + item);
            // // }
            // foreach (var item in abc)
            // {
            //     foreach (var data in item)
            //     {
            //         System.Console.Write(data + " ");
            //     }
            //     System.Console.WriteLine();
            //     //System.Console.WriteLine(String.Join(", ", item));
            // }
            int[] arr5 = { 10, 1, 2, 7, 6, 1, 5 };
            //var abc = CS2Wrapper(arr5, 8);
            // System.Console.WriteLine(abc.Count());
            //  foreach (var item in abc)
            // {
            //     foreach (var data in item)
            //     {
            //         System.Console.Write(data + " ");
            //     }
            //     System.Console.WriteLine();
            //     //System.Console.WriteLine(String.Join(", ", item));
            // }
        }
        static int counter = 0;
        static int counter2 = 0;
        public static void Counters()
        {
            System.Console.WriteLine("DP : " + counter);
            System.Console.WriteLine("Non - DP : " + counter2);
        }
        public static int fibonacci(int n, int[] hs)
        {

            if (hs[n] == 0)
            {
                if (n < 2)
                {
                    hs[n] = n;
                    return hs[n];
                }
                else
                {
                    counter++;
                    hs[n] = fibonacci(n - 1, hs) + fibonacci(n - 2, hs);
                }
            }

            return hs[n];


        }
        public static int fib(int n)
        {
            if (n < 2)
            {
                return n;
            }
            counter2++;
            return fib(n - 1) + fib(n - 2);
        }

        public static void SubequenceWithSum(int index, int[] arr, List<int> list, int givenSum, int tempSum)
        {

            if (index == arr.Length)
            {
                if (givenSum == tempSum)
                {
                    foreach (var item in list)
                    {
                        System.Console.Write(item + " ");
                    }
                    System.Console.WriteLine();
                }
                return;
            }

            //if pick then add to temp sum also
            list.Add(arr[index]);
            tempSum += arr[index];
            SubequenceWithSum(index + 1, arr, list, givenSum, tempSum);
            //if not picked then substract the previously added item
            list.Remove(arr[index]);
            tempSum -= arr[index];
            SubequenceWithSum(index + 1, arr, list, givenSum, tempSum);
        }

        public static void SubSequence(int[] arr, int index, List<int> list)
        {

            //stop when we reach the end of the array
            if (index == arr.Length)
            {
                foreach (var item in list)
                {
                    System.Console.Write(item + " ");
                }
                System.Console.WriteLine();
                return;
            }

            //pick the item
            list.Add(arr[index]);
            SubSequence(arr, index + 1, list);//go for the next element by incrementing index
            //dont pick the item
            list.Remove(arr[index]);
            SubSequence(arr, index + 1, list);//go for the next element by incrementing index

        }

        static void AlSubs(int[] forThisArray, List<int> tempDs, int indexToIterateTheArray, int arrayLength)
        {

            if (indexToIterateTheArray == arrayLength)
            {
                foreach (var item in tempDs)
                {
                    System.Console.Write(item + " ");
                }
                System.Console.WriteLine();
                return;
            }

            //dont pick it
            // tempDs.Remove(forThisArray[indexToIterateTheArray]);
            AlSubs(forThisArray, tempDs, indexToIterateTheArray + 1, arrayLength);
            //pick the element
            tempDs.Add(forThisArray[indexToIterateTheArray]);
            AlSubs(forThisArray, tempDs, indexToIterateTheArray + 1, arrayLength);
            tempDs.Remove(forThisArray[indexToIterateTheArray]);


        }

        static void CombinationSum(int[] candidates, int target, int iterator, List<int> tempDs, int candidatesArrayLength)
        {
            //same number can be chosen
            //only unique combinations
            //any order
            //How is it Unique tho??
            //How to handle negative nums (when we use negative nums (target - candidates[iterator]) will create problems
            /*
            as negative and negative becomes positive
            */
            //)
            if (iterator == candidatesArrayLength)
            {
                if (target == 0)
                {
                    foreach (var item in tempDs)
                    {
                        System.Console.Write(item + " ");
                    }
                    System.Console.WriteLine();
                }
                return;
            }

            if (candidates[iterator] <= target)
            {
                tempDs.Add(candidates[iterator]);
                CombinationSum(candidates, target - candidates[iterator], iterator, tempDs, candidatesArrayLength);
                //to print all combinations where same number isnt pciked more than once, uncomment the line below
                // and comment the line above.
                //CombinationSum(candidates, target - candidates[iterator], iterator + 1, tempDs, candidatesArrayLength);
                tempDs.Remove(candidates[iterator]);
                CombinationSum(candidates, target, iterator + 1, tempDs, candidatesArrayLength);
            }
            else
            {
                //not picking the number becoz its greater than the target
                CombinationSum(candidates, target, iterator + 1, tempDs, candidatesArrayLength);
            }


        }
        static void CombinationSum2(int[] candidates, int target, int iterator, List<int> tempDs, int candidatesArrayLength)
        {
            //same number can be chosen
            //only unique combinations
            //any order
            //How is it Unique tho??
            //How to handle negative nums
            if (iterator == candidatesArrayLength)
            {
                if (target == 0)
                {
                    foreach (var item in tempDs)
                    {
                        System.Console.Write(item + " ");
                    }
                    System.Console.WriteLine();
                }
                return;
            }

            if (candidates[iterator] <= target)
            {
                tempDs.Add(candidates[iterator]);
                if (candidates[iterator] < 0)
                {
                    CombinationSum2(candidates, target + candidates[iterator], iterator, tempDs, candidatesArrayLength);

                }
                else
                {

                    CombinationSum2(candidates, target - candidates[iterator], iterator, tempDs, candidatesArrayLength);
                }
                tempDs.Remove(candidates[iterator]);
                CombinationSum2(candidates, target, iterator + 1, tempDs, candidatesArrayLength);
            }
            else
            {
                CombinationSum2(candidates, target, iterator + 1, tempDs, candidatesArrayLength);
            }


        }
        static void Kadane()
        {

        }
        static List<List<int>> WrapperToCS(int[] candidates, int target)
        {
            HashSet<List<int>> ds = new HashSet<List<int>>();
            List<List<int>> list = new List<List<int>>();
            HashSet<int> set = new HashSet<int>(candidates);
            candidates = set.ToArray();
            List<int> tempDs = new List<int>();
            CombinationSumReal(candidates, ds, target, 0, tempDs, candidates.Length);

            return ds.ToList();
        }
        static void CombinationSumReal(int[] candidates, HashSet<List<int>> ds, int target, int iterator, List<int> tempDs, int candidatesArrayLength)
        {

            if (iterator == candidatesArrayLength)
            {
                if (target == 0)
                {
                    ds.Add(new List<int>(tempDs));
                }
                return;
            }

            if (candidates[iterator] <= target)
            {
                tempDs.Add(candidates[iterator]);
                CombinationSumReal(candidates, ds, target - candidates[iterator], iterator, tempDs, candidatesArrayLength);
                tempDs.Remove(candidates[iterator]);
                CombinationSumReal(candidates, ds, target, iterator + 1, tempDs, candidatesArrayLength);
            }
            else
            {
                CombinationSumReal(candidates, ds, target, iterator + 1, tempDs, candidatesArrayLength);
            }


        }

        static IList<IList<int>> CS2Wrapper(int[] candidates, int target)
        {
            HashSet<List<int>> ds = new HashSet<List<int>>();
            // HashSet<int> set = new HashSet<int>(candidates);
            // candidates = set.ToArray();
            List<int> tempDs = new List<int>();

            /*
            sort the array and make sure that arr[i] and arr[i-1] are not same
            */
            CS2Real(candidates, ds, target, tempDs, 0, 0, candidates.Length);

            System.Console.WriteLine("**********");
            foreach (var item in ds)
            {
                foreach (var data in item)
                {
                    System.Console.Write(data + " ");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("**********");
            IList<IList<int>> ans = new List<IList<int>>(ds);
            return ans;
        }

        public static void CS2Real(int[] candidates, HashSet<List<int>> finalDs, int target, List<int> tempDs, int sum, int iterator, int arrLength)
        {
            if (iterator == arrLength)
            {
                if (sum == target)
                {
                    finalDs.Add(new List<int>(tempDs));

                }
                return;
            }

            //pick 
            sum += candidates[iterator];
            tempDs.Add(candidates[iterator]);
            CS2Real(candidates, finalDs, target, tempDs, sum, iterator + 1, arrLength);
            sum -= candidates[iterator];
            tempDs.Remove(candidates[iterator]);
            CS2Real(candidates, finalDs, target, tempDs, sum, iterator + 1, arrLength);
            //dont pick
        }

        // static int FiboIterative(int number)
        // {
        //     int first = 0;
        //     int second = 1;
        //     int ans=first+second;

        //     for (int i = 3; i <= number; i++)
        //     {

        //     }

        // }
    }

}


/* Dumped code

//fibpnacci with DP
            //var hs = new List<int>();
            // int n = 25;
            // int[] hs = new int[n + 1];

            // // hs.Add(0);
            // // hs.Add(1);
            // System.Console.WriteLine("fibonacci DP : " + fibonacci(n, hs));
            // System.Console.WriteLine("fibonacci : " + fib(n));
            // Counters();



 // SubSequence(arr, 0, list);//0 is the starting index
            // SubequenceWithSum(0, arr, list, 3, 0);
            // AlSubs(arr, list, 0, arr.Length);

            // CombinationSum(arr2, 6, 0, list, arr2.Length);
            // System.Console.WriteLine();
            // CombinationSum(arr3, 6, 0, list, arr3.Length);
            // CombinationSum2(arr4, 5, 0, list, arr4.Length);
            // IList<int> ds = (IList<int>)new HashSet<int>();
            
            // HashSet<List<int>> res = new HashSet<List<int>>();
            // res = WrapperToCS(arr2, 6);
            // foreach (var item in res)
            // {
            //     foreach (var data in item)
            //     {
            //         System.Console.Write(data + " ");
            //     }
            //     System.Console.WriteLine();
            // }

*/