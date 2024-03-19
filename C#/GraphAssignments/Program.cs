class Program
{
    static void Main(string[] args)
    {

        int[,] basketOfOranges = new int[3, 3]
        {
            { 1, 0, 1 },
            { 1, 1, 1 },
            { 1, 0, 2 }
            // 0 -> empty cell
            // 1 -> fresh orange
            // 2 -> rotten orange
        };
        int[,] virtualGraph = {
            // we can move top, left, bottom and right
            // 1 is water, 0 is land
            //find the number of islands ( cluster(s) of zero(s) connected together )
            { 0, 0, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 0 },
            { 1, 1, 0, 0, 0, 1, 1, 0 },
            { 1, 1, 1, 1, 0, 1, 1, 0 },
            { 1, 1, 1, 1, 0, 1, 1, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 0 },
            { 1, 1, 0, 0, 1, 1, 1, 0 }

        };

        //RottenOrangeTimeCalculator(basketOfOranges, 0);
        NumberOfIslands_Wrapper(virtualGraph,8,8);

    }
    static int NumberOfIslands_Wrapper(int[,] graph, int rows, int columns)
    {
        int totalIslands = 0;
        bool[,] visited = new bool[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (graph[i,j]==0 && !visited[i, j])
                {
                    NumberOfIslands(graph, visited, i, j);
                    totalIslands++;
                }
            }
        }

        System.Console.WriteLine(totalIslands);
        return totalIslands;
    }
    static void NumberOfIslands(int[,] graph, bool[,] visited, int x, int y)
    {
        if (IsOutOfBounds(x, y, graph) || graph[x, y] == 1 )
        {
            return;
        }
        if(visited[x,y]==true)
        {
            return;
        }
        visited[x, y] = true;

        NumberOfIslands(graph, visited, x, y - 1);
        NumberOfIslands(graph, visited, x + 1, y);
        NumberOfIslands(graph, visited, x, y + 1);
        NumberOfIslands(graph, visited, x - 1, y);

    }

    static void RottenOrangeTimeCalculator_Wrapper()
    {

    }
    static void RottenOrangeTimeCalculator(int[,] basket, int minutesCount)
    {

        int count = 0;

        Queue<int> q = new();
        bool[] visited = new bool[basket.GetLength(0)];

        for (int i = 0; i < basket.GetLength(0); i++)
        {
            if(!visited[i])
            for (int j = 0; j < basket.GetLength(1); j++)
            {
                
            }
        }
       
        

        System.Console.WriteLine(count);
    }
    static bool IsOutOfBounds(int i, int j, int[,] grid)
    {
        if (i < 0 || j < 0)
        {
            return true;
        }

        if (i >= grid.GetLength(0) || j >= grid.GetLength(1))
        {
            return true;
        }

        return false;
    }

    // -----------------------------------------------------------------------
    // static void BuildGraph1(List<Edge>[] graph1)
    // {
    //     for (int i = 0; i < graph1.Length; i++)
    //     {
    //         graph1[i] = new List<Edge>();
    //     }

    //     graph1[0].Add(new Edge(0, 1, 10));
    //     graph1[0].Add(new Edge(0, 3, 40));

    //     graph1[1].Add(new Edge(1, 0, 10));
    //     graph1[1].Add(new Edge(1, 2, 10));
    //     // graph1[1].Add(new Edge(1, 3, 10));

    //     graph1[2].Add(new Edge(2, 1, 10));
    //     graph1[2].Add(new Edge(2, 3, 10));

    //     graph1[3].Add(new Edge(3, 0, 10));
    //     // graph1[3].Add(new Edge(3, 1, 10));
    //     graph1[3].Add(new Edge(3, 2, 10));
    //     graph1[3].Add(new Edge(3, 4, 10));

    //     graph1[4].Add(new Edge(4, 3, 10));
    //     graph1[4].Add(new Edge(4, 5, 10));
    //     graph1[4].Add(new Edge(4, 6, 5));

    //     graph1[5].Add(new Edge(5, 4, 10));
    //     graph1[5].Add(new Edge(5, 6, 10));

    //     graph1[6].Add(new Edge(6, 4, 10));
    //     graph1[6].Add(new Edge(6, 5, 10));

    // }

    // static void BuildGraph2(List<Edge>[] graph1)
    // {
    //     for (int i = 0; i < graph1.Length; i++)
    //     {
    //         graph1[i] = new List<Edge>();
    //     }

    //     graph1[0].Add(new Edge(0, 1, 10));
    //     // graph1[0].Add(new Edge(0, 3, 10));

    //     graph1[1].Add(new Edge(1, 0, 10));
    //     // graph1[1].Add(new Edge(1, 2, 10));
    //     // graph1[1].Add(new Edge(1, 3, 10));

    //     // graph1[2].Add(new Edge(2, 1, 10));
    //     graph1[2].Add(new Edge(2, 3, 10));

    //     // graph1[3].Add(new Edge(3, 0, 10));
    //     // graph1[3].Add(new Edge(3, 1, 10));
    //     graph1[3].Add(new Edge(3, 2, 10));
    //     // graph1[3].Add(new Edge(3, 4, 10));

    //     // graph1[4].Add(new Edge(4, 3, 10));
    //     graph1[4].Add(new Edge(4, 5, 10));
    //     graph1[4].Add(new Edge(4, 6, 10));

    //     graph1[5].Add(new Edge(5, 4, 10));
    //     graph1[5].Add(new Edge(5, 6, 10));

    //     graph1[6].Add(new Edge(6, 4, 10));
    //     graph1[6].Add(new Edge(6, 5, 10));

    // }

    // static void BuildGraph3(List<Edge>[] graph)
    // {
    //     for (int i = 0; i < graph.Length; i++)
    //     {
    //         graph[i] = new List<Edge>();
    //     }

    //     graph[0].Add(new Edge(0, 1, 0));
    //     graph[0].Add(new Edge(0, 2, 0));

    //     graph[1].Add(new Edge(1, 0, 0));
    //     graph[1].Add(new Edge(1, 3, 0));

    //     graph[2].Add(new Edge(2, 0, 0));
    //     graph[2].Add(new Edge(2, 4, 0));

    //     graph[3].Add(new Edge(3, 1, 0));
    //     graph[3].Add(new Edge(3, 4, 0));
    //     graph[3].Add(new Edge(3, 5, 0));

    //     graph[4].Add(new Edge(4, 2, 0));
    //     graph[4].Add(new Edge(4, 3, 0));
    //     graph[4].Add(new Edge(4, 5, 0));

    //     graph[5].Add(new Edge(5, 3, 0));
    //     graph[5].Add(new Edge(5, 4, 0));
    //     graph[5].Add(new Edge(5, 6, 0));

    //     graph[6].Add(new Edge(6, 5, 0));
    // }

    // static void BuildGraph4(List<Edge>[] graph)
    // {
    //     for (int i = 0; i < graph.Length; i++)
    //     {
    //         graph[i] = new List<Edge>();
    //     }

    //     /*
    //         5       4
    //         | \   / |
    //         |  V V  |
    //         |   0   |
    //         V       V
    //         2-->3-->1
    //     */

    //     graph[2].Add(new Edge(2, 3, 0));

    //     graph[3].Add(new Edge(3, 1, 0));

    //     graph[4].Add(new Edge(4, 0, 0));
    //     graph[4].Add(new Edge(4, 1, 0));

    //     graph[5].Add(new Edge(5, 0, 0));
    //     graph[5].Add(new Edge(5, 2, 0));
    // }

    // static List<Edge>[] BuildGraph5()
    // {
    //     List<Edge>[] graph = new List<Edge>[5];
    //     for (int i = 0; i < graph.Length; i++)
    //     {
    //         graph[i] = new List<Edge>();
    //     }



    //     //graph[0].Add(new Edge(0, 3, 0));

    //     graph[1].Add(new Edge(1, 0, 0));

    //     graph[2].Add(new Edge(2, 0, 0));
    //     graph[2].Add(new Edge(2, 4, 0));

    //     graph[3].Add(new Edge(3, 2, 0));

    //     graph[4].Add(new Edge(4, 3, 0));

    //     return graph;
    // }

    // static List<Edge>[] BuildGraph6()
    // {
    //     List<Edge>[] graph = new List<Edge>[6];
    //     for (int i = 0; i < graph.Length; i++)
    //     {
    //         graph[i] = new List<Edge>();
    //     }



    //     graph[0].Add(new Edge(0, 1, 2));
    //     graph[0].Add(new Edge(0, 2, 4));

    //     graph[1].Add(new Edge(1, 2, 1));
    //     graph[1].Add(new Edge(1, 3, 7));

    //     graph[2].Add(new Edge(2, 4, 3));

    //     graph[3].Add(new Edge(3, 5, 1));

    //     graph[4].Add(new Edge(4, 3, 2));
    //     graph[4].Add(new Edge(4, 5, 5));

    //     return graph;
    // }
    // static List<Edge>[] BuildGraph7_4Nodes()
    // {
    //     List<Edge>[] graph = new List<Edge>[4];
    //     for (int i = 0; i < graph.Length; i++)
    //     {
    //         graph[i] = new List<Edge>();
    //     }



    //     graph[0].Add(new Edge(0, 1, 10));
    //     graph[0].Add(new Edge(0, 2, 15));
    //     graph[0].Add(new Edge(0, 3, 30));

    //     graph[1].Add(new Edge(1, 3, 40));

    //     graph[2].Add(new Edge(2, 3, 50));

    //     graph[3].Add(new Edge(3, 1, 40));
    //     graph[3].Add(new Edge(3, 2, 50));

    //     return graph;
    // }

    class Edge
    {
        public int source;
        public int neighbor; //destination

        public int weight;

        public Edge(int src, int nbr, int wght)
        {
            source = src;
            neighbor = nbr;
            weight = wght;
        }
    }
}

