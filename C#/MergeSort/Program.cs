class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 4, -1, 2, 3, 6, 3, 1, 25, 2, 9, 7, 8 };
        int[] arr2 = { 4, -1, 2, 3, 6, 3, 1, 25, 2, 9, 7, 8 };
        MS(arr, 0, arr.Length - 1);
        System.Console.Write(String.Join(", ", arr));
        Divide(arr2, 0, arr2.Length - 1);
        System.Console.WriteLine();
        System.Console.Write(String.Join(", ", arr2));
    }
    static void MS(int[] arr, int lb, int ub)
    {
        if (lb < ub)
        {
            //divide
            int mid = lb + (ub - lb) / 2;
            MS(arr, lb, mid);
            MS(arr, mid + 1, ub);
            Merge(arr, lb, mid, ub);
        }
    }
    static void Merge(int[] arr, int lb, int mid, int ub)
    {
        int[] tempArray = new int[ub - lb + 1];
        int indexOfFirstHalf = lb;
        int indexOfSecondHalf = mid + 1;
        int indexForTempArray = -1;

        while (indexOfFirstHalf <= mid && indexOfSecondHalf <= ub)
        {
            ++indexForTempArray;
            if (arr[indexOfFirstHalf] < arr[indexOfSecondHalf])
            {
                tempArray[indexForTempArray] = arr[indexOfFirstHalf];
                indexOfFirstHalf++;

            }
            else
            {
                tempArray[indexForTempArray] = arr[indexOfSecondHalf];
                indexOfSecondHalf++;
            }
        }

        while (indexOfFirstHalf <= mid)
        {
            ++indexForTempArray;
            tempArray[indexForTempArray] = arr[indexOfFirstHalf];
            indexOfFirstHalf++;

        }
        while (indexOfSecondHalf <= ub)
        {
            ++indexForTempArray;
            tempArray[indexForTempArray] = arr[indexOfSecondHalf];
            indexOfSecondHalf++;
        }
        // foreach (var item in tempArray)
        // {
        //     System.Console.Write(item + " ");
        // }
        // System.Console.WriteLine();
        for (int i = 0, j = lb; i < tempArray.Length; i++, j++)
        {
            arr[j] = tempArray[i];
        }
    }


    static void Divide(int[] arr, int lb, int ub)
    {
        if (lb < ub)
        {
            int mid = lb + (ub - lb) / 2;
            Divide(arr, lb, mid);
            Divide(arr, mid + 1, ub);
            Conquer(arr, lb, mid, ub);
        }
    }
    static void Conquer(int[] arr, int lb, int mid, int ub)
    {
        int[] tempArray = new int[ub - lb + 1];
        int indexForFirstHalf = lb;
        int indexForSecondHalf = mid + 1;
        int indexForTempArray = -1;

        while (indexForFirstHalf <= mid && indexForSecondHalf <= ub)
        {
            if (arr[indexForFirstHalf] < arr[indexForSecondHalf])
            {
                //putting into to tempArray whichever element is smaller
                tempArray[++indexForTempArray] = arr[indexForFirstHalf++];
                //incrementing the 
                //index-for-first-half so that it doesn't get compared again as it has
                // alrealy been put into the temp Array
            }
            else
            {
                tempArray[++indexForTempArray] = arr[indexForSecondHalf++];
            }
        }
        while (indexForFirstHalf <= mid)
        {
            tempArray[++indexForTempArray] = arr[indexForFirstHalf++];
        }
        while (indexForSecondHalf <= ub)
        {
            tempArray[++indexForTempArray] = arr[indexForSecondHalf++];
        }

        for (int i = 0, j= lb; i < tempArray.Length; i++, j++)
        {
            arr[j] = tempArray[i];
        }

    }

}
/*
We find the mid of array to divide it on its basis.
Division of array should be done until the divided array contains only 1 element (lb<ub)
After Division is done, We merge the array by treating it as 2 different arrays, hence for that we pass mid also
in the merge function (TO BE CONTINUED...)
*/