class Program
{
    static void Main(string[] args)
    {

        // int n = 3;
        // string tower1 = "A", tower2 = "B", tower3 = "C";
        // TowerOfHanoi(n, tower1, tower2, tower3);

        //expectation
        toh2(10, "a", "b", "c");
        System.Console.WriteLine(counting);


    }
    static void TowerOfHanoi(int numberOfDisks, string source, string destination, string helper)
    {
        if(numberOfDisks==0){
            return; // we have nothing to say when we have no disks at all.
        }

        TowerOfHanoi(numberOfDisks-1,source,helper,destination); //2 disks from source to helper using destination
        System.Console.WriteLine("put disk "+numberOfDisks+" from " + source + " to " + destination);
        TowerOfHanoi(numberOfDisks-1 , helper, destination, source);
    }

        //expectation
    static void toh(int N, string source , string helper, string destination)
    {
        if(N==0){
            return;
        }
        
        //lets say I am solving it for 2 disks (1 & 2),  and 3 rods (a, b & c)

        // I move disk 1 from a to b 
        toh(N-1, source, destination, helper );//faith
        // Now I print how to move one disk (disk no. 2) from a to c (as I know how to)
        System.Console.WriteLine($"Move {N} from {source} to {destination}"); // faith-expectation meet here
        // then I move back disk 1 from b to c
        toh(N-1,helper,source, destination); //faith

        /*
        basically
        for 2 disks
        move disk 1 from source to helper //first recursive call
        move disk 2 from source to destination // print statement 
        move disk 1 from helper to destination // second recursive call


        hence n-1 disks will be moved from source to helper recursively
        then we ourselves print that we are moving the nth disk from source to destination
        then we move n-1 disks from helper (where they were placed in the first recursive call) to
        destination.

        sometimes destinations works as a helper sometimes source acts as a helper and the like.   
        */
    }

    public static int counting = 0;
    public static void toh2(int totalDisks, string s, string h, string d)//4th parameter represents the rod where we
                                                                         //where we want our source disk to go   
    {
        if(totalDisks==0) return;

        counting++;
        toh2(totalDisks-1, s, d, h);// in this line, s acts as source, d acts as helper and h as destination
        // 2nd parameter will always take the source of the required disk
        // 3rd will take helper, 4th will take destination
        System.Console.WriteLine($"Move disk {totalDisks} from {s} to {d}");
        toh2(totalDisks-1, h, s, d);// in this line, h acts as source, s acts as helper and d as destination

    }
}