// Dumped Code
/*
int count = 0;

        for (int i = 0; i < basket.GetLength(0); i++)
        {
            for (int j = 0; j < basket.GetLength(1); j++)
            {
                if (basket[i, j] == 2)
                {
                    bool posStatusLeft = IsOutOfBounds(i - 1, j, basket);
                    bool posStatusRight = IsOutOfBounds(i + 1, j, basket);
                    bool posStatusUp = IsOutOfBounds(i, j - 1, basket);
                    bool posStatusDown = IsOutOfBounds(i, j + 1, basket);
                    int change = 0;
                    if (!posStatusLeft)
                    {
                        if (basket[i - 1, j] == 1)
                        {
                            basket[i - 1, j] = 2;
                            change++;
                        }
                    }
                    if (!posStatusRight)
                    {
                        if (basket[i + 1, j] == 1)
                        {
                            basket[i + 1, j] = 2;
                            change++;

                        }
                    }
                    if (!posStatusUp)
                    {
                        if (basket[i, j - 1] == 1)
                        {
                            basket[i, j - 1] = 2;
                            change++;

                        }
                    }
                    if (!posStatusDown)
                    {
                        if (basket[i, j + 1] == 1)
                        {
                            basket[i, j + 1] = 2;
                            change++;

                        }
                    }

                    if (change > 0)
                    {
                        count++;
                    }

                }
            }
        }
        for (int i = 0; i < basket.GetLength(0); i++)
        {
            for (int j = 0; j < basket.GetLength(1); j++)
            {
                if(basket[i,j]==1)
                {
                    System.Console.WriteLine(-1);
                    return;
                }
            }
        }
*/