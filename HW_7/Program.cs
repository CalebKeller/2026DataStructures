/*
|-------                                                  --- Answers ---                                                 --------|
|                                                                                                                                 |
| - Part 1 -                                                                                                                      |
| 1) A balanced tree is a binary tree which has an equal height on both of its left and right "sides".                            |
| Because of this balanced height, it is far more effectient in the long term to locate, insert, and delete elements.             |
|                                                                                                                                 |
| 2)                                                                                                                              |
|                                                                                                                                 |
|       Not Balanced:                                                                                                             |
|                                                                                                                                 |
|          10         h = 4                                                                                                       |
|            \                                                                                                                    |
|             20         h = 3                                                                                                    |
|               \                                                                                                                 |
|                30         h = 2                                                                                                 |
|                  \                                                                                                              |
|                   40         h = 1                                                                                              |
|                     \                                                                                                           |
|                      50         h = 0                                                                                           |
|                                                                                                                                 |
| -----                                                                                                                           |
|                                                                                                                                 |
|       Balanced:                                                                                                                 |
|                                                                                                                                 |
|                           30   h = 2                                                                                            |
|                          /  \                                                                                                   |
|                        20    40   h = 1                                                                                         |
|                       /        \                                                                                                |
|                     10          50    h = 0                                                                                     |
| -----                                                                                                                           |
|                                                                                                                                 |
|          The height is 4. You visit 5 nodes (including the root) to find 50. The height would be 2 if it were balanced.         |
| 3) The balance factor of a node is the numerical value of the difference between the heights of the left and right sides.       |                     |
| The balance factort values allowed in an AVL tree are -1, 0, and 1.                                                             |
| 4) Search in an AVL tree is O(log n) because it is easier to narrow down the search logarithmically because of its balance.     |
| A plain BST can sometimes even be similar to a linked-list, where one has to search up to every node to find the one to delete  |
| or find, or even to insert something.                                                                                           |
| 5)                                                                                                                              |
|                                                                                                                                 |
|           50                                                                                                                    |
|         /    \                                                                                                                  |
|       30      70                                                                                                                |
|      /  \       \                                                                                                               |
|    20    40      80                                                                                                             |
|   /                \                                                                                                            |
| 10                  90                                                                                                          |
|                                                                                                                                 |
|   10: h = 0 | bf: 0
|   20: h = 1 | bf: +1
|   30: h = 2 | bf: +1
|   40: h = 0 | bf: 0
|   50: h = 3 | bf: 0
|   70: h = 2 | bf: -2 X (too imbalanced)
|   80: h = 1 | bf: -1
|   90: h = 0 | bf: 0
| This is not an AVL tree because of the Node 70, every other node is valid for an AVL tree.                      
|                                                                    
| - Part 2 -
|
| 6)
|   a)
|       33, h=0, bf= 0
|   
|   b)
|               33 (h = 1; bf = +1)
|              /
|            18 (h = 0; bf= 0)
|
|   c)
|               33 (h = 2; bf = +2)
|              /
|            18 (h = 1; bf= +1)
|           /
|          7 (h = 0; bf= 0)
|
|       c.1)
|           LL at Node 33
|               18
|              /  \
|             7    33
|   d)
|                    18 (h = 2; bf= -1)
|                   /  \
| (h = 0; bf = 0)  7    33 (h = 1; bf= +1)
|                       /
|                      25 (h = 0; bf= 0)
|   e)
|                    18 (h = 3; bf = -1)
|                   /  \
| (h = 1; bf = -1) 7    33 (h = 2; bf = +1)
|                       /
|                      25 (h = 1; bf = 0)
|                       \
|                        29 (h = 0; bf = 0)
|           e.1)
|               LR at node 33
|                    18
|                   /  \
|                  7    25
|                         \
|                          29
|                            \
|                             33
|               RR at node 25
|   f)
|       Final Tree
|                    18
|                   /  \
|                  7    29
|                      /  \
|                     25   33
|
| 7)
|   a)
|       14, h=0, bf= 0
|   
|   b)
|               14 (h = 1; bf = -1)
|                 \
|                  26 (h = 0; bf= 0)
|
|   c)
|               14 (h = 2; bf = -2)
|                 \
|                  26 (h = 1; bf= 0)
|                   \
|                    38 (h = 0; bf= 0)
|       c.1)
|           RR at Node 14
|               26
|              /  \
|             14   38
|   d)
|                        26 (h = 2; bf = -1)
|                       /  \
|     (h = 0; bf = 0) 14    38 (h = 1; bf = -1)
|                             \
|                              44 (h = 0; bf = 0)
|   e)
|                        26 (h = 3; bf = -2)
|                       /  \
|     (h = 0; bf = 0) 14    38 (h = 2; bf = -2)
|                             \
|                              44 (h = 1; bf = +1)
|                             /
|                            41 (h = 0; bf = 0)
|       e.1)
|           RL at node 38
|                        26
|                       /  \
|                     14    38
|                             \
|                              41
|                               \
|                                44
            RR at node 38
|       f) Final Tree:
|           
|                        26
|                       /  \
|                     14    41
|                          /  \
|                         38   44
|
| 8)
|         71
|        /  \
|      48    90
|     /
|   39
|
|       a) Insert 42
|                           71 (h = 3; bf = +2)
|                          /  \
|        (h = 2; bf = -2) 48    90 (h = 0; bf = 0)
|                        /
|                       39 (h = 1; bf = -1)
|                         \
|                          42 (h = 0; bf = 0)
|       b) LR at node 48; Final tree
|
|         71
|        /  \
|      42    90
|     /  \
|   39    48
|
| 9)
|
|   a) 52
|       52, h=0, bf= 0
|
|   b) 37
|                   52 (h = 1; bf = +1)
|                  /
|                37 (h = 0; bf = 0)
|       No rotation needed.
|
|   c) 68
|                   52 (h = 1; bf = 0)
|                  /  \
| (h = 0; bf = 0) 37   68 (h = 0; bf = 0)
|       No rotation needed.
|
|   d) 29
|                      52 (h = 2; bf = +1)
|                     /  \
|   (h = 1; bf = +1) 37   68 (h = 0; bf = 0)
|                   /
|  (h = 0; bf = 0) 29
|       No rotation needed.
|
|   e) 44
|                      52 (h = 2; bf = +1)
|                     /  \
|    (h = 1; bf = 0) 37   68 (h = 0; bf = 0)
|                   /  \
|  (h = 0; bf = 0) 29   44 (h = 0; bf = 0)
|       No rotation needed.
|
|   f) 41
|                      52 (h = 3; bf = +2)
|                     /  \
|   (h = 2; bf = +1) 37   68 (h = 0; bf = 0)
|                   /  \
| (h = 1; bf = -1) 29   44 (h = 0; bf = 0)
|                    \
|                     41 (h = 0; bf = 0)
|       LR at node 37
|       f.1)
|                      52
|                     /  \
|                   37   68 
|                  /  \
|                 29   41 
|                        \
|                         44
|       LR at node 52
|           f.2.1)
|                      37
|                     /   \
|                   29     44 
|                    \      \
|                    41      52
|                              \
|                               68
|           f.2.2) 41 Insert Balanced
|                      37
|                     /   \
|                   29      52 
|                    \      / \
|                    41    44  68             
|   
|   g) 75
|                       37 (h = 3; bf = -1)
|                     /    \
|                   29***   52 (h = 2; bf = -1)
|                    \      / \
|                    41**  44* 68 (h = 1; bf = -1)
|                                \
|                                 75 (h = 0; bf = 0)
|
|       *44(h = 0; bf = 0); **41(h = 0; bf = 0); ***29(h = 1; bf = -1)
|       No rotation needed.
|
|   h) 80
|                       37 (h = 4; bf = -2)
|                     /    \
|                   29***   52 (h = 3; bf = -2)
|                    \      / \
|                    41**  44* 68 (h = 2; bf = -2)
|                                \
|                                 75 (h = 1; bf = -1)
|                                   \
|                                    80 (h = 0; bf = 0)
|
|       *44(h = 0; bf = 0); **41(h = 0; bf = 0); ***29(h = 1; bf = -1)
|       RR at node 52
|       h.1) Rotated left
|                       37
|                     /    \
|                   29      68
|                    \      / \
|                    41   52   75
|                         /     \
|                        44      80
|
|   i) 61
|                       37 (h = 3; bf = -1)
|                     /    \
|   (h = 1; bf = -1) 29       68 (h = 2; bf = 0)
|                    \      /  \
|     (h = 0; bf = 0) 41   52    75 (h = 1; bf = 0)
|                         /     / \
|                        44   61   80 (h = 0; bf = 0)
|
|   52 (h = 1; bf = +1); 44 (h = 0; bf = 0); 61 (h = 0; bf = 0);
|   No Rotation needed.
|
|   j) 78
|                       37 (h = 4; bf = -2)
|                     /    \
|  (h = 1; bf = -1) 29       68 (h = 3; bf = -1)
|                    \      /  \
|     (h = 0; bf = 0) 41   52    75 (h = 2; bf = -1)
|                         /     / \
|                        44   61   80 (h = 1; bf = +1)
|                                 /
|                                78 (h = 0; bf = 0)
|
|   52 (h = 1; bf = +1); 44 (h = 0; bf = 0); 61 (h = 0; bf = 0);
|
|
|---    ---         ---     ---|
*/

static class Program
{
    
}
