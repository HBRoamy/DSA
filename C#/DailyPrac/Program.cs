class Program
{
    static void Main(string[] args)
    {
        int[] arr = { -1, 2, 4, 7, 8, -3, 5 };
        int[] ans = new int[2];
        //MinMaxInArray(arr, 6);
        //ReverseArrayAndString(arr,"abcd");
        int[] maxSumArray = { -2, 1, -3, 4, -1, 2, 1, -5, 4 }; // ans 6 for max subarraysum
        int[] maxSumArray2 = { 1, 2, 3, 1, 1, 3 }; // ans 23 for max subarraysum// make for -ve nums too

        // SubArrayIndicesWithGivenSum(maxSumArray2, 5);

        // System.Console.WriteLine("Sum: "+MaxSubArray_O_N_Square(maxSumArray));
        // System.Console.WriteLine("Sum: "+MaxSubArray_KadaneAlgo_O_N(maxSumArray));
        // System.Console.WriteLine("Sum: "+MaxSubArray_O_N_Square(maxSumArray2));
        // System.Console.WriteLine("Sum: "+MaxSubArray_KadaneAlgo_O_N(maxSumArray2));
        //int[] arr1 = {3, 4, 1, 9, 56, 7, 9, 12};
        //System.Console.WriteLine(ChocolateDistributionProblem(arr1,5));
        // int[] ar1 = { 1, 3, 4, 5, 8, 9, 12, 21 };
        // System.Console.WriteLine(BinarySearch(21, ar1));
        int[] ar2 = { 3,1};
        System.Console.WriteLine(SearchInRotatedSortedArray_in_LogN(ar2, 1));
    }

    static void AddOne(int[] veryLargeNumberRepresentedAsArray)
    {
        // return an array
    }

    //Given an array of size N. The task is to find the maximum and the minimum element of the
    // array using the minimum number of comparisons.
    static void MinMaxInArray(int[] array, int size)
    {
        int min = Int32.MaxValue;
        int max = Int32.MinValue;

        for (int i = 0; i < size; i++)
        {
            min = Math.Min(array[i], min);
            max = Math.Max(array[i], max);
        }

        System.Console.WriteLine(min + " " + max);
    }
    static void MaxMinInArray_Recursion()
    {

    }

    static void ReverseArrayAndString(int[] arr, string str)
    {

        int size = arr.Length;
        for (int i = 0; i < size / 2; i++)
        {

            arr[i] = arr[i] ^ arr[size - 1 - i];
            arr[size - 1 - i] = arr[i] ^ arr[size - 1 - i];
            arr[i] = arr[i] ^ arr[size - 1 - i];

        }
        string ans = "";
        for (int j = str.Length - 1; j >= 0; j--)
        {
            ans += str[j];
        }
        str = ans;
        System.Console.WriteLine(String.Join(", ", arr));
        System.Console.WriteLine(str);

    }
    static int MaxSubArray_O_N_Square(int[] nums)
    {
        /*
        Given an integer array nums, find the 
        subarray with the largest sum, and return its sum.
        */
        int size = nums.Length;
        int maxSum = Int32.MinValue;
        int sum = 0;
        for (int subArraystartingIndex = 0; subArraystartingIndex < size; subArraystartingIndex++)
        {
            sum = 0;
            for (int subArrayEndingIndex = subArraystartingIndex; subArrayEndingIndex < size; subArrayEndingIndex++)
            {
                sum += nums[subArrayEndingIndex];
                maxSum = Math.Max(maxSum, sum);
            }
        }
        return maxSum;
    }

    static int MaxSubArray_KadaneAlgo_O_N(int[] nums)
    {
        /*
        Given an integer array nums, find the 
        subarray with the largest sum, and return its sum.
        */
        int size = nums.Length;
        int maxSoFar = int.MinValue, sumTillHere = 0;

        for (int i = 0; i < size; i++)
        {
            sumTillHere += nums[i];
            maxSoFar = Math.Max(maxSoFar, sumTillHere);

            if (sumTillHere < 0)
            {
                sumTillHere = 0;
            }

        }
        return maxSoFar;

    }
    static void SubArrayIndicesWithGivenSum(int[] arr, int givenSum)
    {
        //try sliding window
        //{5,4,-1,7,8} for 6
        int[] ans = new int[2];
        int slidingSum = givenSum;
        int start = 0;
        for (int i = 0; i < arr.Length; i++)
        {

            if (arr[i] <= slidingSum)
            {
                slidingSum -= arr[i];
            }
            else if (arr[i] > slidingSum)
            {
                slidingSum += arr[start];
                start++;
                slidingSum -= arr[i];
            }
            if (slidingSum == 0)
            {
                ans[0] = start;
                ans[1] = i;
                break;
            }

        }

        System.Console.WriteLine(String.Join(", ", ans));
    }

    static bool ContainsDuplicate(int[] nums)
    {
        /*
        Given an integer array nums, return true if any value appears
        at least twice in the array, and return false if every element
        is distinct.
        */
        HashSet<int> hs = new HashSet<int>();

        foreach (var item in nums)
        {
            if (hs.Contains(item))
            {
                return true;
            }
            else
            {
                hs.Add(item);
            }
        }
        return false;
    }
    static int ChocolateDistributionProblem(int[] arr, int totalStudents)
    {
        /*arr[] = {12, 4, 7, 9, 2, 23, 25, 41, 30, 40, 28, 42, 30, 44, 48, 43, 50} m=7 result=10*/
        Array.Sort(arr);
        int start = 0;
        int minAns = int.MaxValue;
        int i = totalStudents - 1;//i will start from 0 in the loop so we decrease the totalStudents also
                                  // to keep the sliding window of size m;
        while (i < arr.Length)
        {
            if ((arr[i] - arr[start]) < minAns)
            {
                minAns = arr[i] - arr[start];
            }
            // else if((arr[i]-arr[start])>minAns)
            // {
            //     start++; i++;
            // }
            start++; i++;
        }

        /*
        converted the above while loop to for loop
         for (int i = 0; i + m - 1 < n; i++) {
            int diff = arr[i + m - 1] - arr[i];
 
            if (diff < minAns)
                minAns = diff;
        }
        */
        return minAns; //after the loop, i is set to arr.Length so decreasing it by 1;
    }

    static int BinarySearch(int numToLookFor, int[] arr)
    {
        int start = 0, end = arr.Length - 1, mid;
        while (start <= end)
        {
            mid = start + (end - start) / 2;
            if (numToLookFor == arr[mid])
            {
                return mid;
            }
            else if (numToLookFor < arr[mid])
            {
                end = mid - 1;

            }
            else if (numToLookFor > arr[mid])
            {
                start = mid + 1;

            }
        }
        return -1;// return index of element if found or return -1
    }
    static int SearchInRotatedSortedArray_in_LogN(int[] arr, int num)
    {
        //find the inflection point where left element> right element
        int start = 0, end = arr.Length - 1, mid = start + (end - start) / 2;
        //int inflection = -1;
        if (mid > start)
        {
            while (start <= end)
            {

                mid = start + (end - start) / 2;


                if (arr[mid - 1] > arr[mid])
                {
                    //here mid becomes inflection so we break here to use this mid in the next Search
                    // inflection = mid;
                    // mid = inflection;
                    break;
                }
                else
                {
                    start++;
                }
            }
          
        }
        //System.Console.WriteLine(mid);
        while (start <= end)
        {

            mid = start + (end - start) / 2;
            if (num == arr[mid])
            {
                return mid;
            }
            else if (num > arr[mid])
            {
                start = mid + 1;
            }
            else if (num < arr[mid])
            {
                end = mid - 1;
            }
        }
        return -1;
    }

}
