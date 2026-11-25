public static class Main
{
    public static void Main
    {

    }
}

/*
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

*/