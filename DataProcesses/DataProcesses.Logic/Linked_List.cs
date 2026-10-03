namespace DataProcesses.Logic;

// Orginal Code from professor, edits by Caleb Keller
public class Linked_List
{
    private Node head;
    private Node tail;
    private int length;
    // Constructor
    public Linked_List(int value)
    {
        Node newNode = new Node(value);
        head = newNode;
        tail = newNode;
        length = 1;
    }
    public Node GetHead()
    {
        return head;
    }
    public Node GetTail()
    {
        return tail;
    }
    public int GetLength()
    {
        return length;
    }
    public string PrintList() // Altered to fit into multiple froject solution.
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
    public string ReturnAll() // Altered to fit into multiple froject solution.
    {
        string text = string.Empty;
        if (length == 0)
        {
            text += "Head: null\n";
            text += "Tail: null\n";
        }
        else
        {
            text += $"Head: {head.Val}\n";
            text += $"Tail: {tail.Val}\n";
        }
        text += $"Length: {length}\n";
        text += "\nLinked List:\n";
        if (length == 0)
        {
            return text + "empty";
        }
        else
        {
            return $"{text}\n" + PrintList();
        }
    }
    public void MakeEmpty()
    {
        head = null;
        tail = null;
        length = 0;
    }

    /* --- Either HW1 or HW2 --- PROBLEM 1 
    First, if there is no elements or only one element, the LinkedList is left unchanged and the code ends. 
    Next, the current node is tracked from the 'head' and it will run as many times as there are elements (at most).  
    Then, it will end if the pointer to the next value is null, if not, it will check if the next two values are duplicates. 
    It also skips the next pointer, and removes the duplicate. If there's not a duplicate, it just goes to the next element.*/
    public void RemoveDuplicates()
    {
        if (head == null || length <= 1)
        {
            return;
        }
        Node current = head;
        int startingLength = length;
        for (int i = 0; i < startingLength; i++)
        {
            if (current.Next != null)
            {
                if (current.Val == current.Next.Val)
                {
                    current.Next = current.Next.Next;
                    length--;
                }
                else
                {
                    current = current.Next;
                }
            }
            else
            {
                break;
            }
        }
    }
    //  --- Either HW1 or HW2 --- The time complexity is O(n), because it can run n times at the most. The loop's max times to run is the length of the LinkedList
    //  --- Either HW1 or HW2 --- The space complexity is O(1), because it only stores one variable inside the loop.

    public void Append(int value)
    {
        Node newNode = new Node(value);
        if (length == 0)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
        length++;
    }
    public Node RemoveLast()
    {
        if (length == 0) return null;
        Node temp = head;
        Node pre = head;
        while (temp.Next != null)
        {
            pre = temp;
            temp = temp.Next;
        }
        tail = pre;
        tail.Next = null;
        length--;
        if (length == 0)
        {
            head = null;
            tail = null;
        }
        return temp;
    }
    public void Prepend(int value)
    {
        Node newNode = new Node(value);
        if (length == 0)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head = newNode;
        }
        length++;
    }
    public Node RemoveFirst()
    {
        if (length == 0)
        {
            head = null;
            tail = null;
            return null;
        }
        Node temp = head;
        head = head.Next;
        temp.Next = null;
        length--;
        if (length == 0) tail = null;
        return temp;
    }
    public Node Get(int index)
    {
        if (index < 0 || index >= length) return null;
        Node temp = head;
        for (int i = 0; i < index; i++)
        {
            temp = temp.Next;
        }
        return temp;
    }
    public bool Set(int index, int value)
    {
        Node temp = Get(index);
        if (temp != null)
        {
            temp.Val = value;
            return true;
        }
        return false;
    }
    public bool Insert(int index, int value)
    {
        if (index < 0 || index > length) return false;
        if (index == 0)
        {
            Prepend(value);
            return true;
        }
        if (index == length - 1 || index == length)
        {
            Append(value);
            return true;
        }
        Node newNode = new Node(value);
        Node temp = Get(index - 1);
        newNode.Next = temp.Next;
        temp.Next = newNode;
        length++;
        return true;
    }
    public Node Remove(int index)
    {
        if (index < 0 || index >= length) return null;
        if (index == 0) return RemoveFirst();
        if (index == length - 1) return RemoveLast();
        Node temp = Get(index);
        Node prev = Get(index - 1);
        prev.Next = temp.Next;
        temp.Next = null;
        length--;
        return temp;
    }
    public void Reverse()  // --- Either HW1 or HW2 --- 
    {
        Node temp = head;
        head = tail;
        tail = temp;
        Node before = null;
        Node after;
        for (int i = 0; i < length; i++)
        {
            after = temp.Next;
            temp.Next = before;
            before = temp;
            temp = after;
        }
    }

    public void ReverseAlternateK(int k)
    {
        if (length == 0 || (tail.Val == head.Val && head.Val <= tail.Val))
        {
            return;
        }

        Node temp = head;
        while (temp.Val != k) // Find which node is k.
        {
            temp = temp.Next;
        }
        Node temp2 = temp.Next;
        temp.Next = null;
        Node originalHead = head;
        Node prev = head;

        for (int i = 0; i < length; i++)
        {
            while(prev != temp)
            {
                prev = prev.Next;
                temp.Next = prev;
                temp = prev;
            }
        }
        head.Next = temp2;
        head = originalHead;
    }
    // Floyd's Tortoise and Hare algorithm
    public Node FindMiddleNode()
    {
        if (head == null) return null;
        Node slow = head;
        Node fast = head;
        while (fast != null && fast.Next != null)
        {
            fast = fast.Next.Next;
            slow = slow.Next;
        }
        return slow;
    }

    /* PROBLEM 2
    As the LinkedList is iterated the if statement makes sure the LinkedList is binary, if it isn't, it returns 0. 
    It also multiplies the current total by two and adds the current value of the node and then moves to the next one.
    By multiplying by two and adding the value, it ensures that the binary value moves up one digit and also increments by the next one.

    1101

    (0*2)+1 = 1   | 1
    (1*2)+1 = 3   | 11
    (3*2)+0 = 6   | 110
    (6*2)+1 = 13  | 1101


    At the end, it returns the converted integer.
    */
    public int BinaryList()
    {
        Node current = head;
        int total = 0;
        for (int i = 0; i < length; i++)
        {
            if (current.Val != 0 && current.Val != 1)
            {
                return 0;
            }

            total = total * 2 + current.Val;
            current = current.Next;
        }

        return total;
    }
    // The Big O (time complexity) for this one is O(n), because it will run n times (n is the length in this case and that is how many times the loop is set to run)
    // The Big O for the space complexity is O(2), total and current being stored, 2 is a constant, so it simplifies to O(1).


}






