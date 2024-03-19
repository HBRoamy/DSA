class DSA2
{
    static void Main(string[] args)
    {
        int[] arr1 = { 3, 1, 25, -2 };
        // int[] arr2 = { 4, 0, 8, 1 };
        int[] arr2 = { 4, 0, 8, 1, 0, 0, 0, 0 };
        int[] arr3 = { 1, 3, 5, 11 };
        int[] arr4 = { 2, 4, 6, 8 };
        int[] arr5 = { 1, 2, 3 };
        Merge2(arr2, arr1);
        System.Console.WriteLine(String.Join(", ",arr2));
        //if two sorted arrays are merged then the resulting array is also sorted (concept of merge sort)
        // int []  res = Merge(arr1,arr2); // [ 3, 1, 4, 0, 8, 1, 25, -2 ] correct
        // int []  res2 = Merge(arr3,arr4); // [ 3, 1, 4, 0, 8, 1, 25, -2 ] correct
        // System.Console.WriteLine("[ "+ String.Join(", ", res)+" ]");
        // System.Console.WriteLine("[ "+ String.Join(", ", res2)+" ]");
        // //List<int>[] abcdd = new List<int>[7]; // for graphs
        // List<int> list = new List<int>();
        // bool[] statusMap = new bool[arr5.Length];
        // // Permutations_unopt(arr5, statusMap, list);
        // Permutations_space_optimized(0, arr5);


    }

    static int[] Merge(int[] arr1, int[] arr2)
    {

        int l1 = arr1.Length, l2 = arr2.Length;
        int[] resultingArray = new int[l1 + l2];
        int indexForResArr = -1;
        int i = 0, j = 0;

        while (i < l1 && j < l2)
        {
            if (arr1[i] < arr2[j])
            {
                resultingArray[++indexForResArr] = arr1[i++];
            }
            else
            {
                resultingArray[++indexForResArr] = arr2[j++];
            }
        }

        while (i < l1)
        {
            resultingArray[++indexForResArr] = arr1[i++];
        }
        while (j < l2)
        {
            resultingArray[++indexForResArr] = arr2[j++];
        }

        return resultingArray;
    }

    //Balancing brackets in a string using Stack
    static void Merge2(int[] arr1, int[] arr2)
    {
        //incorrect i am trying to not use auxiliary array
        int l1 = arr1.Length, l2 = arr2.Length;
        int i = 0, j = 0;

        while (i < l1 && j < l2)
        {
            if (arr1[i] > arr2[j])
            {
                swapper(i,arr1,j, arr2);
                j++;
            }else{
                i++;
            }
        }

        while(i<l1){
            
            arr1[i++] = arr2[j++];
        }

    }
    static void swapper(int i, int[] arr1, int j, int[] arr2)
    {
        var temp = arr1[i];
        arr1[i] = arr2[j];
        arr2[j] = temp;
    }
    static void Permutations_unopt(int[] givenArray, bool[] statusMap, List<int> tempDs)
    {

        if (givenArray.Length == tempDs.Count)
        {

            foreach (var item in tempDs)
            {
                System.Console.Write(item + " ");
            }
            System.Console.WriteLine();
            return;
        }

        for (int i = 0; i < givenArray.Length; i++)
        {
            if (!statusMap[i])   // if "Not present is true"
            {
                statusMap[i] = true;
                tempDs.Add(givenArray[i]);
                Permutations_unopt(givenArray, statusMap, tempDs);
                tempDs.Remove(givenArray[i]);
                statusMap[i] = false;
            }
        }
    }

    static void Permutations_space_optimized(int index, int[] arr)
    {
        if (index == arr.Length)
        {
            foreach (var item in arr)
            {
                System.Console.Write(item + " ");
            }
            System.Console.WriteLine();
            return;
        }

        for (int i = index; i < arr.Length; i++)
        {
            SwapForPermutations(index, i, arr);
            Permutations_space_optimized(index + 1, arr);
            SwapForPermutations(index, i, arr);
        }

    }

    static void SwapForPermutations(int index, int i, int[] arr)
    {

        int temp = arr[index];
        arr[index] = arr[i];
        arr[i] = temp;

    }

}