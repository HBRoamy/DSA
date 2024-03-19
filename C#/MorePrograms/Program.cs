class Program
{
    static void Main(string[] args)
    {
        // int[,] arrayWithObstacles=  new int[5,6];
        // arrayWithObstacles[0,1] = 1;
        // arrayWithObstacles[1,1] = 1;
        // arrayWithObstacles[1,3] = 1;
        // arrayWithObstacles[1,4] = 1;
        // arrayWithObstacles[3,0] = 1;
        // arrayWithObstacles[3,2] = 1;
        // arrayWithObstacles[3,4] = 1;
        // arrayWithObstacles[3,5] = 1;
        // arrayWithObstacles[4,0] = 1;

        //NQueens(4);
        int[,] chess = new int[6, 6];
        KnightsTour(chess, 2, 1, 1);//answers are either not possible in some arrays or they take exponential time

    }

    static void FloodFill(int[,] array, int sr, int sc)
    {
        //destination is 4,5 (for array[5,6])
        // or the last cell of last row 

    }
    static void NQueens(int n)
    {
        int[,] arr = new int[n, n];
        NQueensHelper(arr, n, 0, "");// for every row we have n columns as options so no need to pass those
    }
    static void NQueensHelper(int[,] arr, int n, int row, string tempDs)
    {
        // take the columns as options
        // increase row on recursive calls
        // choose column as option using a loop
        // so dont pass column in recursive call, remove it from the method signature
        //for n=2 and n=3 it doesnt work as we wont be able to place total n queens safely in arrays of those sizes
        if (row == n)
        {
            System.Console.WriteLine(tempDs + ".");
            return;
        }


        for (int col = 0; col < n; col++)
        {
            if (IsPlaceSafeForQueen(arr, row, col) == true)
            {
                arr[row, col] = 1;
                NQueensHelper(arr, n, row + 1, tempDs + " " + row + "-" + col);
                arr[row, col] = 0;// this is the actual implementation of backtracking as after we fall back from the stack,
                                  // we put 0  back in the place, in other words we are marking the spot unvisited for the future recursions
                                  // that may traverse the spot. We are not just falling but we are also taking a note of the visited and unvisited 
                                  //spots
            }

        }

    }
    static bool IsPlaceSafeForQueen(int[,] arr, int row, int col)
    {
        //we wont check for the safety of queen below the current row as we havent filled those rows yet
        for (int i = row; i >= 0; i--)
        {//checking straight up the column
            if (arr[i, col] == 1) return false;
        }

        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
        {//check left diagonal going up
            if (arr[i, j] == 1) return false;
        }
        for (int i = row, j = col; i >= 0 && j < arr.GetLength(0); i--, j++)//checking right diagonal going up
        {
            if (arr[i, j] == 1) return false;

        }

        return true;
    }
    
    static void KnightsTour(int[,] chess, int row, int col, int moveNumber)
    {
        // when we call this function from Main() then we pass moveNumber as 1 because
        // the when the Knight is already at (row,col) passed in it then it is 1st Move in itself

        // we can move the Knight in 8 directions (row-2,col+1),(row-1,col+1),(row+1,col+1),
        //(r+2,c+2),(r+2,c-2),(r+1,c-1),(r-1,c-1),(r-2,c-1)
        /*
          (r-2,c-1)_ _(r-2,c+1)
        (r-1,c-2)   |          (r-1, c+2)
               |    |         |
                - - K(r,c) - -
               |    |         |
      (r+1,c-2)    _L         (r+1,c+2) 
         (r+2,c-1)    (r+2,c+1)
        */


        if (row < 0 || col < 0 || row >= chess.GetLength(0) || col >= chess.GetLength(0) || chess[row, col] > 0)
        {
            return;
        }
        else if (moveNumber == (chess.GetLength(0) * chess.GetLength(0)))
        {
            chess[row,col] = moveNumber;// the last move wasnt put in the array as we entered the if condition so we have to put it manually
            for (int i = 0; i < chess.GetLength(0); i++)
            {
                for (int j = 0; j < chess.GetLength(0); j++)
                {
                    System.Console.Write(chess[i, j] + " ");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("__________");
            chess[row,col] = 0;// before returning we have to remove the 25th move too
            return;
        }

        chess[row, col] = moveNumber;
        KnightsTour(chess, row - 2, col + 1, moveNumber + 1);
        KnightsTour(chess, row - 1, col + 2, moveNumber + 1);
        KnightsTour(chess, row + 1, col + 2, moveNumber + 1);
        KnightsTour(chess, row + 2, col + 1, moveNumber + 1);
        KnightsTour(chess, row + 2, col - 1, moveNumber + 1);
        KnightsTour(chess, row + 1, col - 2, moveNumber + 1);
        KnightsTour(chess, row - 1, col - 2, moveNumber + 1);
        KnightsTour(chess, row - 2, col - 1, moveNumber + 1);
        chess[row, col] = 0;


    }
}