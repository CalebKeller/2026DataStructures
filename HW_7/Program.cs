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
|   10: h = 0
|   20: h = 1
|   30: h = 2
|   40: h = 1
|   50: h = 3
|   70: h = 2
|   80: h = 1
|   90: h = 0
| This is not an AVL tree because of the Node 70, every other node is valid for an AVL tree.                      
|                                                                    
| - Part 2 -
|
| 6)
| 7)
| 8)
| 9)
|
|---    ---         ---     ---|
*/

static class Program
{
    
}
