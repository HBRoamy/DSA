class Program
{
    static void Main(string[] args)
    {

        // PrintDecreasingIncreasing(5);
        // PrintIncreasingDecreasing(5);
        // System.Console.WriteLine(Factorial(5));
        // System.Console.WriteLine(XRaiseToPowerN(2,0));
        // System.Console.WriteLine(XRaiseToPowerN_OptimizedToLogarithmicTime(2, 4));
        // SeeRecursiveMotionDoubleCall(3);
        // PrintArrayRecursively(new int[]{5, 2, 4 ,1, 9},0);
        // var res = new List<int>{-1, -2};
        // var a =MaxElementInArray_Recursive(new int[]{5, 2, 4 ,1, 9},0);
        // var a = FirstIndexOfRecurrence_recursive(new int[] { 5, 2, 4, 7, 7, 1, 9, 7 }, 0, 7);
        // System.Console.WriteLine(a);
        // string[] codes = {".;", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tu", "vwx", "yz"};
        // string keyPadNumber = "573";

        // var res = GetKeyPadCombinations(keyPadNumber,codes);
        //GetStairPaths(new int[] { 1, 2, 3 }, 4, 0, new List<int>());
        //TwoSum(new int[]{2,11,7,15},9);
        // var res = GetMazePaths2(1,1,3,4); // (to reach from (1,1)-->(3,4) )
        // foreach (var item in res)
        // {
        //     System.Console.Write(item + " ");   
        // }
        // int m=3, n=2;
        // int[,] multiDimArray =  new int[m,n];
        //                         // get rows                   //get columns 
        // System.Console.WriteLine(multiDimArray.GetLength(0) +" "+ multiDimArray.GetLength(1));

        int[] array1 = { 10, 20, 40, 25, 60, 30, 50 };
        TargetSum(array1, 60, 0, new List<int>());
        TargetSum2(array1, 60, 0, new List<int>());//BETTER
        System.Console.WriteLine("rec1 " + rec1);
        System.Console.WriteLine("rec2 " + rec2);
        // foreach (var item in res)
        // {
        //     foreach (var data in item)
        //     {
        //         System.Console.Write(data + " ");
        //     }
        // }

    }
static int rec1 =0;
static int rec2 =0;
    static void TargetSum(int[] arr, int target, int index, List<int> tempDs)
    {
        //int [] array1 = {10, 20, 40, 25, 60, 30, 50}
        //target = 60
        rec1++;
        if (index == arr.Length)
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

        if (arr[index] <= target)
        {
            tempDs.Add(arr[index]);
            TargetSum(arr, target - arr[index], index + 1, tempDs);
            tempDs.Remove(arr[index]);
            TargetSum(arr, target, index + 1, tempDs);
        }
        else
        {
            TargetSum(arr, target, index + 1, tempDs);
        }

    }
    static void TargetSum2(int[] arr, int target, int index, List<int> tempDs)
    {
        if (index == arr.Length)
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
        rec2++;

        tempDs.Add(arr[index]);
        TargetSum(arr, target - arr[index], index + 1, tempDs);
        tempDs.Remove(arr[index]);
        TargetSum(arr, target, index + 1, tempDs);
    }

    static int[] TwoSum(int[] nums, int target)
    {

        List<int> res = new List<int>();
        helper(nums, target, nums.Length, 0, res);
        foreach (var item in res)
        {
            System.Console.Write(item + " ");
        }
        return res.ToArray();

    }
    static void helper(int[] nums, int target, int N, int index, List<int> tempDs)
    {
        if (index == N)
        {

            return;
        };

        if (nums[index] <= target)
        {
            tempDs.Add(index);
            helper(nums, target - nums[index], N, index + 1, tempDs);
            //tempDs.Remove(index);
        }
        else
        {
            helper(nums, target, N, index + 1, tempDs);
        }
    }

    static void PrintDecreasingIncreasing(int fromUpto)
    {
        if (fromUpto == 0)
        {
            System.Console.WriteLine(fromUpto); //prints zero only once
            return;
        }
        System.Console.WriteLine(fromUpto);
        PrintDecreasingIncreasing(fromUpto - 1);
        System.Console.WriteLine(fromUpto);
    }


    static void PrintIncreasingDecreasing(int n)
    {
        int count = n - 1;
        PrintIncreasingDecreasingHelper(n, count);

    }
    static void PrintIncreasingDecreasingHelper(int n, int count)
    {

    }
    static int Factorial(int n)
    {

        if (n == 1) return 1;

        return Factorial(n - 1) * n;

    }
    static int XRaiseToPowerN(int x, int n)
    {
        // here we consider x^n = x * x^(n-1) so time is linear
        //if(n==1) return x;
        //try handling negative powers
        if (n < 0) return 0;
        if (n == 0) return 1;

        return x * XRaiseToPowerN(x, n - 1);
    }

    static int XRaiseToPowerN_OptimizedToLogarithmicTime(int x, int n)
    {
        // here we consider that x^n = x^(n/2) * x^(n/2)

        if (n == 0) return 1;
        // int ans = XRaiseToPowerN_OptimizedToLogarithmicTime(x, n / 2) * XRaiseToPowerN_OptimizedToLogarithmicTime(x, n / 2);
        // if (n % 2 == 0)
        //     return ans;
        // else
        //     return ans * x;
        //OR
        int receivedNby2 = XRaiseToPowerN_OptimizedToLogarithmicTime(x, n / 2);
        int ans = receivedNby2 * receivedNby2;
        if (n % 2 == 1) ans *= x;

        return ans;
    }

    static void SeeRecursiveMotion(int n)
    {

        if (n == 0)
        {
            System.Console.WriteLine("Middle at base case " + n);
            return;
        }

        System.Console.WriteLine("pre of " + n);
        SeeRecursiveMotion(n - 1);
        System.Console.WriteLine("post of " + n);

    }

    static void SeeRecursiveMotionDoubleCall(int n)
    {
        if (n == 0)
        {
            System.Console.WriteLine("now at base case " + n);
            return;
        }

        System.Console.WriteLine("pre of " + n);
        SeeRecursiveMotionDoubleCall(n - 1);
        System.Console.WriteLine("mid of " + n);
        SeeRecursiveMotionDoubleCall(n - 1);
        System.Console.WriteLine("post of " + n);
    }

    static void PrintArrayRecursively(int[] arr, int index)
    {
        if (index == arr.Length)
        {
            //middle of the stack
            return;
        }
        System.Console.WriteLine(arr[index]); // going up the stack
        PrintArrayRecursively(arr, index + 1); // tail recursion
        System.Console.WriteLine(arr[index]); // coming down the stack
    }

    static int MaxElementInArray_Recursive(int[] arr, int index)
    {

        if (index == arr.Length - 1) return arr[index]; // when we reach last element we dont need to
                                                        // compare it with anything as it is a single element
                                                        // and has no element to its right so we return it only
        int a = MaxElementInArray_Recursive(arr, index + 1);
        return Math.Max(arr[index], a);

    }
    static int FirstIndexOfRecurrence_recursive(int[] arr, int index, int givenNum)
    {

        if (index == arr.Length)
        {
            return -1;
        }

        if (arr[index] == givenNum) return index;
        else return FirstIndexOfRecurrence_recursive(arr, index + 1, givenNum);

        // the commented method below traverses the array all the way to the end first and then comes back
        // comparing elements and returning indices, But its not good as we are traversing the array twice
        // it could be use to find last index, but we had freedom to choose which index to start with, we can 
        // we can just choose index as arr.Length-1 and recursed back to base case index<0 and that 
        // would also result in 1 traversal.
        // var ans = FirstIndexOfRecurrence_recursive(arr, index+1, givenNum);
        // if(arr[index]==givenNum){
        //     return index;
        // }
        // else{
        //     return ans;
        // }
    }
    //last index linear and starting from zero

    static void SubsequenceButWithOnlyOneRecursionArm(string str)
    {


    }

    static List<string> GetKeyPadCombinations(string str, string[] arr)
    {
        //string str is made of numbers like 573, 2481
        //to convert number character to int subtract '0' from it (eg. '6'-'0' = 6 <-- Int)
        // string[] codes = {".;", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tu", "vwx", "yz"};
        // say we get a number 573 as str
        if (str == "")
        { // can also be written as str.Length
            // var res = new List<string>();
            // res.Add("");
            return new List<string>() { "" };
        }
        char c = str.ElementAt(0); // 5 --> extracted first character
        string restOfTheString = str.Substring(1); //73

        List<string> recRes = GetKeyPadCombinations(restOfTheString, arr); // have faith that it will work for 73
        List<string> finalResult = new List<string>();
        string valuesAtIndexC = arr[c - '0']; // c is char (like '5') so converting it to number

        foreach (char item in valuesAtIndexC)    // at position 5 we have "mno"
        {
            foreach (var data in recRes)// recRes contains results for strings formed for 73
            {
                finalResult.Add(item + data);// adding every char of string at index 5
            }
        }

        return finalResult;
    }


    static void GetStairPaths(int[] sizeOfJumps, int numOfStairs, int index, List<int> tempDs)
    {
        //Get stair paths // or array is given and using those digits you have to create combinations
        // that add upto a given number. You can take a number more than 1 times also 12 and 21 are
        // treated as 2 different combinations
        //expectation : this fn will return the number of paths for given n Stairs
        //Faith: That it can return number of paths for n - 1
        //F-E : we will just solve for n with the help of result obtatined by
        //putting the n in front of all received paths from n-1

        //approach 1 pick/dont pick
        if (index == sizeOfJumps.Length)
        {
            if (numOfStairs == 0)
            {
                foreach (var item in tempDs)
                {
                    System.Console.Write(item + " ");
                }
                System.Console.WriteLine();
            }

            return;
        }

        //pick 
        if (sizeOfJumps[index] <= numOfStairs)
        {
            tempDs.Add(sizeOfJumps[index]);
            GetStairPaths(sizeOfJumps, numOfStairs - sizeOfJumps[index], index, tempDs);
            //dont pick
            tempDs.Remove(sizeOfJumps[index]);
            GetStairPaths(sizeOfJumps, numOfStairs, index + 1, tempDs);
        }
        else
        {
            GetStairPaths(sizeOfJumps, numOfStairs, index + 1, tempDs);
        }

    }

    static List<string> combinationJump(int n)
    {
        //we can only just 1 or 2 or 3 and 21 and 12 are treated differently
        return new List<string>();
    }


    static List<string> GetMazePaths(int sr, int sc, int dr, int dc)
    {
        /*
        Here we use level and options, that is, at every level we find out how many options we have and then 
        express those options in form of recursion,
        then meet expectation with faith by adding our requirement to the received results from those options

        here at every level we have two options, to go horizontally, and to go vertically so we expressed them
        and then added h and v to them to form our result


        sr : source row
        sc : source column
        dr : destination row
        dc : destination column
        */

        if (sr == dr && sc == dc)
        { // this means if we are standing on the destination itself
          // there is exists one path,  that is dont move so "" added to list
          // also we can say that we have reached the destination as (sr, sc) = (dr,dc)
            return new List<string>() { "" };
        }

        List<string> horizontalPaths = new List<string>();
        List<string> verticalPaths = new List<string>();

        if (sc < dc)//progress horizontally only if we are not on the right most cell
        {
            horizontalPaths = GetMazePaths(sr, sc + 1, dr, dc);
        }

        if (sr < dr)//progress vertically only if we are not on the bottom most cell
        {
            verticalPaths = GetMazePaths(sr + 1, sc, dr, dc);
        }

        List<string> result = new List<string>();
        foreach (var item in horizontalPaths)
        {
            result.Add("h" + item);
        }
        foreach (var item in verticalPaths)
        {
            result.Add("v" + item);
        }

        return result;
    }
    static List<string> GetMazePaths2(int sr, int sc, int dr, int dc)
    {
        List<string> res = new List<string>();

        if (sr == dr && sc == dc)
        {
            return new List<string>() { "" };
        }
        List<string> horizontalPaths = new List<string>();
        List<string> verticalPaths = new List<string>();

        if (sc < dc) //no putting '=' as if we are on the last cell horizonally then we will not move horizontally again       
        {
            horizontalPaths = GetMazePaths2(sr, sc + 1, dr, dc);// we have to move horizontally until we cant i.e. when we reach the dc
        }

        if (sr < dr)
        {
            verticalPaths = GetMazePaths2(sr + 1, sc, dr, dc);   //same logic as the above;
        }

        foreach (var item in horizontalPaths)
        {
            res.Add("h" + item);
        }
        foreach (var item in verticalPaths)
        {
            res.Add("v" + item);
        }

        return res;
    }
    //Flood Fill
    static void FloodFill(int[,] arrWithObstacles, int sr, int sc)
    {
        //we are given source rows and columns and we have to reach the last block of the given array

    }

    // maze path with jumps
    //USE Sieve of Eratosthenes for calculating Primes between 1 to n numbers
}
