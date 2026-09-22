namespace Homework3.Logic;

public class DoublyLinkedList
{
    private Node head;
    private Node tail;
    private int length;
    public DoublyLinkedList(int value)
    {
        Node newNode = new Node(value);
        head = newNode;
        tail = newNode;
        length = 1;
    }

    public void Prepend(int value)
    {
        Node newNode = new Node(value);

        tail.Next = newNode;
        newNode.Prev = tail;
        tail = newNode;
    }

    public void Append(int value)
    {
        Node newNode = new Node(value);

        newNode.Next = head;
        head.Prev = newNode;
        head = newNode;
    }

    public void RemoveFirstElement(int value)
    {
        Node temp = head.Next;
        head.Next = null;
        temp.Prev = null;
        head = temp;
    }

    public void Reverse()
    {
        Node current = head;

        for (int i = 0; i < length; i++)
        {
            Node temp = current.Next;
            current.Next = current.Prev;
            temp.Prev = temp;
        }
        
        Node temp2 = head;
        head = tail;
        tail = temp2;
    }

    public void PartitionList()
    {

    }
}


