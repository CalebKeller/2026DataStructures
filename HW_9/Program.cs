
public static class Main
{
    public static void Main()
    {
        Graph newGraph = new Graph();

        newGraph.AddEdge(0, 1);
        newGraph.AddEdge(1, 2);
        newGraph.AddEdge(0, 3);
        newGraph.AddEdge(3, 4);
        newGraph.AddEdge(1, 4);
        newGraph.AddEdge(6, 7);
        newGraph.AddEdge(4, 6);
        newGraph.AddEdge(2, 5);
        newGraph.AddEdge(4, 5);
        newGraph.AddVertex(8);
    }
}



/*

A1-A9, Answers

    7 Edges

    A1. 0 -> [1, 4]
        1 -> [0, 2, 3]
        2 -> [1, 3]
        3 -> [1, 2, 4]
        4 -> [0, 3, 5]
        5 -> [4]
    
    A2.     0   1   2   3   4   5
        0   0   1   0   0   1   0
        1   1   0   1   1   0   0
        2   0   1   0   1   0   0
        3   0   1   1   0   1   0
        4   1   0   0   1   0   1
        5   0   0   0   0   1   0
    
        This has 2*E 1s, because each vertex has the edge connecting to the other vertex (1*E) and
        the other vertex has a connection the the first vertex (the second 1*E, which becomes 2*E).
        There are 14 1s in this 6 by 6 adjecency matrix.
    
    A3.
        0: 2
        1: 3
        2: 2
        3: 3
        4: 3
        5: 1
        total: 14, which is 2*E

    A4. BFS
          |   Vertex Taken Out    |   Added to Queue    |   Queue After Change  |   
        0 |          _            |         0           |          [0]          |
        1 |          0            |        1, 4         |        [1, 4]         |
        2 |          1            |         2           |        [4, 2]         |
        3 |          4            |         5           |        [2, 5]         |
        4 |          2            |         3           |        [5, 3]         |
        5 |          5            |        none         |          [3]          |
        6 |          3            |        none         |        [EMPTY]        |

        Final BFS Order: 0, 1, 4, 2, 5, 3
    
    A5. DFS
        Final DFS Order: 0, 1, 2, 3, 4, 5

        As 5 is checked, there is no new vertices found, therefore it ends. The Call Stack is
        identical to the final DFS order on the last vertex visited (5)
    
    A6. The traversal that finds the shortest path from 2 to 5 is DFS.
        Shortest path: 2 -> 3 -> 4 -> 5
        This is because any other path is 4 or more, and BFS doesn't go in the needed path.
    
    A7. Cycle: 1 -> 2 -> 3 -> 1

    A8. 
        New Adjacency list:
            0 -> [1, 4]
            1 -> [0, 2]
            2 -> [1]
            4 -> [0, 5]
            5 -> [400]
    
        The list is still connected since one can iterate from 0, to 1, to 2, back to 0, to 4, and to 5.

    A9. 
        There are 10,000 Vertices and 300,000 Edges.

        For an adjacency matrix, it has O(V^2) memory, meaning 100,000,000 in memory.

        For an adjacency list on the other hand, it only has O(V+E) memory, meaning
        it has 310,000 in memory. Therefore, it should use an adjacency list.
*/

