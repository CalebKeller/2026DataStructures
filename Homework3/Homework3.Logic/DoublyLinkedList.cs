using System.Runtime.CompilerServices;
using System.Transactions;

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

    public string PrintList()
    {
        Node temp = head;
        string text = "|";
        while (temp != null)
        {
            text += $"| {Convert.ToString(temp.Val)} |";
            temp = temp.Next;
        }
        return text + "|";
    }

    public void Prepend(int value)
    {
        Node newNode = new Node(value);

        tail.Next = newNode;
        newNode.Prev = tail;
        tail = newNode;
        length++;
    }

    public void Append(int value)
    {
        Node newNode = new Node(value);

        newNode.Next = head;
        head.Prev = newNode;
        head = newNode;
        length++;
    }

    public void RemoveFirstElement(int value)
    {
        Node temp = head.Next;
        head.Next = null;
        temp.Prev = null;
        head = temp;
    }

    /*
        First, it checks if the head is null (empty list) or if the list is so short it cab't be reversed. If so, it doesn't execute the code below.
        Next, the head is stored in current. Then, while current is an actual node, a certain block runs. 
        The next Node is stored in temp and the next and previous node pointer switch. 
        Then current goes to temp, which is the next iteration. This repeats until nearly everything but the head and tail are reversed.
        Finally, after the loop, the head and tail switch.
    */
    public void Reverse()
    {
        if (head == null || length <= 1)
        {
            return;
        }

        Node current = head;

        while (current != null)
        {
            Node temp = current.Next;
            current.Next = current.Prev;
            current.Prev = temp;
            current = temp;
        }

        Node oldHead = head;
        head = tail;
        tail = oldHead;
    }
    // The time complexity can only be as long as current is not null, therefore it is the length of the list of O(n). 
    // The only initialized value inside the loop is temp, which holds one node, so the space complexity is O(1).

    public void PartitionList(int x)
    {

        /*
        Node dummy = new Node(0);
        Node dummy2 = new Node(0);
        
        Node prev1 = dummy;
        Node prev2 = new Node(0);

        Node temp = head;
        dummy.Next = temp;
        head = dummy;

        Node temp2 = tail;
        tail.Next = dummy2;
        dummy2.Prev = temp2.Prev;
        tail = dummy2;
        head = head.Next;
        head.Prev = null;
        prev1.Next = prev2;
        prev2.Prev = prev1;
        */
        Node cur = head;
        Node dummy = new Node(0);
        tail.Next = dummy;
        dummy.Prev = tail;
        tail = dummy;

        Node dummy2 = new Node(0);
        head.Prev = dummy2;
        dummy2.Next = head;
        head = dummy2;

        for (int i = 0; i < length; i++)
        {
            Node next = cur.Next;
            if (cur.Val >= x)
            {
                tail.Next = cur;
                cur.Prev = tail;
                tail = cur;
                tail.Next = null;
            }
            cur = next;
        }
    }
}


