class Program{
    static void Main(string[] args)
    {
        //LSB - Least significant bit
        //MSB - Most significant bit
        //NOTE: precedence of << and >> is even lesser than " = "

        //turn on fourth lsb using bitmask
        // int a = 179;
        // int bitmask = 1;

        // int c = a | (bitmask<<3);
        // System.Console.WriteLine(c);//187

        // //turn off fourth lsb using bitmask
        // int d = 187;
        // int mask = 1;
        // mask = mask<<3;//convert 000000001 to 00001000 then 1's complement
        // mask = ~mask;//to convert into 11110111 now using &, the fourth lsb will be set to 0
        // int e = d & mask;
        // System.Console.WriteLine(e);//179

        // //toggle a bit using Xor (while using xor, 1 is powerful)
        // int f = a ^ (bitmask<<3);
        // System.Console.WriteLine(f);//187
        // int g = d ^ (bitmask<<3);
        // System.Console.WriteLine(g);//179

        //check if a bit is on or off using bitwise &
        // int a = 179;
        // int mask = 1;
        // mask<<=4;
        // int b = a & mask;
        // System.Console.WriteLine("Is bit OFF? = " + (b==0)); 

        // for a number x, -x is its 2's complement
        //int num = 6;
        //int rightMostSetBit_Mask;
        //right most setbit mask will be num & (num)``, in other words num & 2's complement of num
        //Explanation here : (https://youtu.be/XcSr6TIMl7w)
        //int ans=0;
        //int check = num & (~(num)+1);//actual work
        //alternate way 
        //check = num & (-num); bcoz for a number x, -x is its 2's complement
        //for 2'x compl of a number, we can either have (~(x)+1), or just -x
        //kisi num ka 2's compl nikalna usko -ve banana hi to hota hai 
        //System.Console.WriteLine(Convert.ToString(check, 2));//display binary for the mask

        //not related to the actual work, just to display the position of the right most set bit
        // while(check!=1)
        // {
        //     check/=2;
        //     ans++;
        // }
        // System.Console.WriteLine(ans);

        //kernighan algo (n&(n-1)) gives rightMostSetBit
        //But if we directly want to remove rightMostSetBit, then n&(n-1) will do the trick

        Josephus_Problem_Queue(9);

    }

    #region  Unrelated
    static void Josephus_Problem_Queue(int n)
    {
        Queue<int> q = new(Enumerable.Range(1,n));
        while(q.Count!=1)
        {
            q.Enqueue(q.Dequeue());
            q.Dequeue();
        }

        System.Console.WriteLine(q.Dequeue());

    }
    #endregion
}
