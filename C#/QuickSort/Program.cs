class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 4, -1, 2, 3, 6, 3, 1, 25, 2, 9, 7, 8 };
        int[] arr3 = { 4, -1, 2, 3 };
        // int[] arr2 = { 4, -1, 2, 3, 6, 3, 1, 25, 2, 9, 7, 8 };
        // QS(arr, 0, arr.Length - 1);
        // System.Console.Write(String.Join(", ", arr));
        // QuickSort2(arr2, 0 , arr2.Length-1);
        // System.Console.WriteLine();
        // System.Console.Write(String.Join(", ", arr2));
        //NOT WORKING CORRECTLY//QS_Prac(arr,0,arr.Length-1);
        System.Console.Write(String.Join(", ", arr));
    }

    static void QuickSelect_ToFindKthSmallestElement(int[] array, int k)
    {
        
    }

    static int QuickSelect_Partition(int[] array, int low, int high, int pivotIndex)
    {
        int i=low,j=low;

        while(i<pivotIndex)
        {
            if(a)
        }
    }

    static void QS(int[] arr, int lb, int ub)
    { // ub will be (arrLength-1) 
        if (lb < ub)
        {
            int pivotIndex = Partition(arr, lb, ub);
            QS(arr, lb, pivotIndex - 1);//dont touch pivot as its at its right place
            QS(arr, pivotIndex + 1, ub);
        }
    }
    static int Partition(int[] arr, int lb, int ub)
    { // returns correct pivot index
      //choose a pivot
        int pivot = arr[ub];
        int spaceMakerIndex = lb - 1;
        for (int i = lb; i < ub; i++)// we dont want the upper bound (arr[ub]) as it is assigned as pivot
        {
            if (arr[i] < pivot)
            {
                spaceMakerIndex++;
                int temp = arr[i];
                arr[i] = arr[spaceMakerIndex];
                arr[spaceMakerIndex] = temp;

            }
        }
        spaceMakerIndex++;//now we are on the index of the pivot
        //now when elements smaller than pivot are to its left, we know the pivot
        // needs to be placed next to them as it is still at the last position (arr[ub])
        //elements greater than pivot might be sitting on the left side, thats why we change pivot's position
        // to where it should actually be.
        int temp2 = pivot;//pivot can be replaced with arr[ub] also as its just the same thing
        arr[ub] = arr[spaceMakerIndex];
        arr[spaceMakerIndex] = temp2;
        return spaceMakerIndex;

    }


    static void QuickSort2(int[] arr, int lb, int ub)
    {
        if (lb < ub)
        {
            int pivotIndex = Partition2(arr, lb, ub);
            QuickSort2(arr, lb, pivotIndex - 1);
            QuickSort2(arr, pivotIndex + 1, ub);
        }
    }

    static int Partition2(int[] arr, int lb, int ub)
    {
        int pivot = arr[ub]; 
        int spaceMakerIndex=lb-1;

        for (int i = lb; i < ub; i++)
        {
            if(arr[i]<pivot){
               
                ++spaceMakerIndex;
                int temp3 = arr[spaceMakerIndex];
                arr[spaceMakerIndex] = arr[i];
                arr[i]=temp3;
            }

        }
        ++spaceMakerIndex;
        int temper = pivot;
        arr[ub] = arr[spaceMakerIndex];
        arr[spaceMakerIndex]=temper;
        return spaceMakerIndex;
        
    }

    static void QS_Prac(int[] arr, int lb, int ub)
    {
        if(lb<ub)
        {
            int pivotIndex = Partition3(arr, lb, ub);
            QS_Prac(arr, lb, pivotIndex-1);
            QS_Prac(arr, pivotIndex+1, ub);
        }
    }
    static int Partition3(int[] arr, int lb, int ub)
    {
        int mid = lb + (ub-lb)/2;
        int pivot = arr[mid];
        int spaceMakerIndex = lb-1;

        for(int i = lb; i<=ub;i++)
        {
            //if(i==mid) continue;
            if(arr[i]<pivot)
            {
                ++spaceMakerIndex;
                int temp = arr[i];
                arr[i] = arr[spaceMakerIndex];
                arr[spaceMakerIndex] = temp;
            }
        }
        ++spaceMakerIndex;
        int temp2 = arr[mid];
        arr[mid] = arr[spaceMakerIndex];
        arr[spaceMakerIndex] = temp2;

        return spaceMakerIndex;
    }
}




// We keep the base condition such that the recursion only works till the lower bound < upper bound
// so that the division of array stops when its of size 1. 
// We receive the correct pivot position from a partition function
// we then recursively divide the array on basis of the received pivot Index
// since we have the correct pivot index, we dont touch that index and divide array for pivotIndex-1 &
// pivotIndex+1 thereby not including the pivot's index. The partition function actually works to return the
// pivot index, so it doesn't exactly partition the array. Now inside the Partition fn, we choose a pivot,
// say, the last element. We also have another variable called tempIndex or spaceMakerIndex which will be less
// than the lower bound so that when we increment it, we start traversing the array form the first element.
// Its not zero as not both of the partitioned parts of the array start with zero. One starts with 0 and another
// with pivotIndex+1.
// Then we traverse through the array and check if a number is lesser than the pivot, if it is, then we increment 
// the spacemakerIndex to make space for a smaller element to be placed. This way we ensure that all elements smaller
// than the pivot are placed to its left. After this is done, we know, pivot is still at the last position and elements
// greater than it could be present before it, so we increment the spaceMakerIndex again, which gives us the correct location
// for the pivot as before that index all elements are smaller than pivot (though not necessarily in sorted order),
// so we placed the pivot there by swapping.
// This way every element of the array gets to becomes a pivot once and is placed at its correct index which is then returned
// by the partition function.