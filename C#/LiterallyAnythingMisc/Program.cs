class Program
{
    static void Main(String[] args)
    {
        // string testCase = "abracadabra";
        // MaximumOccuringCharacterIn(testCase);
        IList<string> l = new List<string>();
        // int[] array1 = { 1, 2, 2, 5, 3, 4, 3, 3 };
        // int[] array2 = { 1, 7, 2, 0, 1, 8, 3, 3 };
        // IntersectionOfTwoArrays2(array1, array2);

        // int[] arr = { 1, 2, 5, 8, 3, 6, 7, 9 };
        // int[] arr = { 2, 4, 1, 5, 3, 8, 7, 6 };
        // int k=2;
        // KSortedArray(arr, k);


        // List<int> arr = new List<int> { 247, 240, 303, 9, 304, 105, 44, 204, 291, 26, 242,
        //                                 2, 358, 264, 176, 289, 196, 329, 189, 102, 45, 111,
        //                                 115, 339, 74, 200, 34, 201, 215, 173, 107, 141, 71,
        //                                 125, 6, 241, 275, 88, 91, 58, 171, 346, 219, 238, 246,
        //                                 10, 118, 163, 287, 179, 123, 348, 283, 313, 226, 324,
        //                                 203, 323, 28, 251, 69, 311, 330, 316, 320, 312, 50, 157,
        //                                 342, 12, 253, 180, 112, 90, 16, 288, 213, 273, 57, 243,
        //                                 42, 168, 55, 144, 131, 38, 317, 194, 355, 254, 202, 351,
        //                                 62, 80, 134, 321, 31, 127, 232, 67, 22, 124, 271, 231, 
        //                                 162, 172, 52, 228, 87, 174, 307, 36, 148, 302, 198, 24, 
        //                                 338, 276, 327, 150, 110, 188, 309, 354, 190, 265, 3, 108, 
        //                                 218, 164, 145, 285, 99, 60, 286, 103, 119, 29, 75, 212, 290,
        //                                 301, 151, 17, 147, 94, 138, 272, 279, 222, 315, 116, 262, 1, 
        //                                 334, 41, 54, 208, 139, 332, 89, 18, 233, 268, 7, 214, 20, 46, 
        //                                 326, 298, 101, 47, 236, 216, 359, 161, 350, 5, 49, 122, 345, 
        //                                 269, 73, 76, 221, 280, 322, 149, 318, 135, 234, 82, 120, 335, 
        //                                 98, 274, 182, 129, 106, 248, 64, 121, 258, 113, 349, 167, 192, 
        //                                 356, 51, 166, 77, 297, 39, 305, 260, 14, 63, 165, 85, 224, 19, 
        //                                 27, 177, 344, 33, 259, 292, 100, 43, 314, 170, 97, 4, 78, 310, 
        //                                 61, 328, 199, 255, 159, 185, 261, 229, 11, 295, 353, 186, 325, 
        //                                 79, 142, 223, 211, 152, 266, 48, 347, 21, 169, 65, 140, 83, 156, 
        //                                 340, 56, 220, 130, 117, 143, 277, 235, 59, 205, 153, 352, 300, 114, 
        //                                 84, 183, 333, 230, 197, 336, 244, 195, 37, 23, 206, 86, 15, 187, 
        //                                 181, 308, 109, 293, 128, 66, 270, 209, 158, 32, 25, 227, 191, 35, 
        //                                 40, 13, 175, 146, 299, 207, 217, 281, 30, 357, 184, 133, 245, 284, 
        //                                 343, 53, 210, 306, 136, 132, 239, 155, 73, 193, 278, 257, 126, 331, 
        //                                 294, 250, 252, 263, 92, 267, 282, 72, 95, 337, 154, 319, 341, 70, 81, 
        //                                 68, 160, 8, 249, 96, 104, 137, 256, 93, 178, 296, 225, 237 };  

        // // System.Console.WriteLine(repeatedNumber(arr));
        //List<int> l= new List<int>{-6, -3, -1, 2, 4, 5};

        //System.Console.WriteLine(String.Join(", ", solve(l)));

        int[] array = { 1, 0, 1, 0, 1, 2, 2, 3 };
        int[] array2 = { 3, 0, 3, 1, 3, 3, 2, 3 };

        MajorityElement_SpatiallyUnoptimized(array2);
        BoyerMooreVotingAlgoForMajorityElement(array2);
        MajorityElement_3rdApproach(array2);
    }

    static void MajorityElement_3rdApproach(int[] arr)
    {
        // It requires that there is a majority element present in the array
        // TC = O(NLogN) taken by sorting
        // space = O(1) 
        Array.Sort(arr);
        System.Console.WriteLine(arr[arr.Length/2]);
    }

    static void BoyerMooreVotingAlgoForMajorityElement(int[] arr)
    {
        // TC = O(N)
        // space = O(1) 
        int? candidate = null;
        int count = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if(count==0)
            {
                candidate = arr[i];
                count=1;
            }
            else{

            count += arr[i]==candidate?1:-1;
            }
            // if(arr[i]==candidate)
            // {
            //     count++;
            // }else
            // {
            //     count--;
            // }
        }

        System.Console.WriteLine($"{candidate} appears.");

        int count1=0;
        for (int i = 0; i < arr.Length; i++)
        {
            if(arr[i]==candidate)
            {
                count1++;
            }
        }

        if (count1 > arr.Length / 2)
        {
            System.Console.WriteLine($"Its Majority: {count1}");
        }
        else
        {
            System.Console.WriteLine($"Not Majority: {count1}");
        }
    }

    static void MajorityElement_SpatiallyUnoptimized(int[] array)
    {
        // TC = O(N)
        // space = O(N) 

        // A number that appears more than N/2 times
        Dictionary<int, int> ds = new Dictionary<int, int>();
        int majorityKey = -1, majorityValue = int.MinValue;

        for (int i = 0; i < array.Length; i++)
        {
            if (ds.ContainsKey(array[i]))
            {
                ds[array[i]]++;
                if (ds[array[i]] > majorityValue)
                {
                    majorityValue = ds[array[i]];
                    majorityKey = array[i];
                }
            }
            else
            {
                ds.Add(array[i], 1);
            }
        }

        System.Console.WriteLine(majorityKey + " appears " + majorityValue + " times.");

        if (majorityValue > array.Length / 2)
        {
            System.Console.WriteLine("Its Majority");
        }
        else
        {
            System.Console.WriteLine("Not Majority");
        }

    }

    public static List<int> solve(List<int> A)
    {
        List<int> ans = new List<int>();
        int j = 0;
        for (j = 0; j < A.Count; j++)
        {
            if (A[j] >= 0)
            {
                break;
            }
        }
        System.Console.WriteLine(j);
        for (int i = 0, k = j; i < j && k < A.Count; i++, k++)
        {
            int a = A[i] * A[i];
            int b = A[k] * A[k];
            System.Console.WriteLine(i + " " + k);
            if (a < b)
            {
                ans.Add(a);
            }
            else
            {
                ans.Add(b);
            }
        }

        return ans;
    }

    public static int repeatedNumber(List<int> A)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();

        for (int i = 0; i < A.Count; i++)
        {
            if (d.ContainsKey(A[i]))
            {
                d[A[i]]++;
            }
            else
            {
                d.Add(A[i], 1);
            }
        }

        foreach (var key in d.Keys)
        {
            if (d[key] > 1)
            {
                return key;
            }
        }
        return -1;
    }

    static void KSortedArray(int[] array, int k)
    {
        //given array is nearly sorted, its just that the elements are shifted atmost k places left or right
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();



        System.Console.WriteLine(String.Join(", ", array));

    }

    static void LongestConsecutiveSequence(int[] array)
    {
        //arr = 1, 2, 5, 8, 3, 6, 7, 9
        //so consecutive sequences are 1,2,3 and 5,6,7,8,9
        // the latter one is longer so print it.

    }

    static void IntersectionOfTwoArrays2(int[] arr1, int[] arr2)
    {
        // arr1 = 1 , 1, 2, 3
        // arr2 = 1, 9, 1 , 2
        // ans will be 1, 1, 2
        Dictionary<int, int> dict = new Dictionary<int, int>();
        List<int> ans = new List<int>();
        for (int i = 0; i < arr1.Length; i++)
        {
            if (dict.ContainsKey(arr1[i]))
            {

                dict[arr1[i]]++;
            }
            else
            {
                dict.Add(arr1[i], 1);
            }
        }

        foreach (var item in arr2)
        {
            if (dict.ContainsKey(item))
            {
                if (dict[item] > 0)
                {
                    ans.Add(item);
                    dict[item]--;
                }
            }
        }

        System.Console.WriteLine(String.Join(", ", ans));
    }

    static void IntersectionOfTwoArrays(int[] arr1, int[] arr2)
    {
        HashSet<int> hs = new HashSet<int>();
        HashSet<int> temp = new HashSet<int>();
        for (int i = 0; i < arr1.Length; i++)
        {
            hs.Add(arr1[i]);
        }

        for (int j = 0; j < arr2.Length; j++)
        {
            if (hs.Contains(arr2[j]))
            {
                temp.Add(arr2[j]);
            }
        }

        System.Console.WriteLine(String.Join(", ", temp));
    }
    static void MaximumOccuringCharacterIn(string str)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();

        for (int i = 0; i < str.Length; i++)
        {
            if (dict.ContainsKey(str[i]))
            {
                dict[str[i]]++;
            }
            else
            {
                dict.Add(str[i], 1);
            }
        }
        char ans = default;
        int max = int.MinValue;

        foreach (var item in dict)
        {
            if (item.Value > max)
            {
                max = item.Value;
                ans = item.Key;
            }
        }

        System.Console.WriteLine($"Character {ans} appears {max} times");
    }
}