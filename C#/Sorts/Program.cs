class Program
{
    static void Main(string[] args)
    {
        int[] arr = {2,5,1,4,3,1,2,9,8,7};
        InsertionSort(arr);
        System.Console.WriteLine(string.Join(", ",arr));
        
    }

    public static void InsertionSort(int[] arr)
    {
        int arrLength = arr.Length;
        for (int i = 1; i < arrLength; i++)
        {
            for (int j = i - 1; j >= 0; j--)//reverse bubbling
            {
                if (arr[j] > arr[j+1])
                {
                    int t = arr[j];
                    arr[j] = arr[j+1];
                    arr[j+1] = t;
                }
                else
                {
                    break;
                }
            }
        }
    }
}