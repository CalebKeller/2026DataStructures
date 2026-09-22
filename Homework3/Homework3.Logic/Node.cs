namespace Homework3.Logic;

public class Node
{
    public int Val { get; set; }
    public Node Next { get; set; }
    public Node Prev { get; set; }

    public Node(int value)
    {
        Val = value;
    }
}


