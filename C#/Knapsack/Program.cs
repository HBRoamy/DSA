using System;
using System.Collections.Generic;

namespace KnapSack01
{

    /*
        Given weights and values of N items, put these items in a knapsack of capacity W 
        to get the maximum total value in the knapsack. In other words, given two integer
        arrays val[0..N-1] and wt[0..N-1] which represent values and weights associated with
        N items respectively. Also given an integer W which represents knapsack capacity, find
        out the maximum value subset of val[] such that the sum of the weights of this subset 
        is smaller than or equal to W. You cannot break an item, either pick the complete item
         or don’t pick it (0-1 property)
    */

    class Program
    {
        static void Main(string[] args)
        {
            /*
                Input: N = 3, W = 4
                values[] = {1,2,3}
                weight[] = {4,5,1}
                Output: 3

                Input: N = 3, W = 3
                values[] = {1,2,3}
                weight[] = {4,5,6}
                Output: 0
            */

            int[] weights = { 10, 20, 30 };
            int[] values = { 60, 100, 120 };
            int W = 50;
            //knapsack capacity W = 4 given
            //total items N = 3 given

            System.Console.WriteLine(KS01(W, 3, weights, values));

            // System.Console.WriteLine(numDistinct("aaaababbababbaabbaaababaaabbbaaabbb", "bbababa"));
        }
        static int KS01(int W, int N, int[] wts, int[] vals)
        {
            if (W == 0 || N == 0) return 0;

            if (wts[N - 1] <= W)
            {
                int with = KS01(W - wts[N - 1], N - 1, wts, vals) + vals[N - 1];
                int without = KS01(W, N - 1, wts, vals);
                return Math.Max(with,without);
            }else{
                int without = KS01(W, N - 1, wts, vals);
                return without;
            }
        }


        public static int numDistinct(string A, string B)
        {
            int count = 0;
            numDistinctHelper(0, A, B, count, new List<char>());

            return count;
        }

        public static void numDistinctHelper(int index, string inQuestion, string target, int count, List<char> tempDs)
        {

            if (index == inQuestion.Length || index == target.Length)
            {
                string s = "";
                foreach (var item in tempDs)
                {
                    s += item;
                }

                System.Console.WriteLine(s);
                if (s == target)
                {
                    count++;
                }
                return;
            }

            tempDs.Add(inQuestion[index]);
            var tmp = inQuestion.Substring(0, index) + inQuestion.Substring(index + 1);
            numDistinctHelper(index + 1, tmp, target, count, tempDs);
            tempDs.Remove(inQuestion[index]);
            numDistinctHelper(index + 1, inQuestion, target, count, tempDs);



        }
    }



}