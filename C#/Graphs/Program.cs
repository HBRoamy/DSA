class Program
{
    static void Main(string[] args)
    {
        // TRY implementing Graph using Linked lists
        // LinkedList<LinkedList<Edge>>
        /*
        Graph Coloring
        Kahn's Algo for topological sort
        Print All topological Sorts
        topological Sort in weighted graph
        longest arm/ width in graph
        Topological Sort Iterative
        Shortest path in an unweighted graph
        Kruskal's Algo for MST
        */


        int totalVertices = 7;//0, 1, 2, 3, 4, 5 ,6
                              //vertices and edges are different
        List<Edge>[] graph1 = new List<Edge>[totalVertices];
        List<Edge>[] graph3 = new List<Edge>[totalVertices];
        List<Edge>[] graph4 = new List<Edge>[6];
        BuildGraph1(graph1);
        /*
            BuildGraph1(graph1)
            0 ---- 3 ----- 4
            |      |      |  \
            |      |      |   \
            1 ---- 2      5 ---6

        */
        // BuildGraph2(graph1);

        BuildGraph3(graph3);

        /*
            BuildGraph3(graph3);
                1 ---- 3
              /        | \
             0         |  5 ---- 6
              \        | /
               2 ------4   
        */

        //We use visited[] array in graphs as graphs can contain cycle
        // while trees don't have cycles in them
        bool[] visited = new bool[totalVertices];
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
            { 1, 1, 1, 1, 1, 1, 1, 0 }

        };

        // var ans = IsPathPresent(graph1, 0, 6, visited);
        // System.Console.WriteLine(ans);
        //PrintAllPaths_DepthFirst(graph1, 0, 6, new List<int>(), visited);
        //GetConnectedComponents_Wrapper(graph1, visited);// Use BuildGraph2 methods for this
        BuildGraph4(graph4);

        // System.Console.WriteLine(CycleDetection_DirectedGraphs(graph5));
        // var graph = BuildGraph4(graph1);

        // PrimsAlgo_MinimumSpanningTree_MST(graph, 0, 4);
        TopologicalSortDFS_Wrapper(graph4);


    }
    // -----------------------------------------------------------------------

    // find ceil, floor of a given number in graph and tree

    static void ShortestPathInTermsOfEdges()
    {
        // use BFS
    }
    static void IterativeDFS()
    {
        // almost same as BFS, just replace the queue with a stack
    }

    static void PrimsAlgo_MinimumSpanningTree_MST(List<Edge>[] graph, int source, int V)
    {
        /*
            TC = O(E.LogE) because whenever we insert an edge in PQ, it wiil take E.LogE time if all edges are to be added (Worst Case)

            MST is subset of the edges of a WEIGHTED UNDIRECTED graph
            It contains all the vertices of the weighted UNDIRECTED graph but lesser number of edges
            The Mst is a connected Graph
            It contains no cycles (thats why called a tree)
            IMPORTANT - ITS HAS MINIMUM POSSIBLE TOTAL EDGE WEIGHT

            SIMPLY PUT
            1. All vertices present
            2. All Connected (i.e., graph is single component)
            3. No Cycles
            4. Minimum Possible Edge Weight
            
        */

        PriorityQueue<int, int> pq = new PriorityQueue<int, int>(); // Acts as Non MST Set (All unvisited Nodes)
        bool[] visited = new bool[V]; // Acts as MST Set
        int cost = 0;
        List<Edge> mstEdges = new List<Edge>();
        pq.Enqueue(source, 0);

        while (pq.Count != 0)
        {
            pq.TryDequeue(out int current, out int edgeWt);//node got in 'current' and priority got in 'edgeWt'

            if (visited[current] == false)
            {
                visited[current] = true;
                cost += edgeWt;
                mstEdges.Add(new Edge(current, -1, edgeWt));//Not working the way i want

                foreach (Edge edge in graph[current])
                {
                    if (visited[edge.neighbor] == false)
                    {

                        pq.Enqueue(edge.neighbor, edge.weight);
                    }
                }
            }
        }
        System.Console.WriteLine("Min cost of MST: " + cost);
        foreach (var edge in mstEdges)
        {
            System.Console.WriteLine(edge.source + $" --({edge.weight})");
        }
    }

    static void BellmanFordShortestPath(List<Edge>[] graph, int source, int V)
    {
        // TC = O(V.E) as even if we need 2 for loops to access every edge, all in all we are just traversing E edges, V-1 times so its 
        // (V-1).E ~~ V.E . Also we need to traverse every edge on every iteration

        // shortest path/cost from source to all nodes
        // works with negative edge weights also
        // can detect negative weight cycles too

        // but DOESN'T WORK for negative weight cycles (i.e., when sum of weights of all edges of a cycle is less than zero)
        // there is no sense in calculating shortest path in negative weight cycle because for e.g. if we sit on a node, it takes 0
        // minutes to travel to the same node as we are already there; but in negative weight cycles, if it takes -2 seconds to reach that node
        // and -2 being less than zero, then it makes it quicker to reach our node than staying at the node, which doesnt make any sense.

        // Its an example of Dynamic Programming as Relaxation is a bottom-up approach and is used in a loop
        // To reach a node from a source node, we can travel atmost V-1 nodes (except for negative weight cycles), hence we run it V-1 times
        // more time taken as compared to Dijkstra's Algo
        // We run a loop for V-1 times and perform relaxation for every edge

        int[] distanceFromSourceTo = new int[V];

        for (int a = 0; a < distanceFromSourceTo.Length; a++)
        {
            if (a != source)
            {
                distanceFromSourceTo[a] = int.MaxValue;
            }
        }

        for (int i = 0; i < V - 1; i++)//running loop V-1 times, V being the number of vertices in the graph
        {
            for (int j = 0; j < V; j++)// accessing every edge (on every iteration of the above loop) using 2 for loops
                                       // below (1 forloop and 1 foreach loop here)
            {
                foreach (Edge edge in graph[j])
                {
                    int src = edge.source;
                    int nbr = edge.neighbor;

                    //RELAXATION
                    // distanceFromSourceTo[src]!=int.MaxValue --> this statement is added to prevent (infinity + somenumber) overflow
                    // not really necessary in C#, but important in Java
                    if (distanceFromSourceTo[src] != int.MaxValue && distanceFromSourceTo[nbr] > distanceFromSourceTo[src] + edge.weight)
                    {
                        distanceFromSourceTo[nbr] = distanceFromSourceTo[src] + edge.weight;
                    }
                }
            }
        }

        // we can run the above loops one more time (total V times instead of V-1 times ) and the resulting array is not the same
        // as the V-1 times array, then we know there is a negative weight cycle present. Like this

        //THE CODE BELOW IS OPTIONAL AND NOT NECESSARY FOR BELLMAN FORD ALGO
        for (int j = 0; j < V; j++)
        {
            foreach (Edge edge in graph[j])
            {
                int src = edge.source;
                int nbr = edge.neighbor;

                //RELAXATION
                // distanceFromSourceTo[src]!=int.MaxValue --> this statement is added to prevent (infinity + somenumber) overflow
                // not really necessary in C#, but important in Java
                if (distanceFromSourceTo[src] != int.MaxValue && distanceFromSourceTo[nbr] > distanceFromSourceTo[src] + edge.weight)
                {
                    System.Console.WriteLine("Negative cycle present");
                    return;
                }
            }
        }

        System.Console.WriteLine(String.Join(", ", distanceFromSourceTo));
    }

    static void DjikstraShortestPath(List<Edge>[] graph, int source)
    {
        //TC = O(E + ELogV) where ELogV is given by Priority Queue, plus E is for traversing every edge

        //used mainly for DAGs
        //works with cyclic graphs also
        //Its an example of Greedy Algorithm
        //doesn't work for negative weights

        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        int[] distanceFromSource = new int[graph.Length];
        bool[] visited = new bool[graph.Length];

        pq.Enqueue(source, 0); // Enqueuing source and its distance from source, which is 0.

        for (int i = 0; i < distanceFromSource.Length; i++)
        {
            if (i != source)
            {
                distanceFromSource[i] = int.MaxValue;
            }
        }

        while (pq.Count != 0)
        {
            int shortest = pq.Dequeue();
            
            if (visited[shortest] == false)
            {
                visited[shortest] = true;


                foreach (Edge edge in graph[shortest])
                {
                    int src = edge.source;
                    int nbr = edge.neighbor;
                    if ((distanceFromSource[src] + edge.weight) < distanceFromSource[nbr])//relaxation
                    {
                        distanceFromSource[nbr] = distanceFromSource[src] + edge.weight;
                        pq.Enqueue(nbr, distanceFromSource[nbr]);// Enqueuing neighbor and its distance from source
                    }

                }
            }
        }

        System.Console.WriteLine(String.Join(", ", distanceFromSource));

    }

    static void TopologicalSortDFS_Wrapper(List<Edge>[] graph)
    {
        Stack<int> stack = new Stack<int>();
        bool[] visited = new bool[graph.Length];
        for (int i = 0; i < graph.Length; i++)
        {
            if (visited[i] == false)
            {
                TopologicalSortDFS(graph, i, stack, visited);
            }
        }
        while (stack.Count > 0)
        {
            System.Console.Write(stack.Pop() + " ");
        }
    }

    static void TopologicalSortDFS(List<Edge>[] graph, int current, Stack<int> stack, bool[] visited)
    {
        /*
            TC - O(V+E)

            Topological Sort is used only for Directed Acyclic Graphs (Directed graphs with No cycles or DAG)
            It is mainly used where we have to check dependency order
            We use stack here
            We use DFS here

            Faith-Expectation method works well here

            first we push nodes-dependent-on-current-node to the stack
            and then we push the node itself

            Basically, we want to push first our neighbors in stack and then ourselves, recursively
        */
        visited[current] = true;
        foreach (var edge in graph[current])// my neighbors depend on me so I will firstly add them in stack using this loop
        {
            if (visited[edge.neighbor] == false)
            {
                TopologicalSortDFS(graph, edge.neighbor, stack, visited);
            }
        }
        // System.Console.Write(current + " ");

        stack.Push(current);// pushing the current element post recursion as
                            // its neighbors must have been added in the stack during recursion
                            // this way higher priorities stay on top levels of stack

    }

    static int CountNumberOfCyclesInUndirectedGraph()
    {
        return -1;
    }
    static void PrintAllCycles()
    {

    }
    static bool DetectNegativeWeightCycle()
    {
        return false;
    }
    static bool CycleDetection_DirectedGraphs(List<Edge>[] graph)
    {
        // IMPORTANT: Treat this graph like a Disconnected Graph
        // as sometimes you will have no way to visit some the vertices
        // which points to no one but others point to it
        // hence use a loop in a wrapper function to access all those vertices
        // if neighbor is present in recursion/call stack
        // then return true as you found a cycle
        // so use another boolean array mockCallStack[]
        // Also, assign visited=true but dont unvisit
        // while assign mockCallStack = true and then false after
        // the recursive arm

        bool ans = false;
        bool[] visited = new bool[graph.Length];
        for (int i = 0; i < graph.Length; i++)
        {
            if (visited[i] == false)
            {
                ans = CycleDetection_DirectedGraphs_Helper(graph, i, visited, new bool[graph.Length]);
                if (ans) return true;
            }
        }

        return ans;
    }
    static bool CycleDetection_DirectedGraphs_Helper(List<Edge>[] graph, int current, bool[] visited, bool[] mockCallStack)
    {
        visited[current] = true;
        mockCallStack[current] = true;

        foreach (var edge in graph[current])
        {
            if (mockCallStack[edge.neighbor] == true)// obviously it can only be true if it has been visited
                                                     // so no need to check visited[edge.neighbor]==true
            {
                return true;
            }
            else
            {
                if (visited[edge.neighbor] == false)
                {
                    bool cycleStatus = CycleDetection_DirectedGraphs_Helper(graph, edge.neighbor, visited, mockCallStack);
                    if (cycleStatus)
                    {
                        return true;
                    }
                }

            }
        }

        mockCallStack[current] = false;
        return false;
    }

    static bool CycleDetection_UndirectedGraphs_DFS(List<Edge>[] graph, int currentNode, int parentOfCurrentNode, bool[] visited)
    {
        //if neighbor is visited but it isnt the parent of the current Node then its a cycle hence return true

        visited[currentNode] = true;
        System.Console.Write(currentNode + " \n");
        foreach (var edge in graph[currentNode])
        {
            if (visited[edge.neighbor] == true && edge.neighbor != parentOfCurrentNode)
            {
                return true;
            }
            else if (visited[edge.neighbor] == false)
            {
                bool isPathPresent = CycleDetection_UndirectedGraphs_DFS(graph, edge.neighbor, currentNode, visited);
                if (isPathPresent)
                {
                    return true;
                }
            }

        }
        visited[currentNode] = false;

        return false;
    }

    static void PrintAllPathsFromSourceToTarget_BFS(List<Edge>[] graph, int source, int target, List<int> ds, bool[] visited)
    {
        //NOT WORKING YET
        Queue<int> q = new Queue<int>();

        q.Enqueue(source);
        while (q.Count > 0)
        {
            int first = q.Dequeue();

            if (visited[first] == false)
            {
                if (first == target)
                {
                    ds.Add(first);
                    System.Console.WriteLine(String.Join(", ", ds));

                }
                else
                {
                    visited[first] = true;
                    ds.Add(first);
                    foreach (var edge in graph[first])
                    {
                        q.Enqueue(edge.neighbor);
                    }
                }


            }



        }

    }

    static void PrintAllPathsFromSourceToTarget_DFS(List<Edge>[] graph, int source, int target, string path, bool[] visited)
    {
        //TIME Complexity : O(V^V) exponential time complexity
        //Pass source as the path to get it included in the all the paths
        //like this PrintAllPathsFromSourceToTarget_DFS(graph3, 0, 6 ,"0", visited);
        if (source == target)
        {
            System.Console.WriteLine(path);
            return;
        }

        visited[source] = true;
        foreach (var edge in graph[source])
        {
            if (visited[edge.neighbor] == false)
            {
                PrintAllPathsFromSourceToTarget_DFS(graph, edge.neighbor, target, path + edge.neighbor, visited);
            }
        }
        visited[source] = false;
    }

    static void DisconnectedGraphsDFS_Wrapper(List<Edge>[] graph, bool[] visited)
    {
        //It works even for disconnected graphs
        for (int i = 0; i < graph.Length; i++)
        {
            if (visited[i] == false)
            {
                PrintGraphDFS(graph, i, visited);
            }
        }
    }

    static void PrintGraphDFS(List<Edge>[] graph, int startingVertex, bool[] visited)
    {
        // Same Time complexity as BFS , i.e., O(V+E)
        visited[startingVertex] = true;
        System.Console.Write(startingVertex + " ");
        foreach (var edge in graph[startingVertex])
        {
            if (visited[edge.neighbor] == false)
            {
                PrintGraphDFS(graph, edge.neighbor, visited);
            }
        }


    }

    static void DisconnectedGraphsBFS_Wrapper(List<Edge>[] graph, bool[] visited)
    {
        //It works even for disconnected graphs
        for (int i = 0; i < graph.Length; i++)
        {
            if (visited[i] == false)
            {
                PrintGraph3UsingBFS(graph, i, visited);
            }
        }
    }
    static void PrintGraph3UsingBFS(List<Edge>[] graph, int startingVertex, bool[] visited)
    {
        //Time complexity = O(Vertices + Edges) as we visit V vertices and also their edges while visiting every vertex
        // It is like O(N) despite a forloop inside a while loop
        // if Vertices are very high in number, it can be O(V),
        // so is the case if edges are very high in number, O(E)

        //IMPORTANT
        // if the graph contains disconnected components
        // iterate through all the vertices
        // then check if its visited or not and so on.....
        // That means q.Count==0 doesnt necessarily mean that the graph has 
        // been traversed that way we will Enqueue startingVertex if its not visited
        // easier way to do this is by using a forloop in Main() or a wrapper function
        // and then we loop PrintGraph3UsingBFS(startingIndex) for startingIndex
        // only if that index is not visited
        /*
            Example of graph with disconnected components

            0---1---2

            3---4
        */
        Queue<int> q = new Queue<int>();
        q.Enqueue(startingVertex);
        while (q.Count > 0)
        {
            int top = q.Dequeue();
            if (visited[top] == false)
            {
                visited[top] = true;
                System.Console.Write(top + " ");


                foreach (var edge in graph[top])
                {
                    // if(visited[edge.neighbor]==false)
                    q.Enqueue(edge.neighbor);
                }
            }
            // when searching we can stop the traversing as follows
            // that is break it when you find the number
            // if (top == numberYouAreLookingFor)
            // {
            //     System.Console.WriteLine("found");
            //     break;
            // }
        }


    }

    static void GetConnectedComponents_Wrapper(List<Edge>[] graph, bool[] visited)
    {
        List<List<int>> ans = new List<List<int>>();


        for (int i = 0; i < graph.Length; i++)
        {
            if (visited[i] == false)
            {
                List<int> tempDs = new List<int>();
                GetConnectedComponents(graph, visited, tempDs, i);
                ans.Add(new List<int>(tempDs));

            }
        }

        foreach (var item in ans)
        {
            foreach (var data in item)
            {
                System.Console.Write(data + " ");
            }
            System.Console.WriteLine();
        }

    }
    static void GetConnectedComponents
    (
     List<Edge>[] graph,
     bool[] visited,
     List<int> tempDs,
     int source
     )
    {

        visited[source] = true;
        tempDs.Add(source);
        foreach (var edge in graph[source])
        {
            if (visited[edge.neighbor] == false)
            {
                GetConnectedComponents(graph, visited, tempDs, edge.neighbor);
            }
        }

    }
    static void PrintAllPaths_DepthFirst(List<Edge>[] graph, int source, int destination, List<int> tempDs, bool[] visited)
    {
        if (source == destination)
        {
            tempDs.Add(destination);// adding here as we wont reach the tempDs.Add(source) line in this if block
            foreach (var item in tempDs)
            {
                System.Console.Write(item);
            }
            System.Console.WriteLine();
            tempDs.Remove(destination);// removing here as we wont reach the tempDs.Remove(source) line in this if block 
            return;
        }
        visited[source] = true;
        tempDs.Add(source);
        foreach (var edge in graph[source])
        {
            if (visited[edge.neighbor] == false)
            {
                PrintAllPaths_DepthFirst(graph, edge.neighbor, destination, tempDs, visited);
            }

        }
        tempDs.Remove(source);
        visited[source] = false;

    }
    static bool IsPathPresent_DepthFirst(List<Edge>[] graph, int source, int destination, bool[] visited)
    {
        if (source == destination)
        {
            return true;
        }

        visited[source] = true;
        foreach (var edge in graph[source])//graph[source] is the List<Edge> which which contains all 
                                           //edges from source to its neighbors 
        {
            if (visited[edge.neighbor] == false)
            {
                var doesThisNeighborHaveAPathToDestination = IsPathPresent_DepthFirst(graph, edge.neighbor, destination, visited);
                if (doesThisNeighborHaveAPathToDestination == true) return true;
            }

        }
        return false;
    }

    // -----------------------------------------------------------------------
    static void BuildGraph1(List<Edge>[] graph1)
    {
        for (int i = 0; i < graph1.Length; i++)
        {
            graph1[i] = new List<Edge>();
        }

        graph1[0].Add(new Edge(0, 1, 10));
        graph1[0].Add(new Edge(0, 3, 40));

        graph1[1].Add(new Edge(1, 0, 10));
        graph1[1].Add(new Edge(1, 2, 10));
        // graph1[1].Add(new Edge(1, 3, 10));

        graph1[2].Add(new Edge(2, 1, 10));
        graph1[2].Add(new Edge(2, 3, 10));

        graph1[3].Add(new Edge(3, 0, 10));
        // graph1[3].Add(new Edge(3, 1, 10));
        graph1[3].Add(new Edge(3, 2, 10));
        graph1[3].Add(new Edge(3, 4, 10));

        graph1[4].Add(new Edge(4, 3, 10));
        graph1[4].Add(new Edge(4, 5, 10));
        graph1[4].Add(new Edge(4, 6, 5));

        graph1[5].Add(new Edge(5, 4, 10));
        graph1[5].Add(new Edge(5, 6, 10));

        graph1[6].Add(new Edge(6, 4, 10));
        graph1[6].Add(new Edge(6, 5, 10));

    }

    static void BuildGraph2(List<Edge>[] graph1)
    {
        for (int i = 0; i < graph1.Length; i++)
        {
            graph1[i] = new List<Edge>();
        }

        graph1[0].Add(new Edge(0, 1, 10));
        // graph1[0].Add(new Edge(0, 3, 10));

        graph1[1].Add(new Edge(1, 0, 10));
        // graph1[1].Add(new Edge(1, 2, 10));
        // graph1[1].Add(new Edge(1, 3, 10));

        // graph1[2].Add(new Edge(2, 1, 10));
        graph1[2].Add(new Edge(2, 3, 10));

        // graph1[3].Add(new Edge(3, 0, 10));
        // graph1[3].Add(new Edge(3, 1, 10));
        graph1[3].Add(new Edge(3, 2, 10));
        // graph1[3].Add(new Edge(3, 4, 10));

        // graph1[4].Add(new Edge(4, 3, 10));
        graph1[4].Add(new Edge(4, 5, 10));
        graph1[4].Add(new Edge(4, 6, 10));

        graph1[5].Add(new Edge(5, 4, 10));
        graph1[5].Add(new Edge(5, 6, 10));

        graph1[6].Add(new Edge(6, 4, 10));
        graph1[6].Add(new Edge(6, 5, 10));

    }

    static void BuildGraph3(List<Edge>[] graph)
    {
        for (int i = 0; i < graph.Length; i++)
        {
            graph[i] = new List<Edge>();
        }

        graph[0].Add(new Edge(0, 1, 0));
        graph[0].Add(new Edge(0, 2, 0));

        graph[1].Add(new Edge(1, 0, 0));
        graph[1].Add(new Edge(1, 3, 0));

        graph[2].Add(new Edge(2, 0, 0));
        graph[2].Add(new Edge(2, 4, 0));

        graph[3].Add(new Edge(3, 1, 0));
        graph[3].Add(new Edge(3, 4, 0));
        graph[3].Add(new Edge(3, 5, 0));

        graph[4].Add(new Edge(4, 2, 0));
        graph[4].Add(new Edge(4, 3, 0));
        graph[4].Add(new Edge(4, 5, 0));

        graph[5].Add(new Edge(5, 3, 0));
        graph[5].Add(new Edge(5, 4, 0));
        graph[5].Add(new Edge(5, 6, 0));

        graph[6].Add(new Edge(6, 5, 0));
    }

    static void BuildGraph4(List<Edge>[] graph)
    {
        for (int i = 0; i < graph.Length; i++)
        {
            graph[i] = new List<Edge>();
        }

        /*
            5       4
            | \   / |
            |  V V  |
            |   0   |
            V       V
            2-->3-->1
        */

        graph[2].Add(new Edge(2, 3, 0));

        graph[3].Add(new Edge(3, 1, 0));

        graph[4].Add(new Edge(4, 0, 0));
        graph[4].Add(new Edge(4, 1, 0));

        graph[5].Add(new Edge(5, 0, 0));
        graph[5].Add(new Edge(5, 2, 0));
    }

    static List<Edge>[] BuildGraph5()
    {
        List<Edge>[] graph = new List<Edge>[5];
        for (int i = 0; i < graph.Length; i++)
        {
            graph[i] = new List<Edge>();
        }



        //graph[0].Add(new Edge(0, 3, 0));

        graph[1].Add(new Edge(1, 0, 0));

        graph[2].Add(new Edge(2, 0, 0));
        graph[2].Add(new Edge(2, 4, 0));

        graph[3].Add(new Edge(3, 2, 0));

        graph[4].Add(new Edge(4, 3, 0));

        return graph;
    }

    static List<Edge>[] BuildGraph6()
    {
        List<Edge>[] graph = new List<Edge>[6];
        for (int i = 0; i < graph.Length; i++)
        {
            graph[i] = new List<Edge>();
        }



        graph[0].Add(new Edge(0, 1, 2));
        graph[0].Add(new Edge(0, 2, 4));

        graph[1].Add(new Edge(1, 2, 1));
        graph[1].Add(new Edge(1, 3, 7));

        graph[2].Add(new Edge(2, 4, 3));

        graph[3].Add(new Edge(3, 5, 1));

        graph[4].Add(new Edge(4, 3, 2));
        graph[4].Add(new Edge(4, 5, 5));

        return graph;
    }
    static List<Edge>[] BuildGraph7_4Nodes()
    {
        List<Edge>[] graph = new List<Edge>[4];
        for (int i = 0; i < graph.Length; i++)
        {
            graph[i] = new List<Edge>();
        }



        graph[0].Add(new Edge(0, 1, 10));
        graph[0].Add(new Edge(0, 2, 15));
        graph[0].Add(new Edge(0, 3, 30));

        graph[1].Add(new Edge(1, 3, 40));

        graph[2].Add(new Edge(2, 3, 50));

        graph[3].Add(new Edge(3, 1, 40));
        graph[3].Add(new Edge(3, 2, 50));

        return graph;
    }
}
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