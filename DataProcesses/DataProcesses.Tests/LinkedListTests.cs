namespace DataProcesses.Tests;

public class LinkedListTests
{
    [Fact]
    public void TPrintList()
    {
        Linked_List sortedLinkedList = new Linked_List(1);
        sortedLinkedList.Append(1);
        sortedLinkedList.Append(2);
        sortedLinkedList.Append(3);
        sortedLinkedList.Append(3);
        sortedLinkedList.Append(3);
        sortedLinkedList.Append(4);

        sortedLinkedList.PrintList().ShouldBe("|| 1 || 1 || 2 || 3 || 3 || 3 || 4 ||");
    }

    [Fact]
    public void TRemoveDuplicates()
    {
        Linked_List sortedLinkedList = new Linked_List(1);
        sortedLinkedList.Append(1);
        sortedLinkedList.Append(2);
        sortedLinkedList.Append(3);
        sortedLinkedList.Append(3);
        sortedLinkedList.Append(4);
        sortedLinkedList.Append(4);
        sortedLinkedList.Append(5);
        sortedLinkedList.Append(5);
        sortedLinkedList.Append(5);
 

        sortedLinkedList.RemoveDuplicates();

        sortedLinkedList.PrintList().ShouldBe("|| 1 || 2 || 3 || 4 || 5 ||");
    }

    [Fact]
    public void TRemoveDuplicates2()
    {
        Linked_List sortedLinkedList = new Linked_List(1);
 
        sortedLinkedList.MakeEmpty();
        sortedLinkedList.RemoveDuplicates();

        sortedLinkedList.PrintList().ShouldBe("||");
    }

    [Fact]
    public void TBinaryList()
    {
        Linked_List sortedLinkedList = new Linked_List(1);
        sortedLinkedList.Append(1);
        sortedLinkedList.Append(0);
        sortedLinkedList.Append(1);

        
        sortedLinkedList.PrintList().ShouldBe("|| 1 || 1 || 0 || 1 ||");
        sortedLinkedList.BinaryList().ShouldBe(13);
    }

    // LeetCode Practice- Difficulty Medium
    [Theory]
    [InlineData(3, "|| 3 || 2 || 1 || 4 || 5 || 6 || 8 || 7 ||")]
    [InlineData(2, "|| 2 || 1 || 3 || 4 || 6 || 5 || 7 || 8 ||")]
    public void ReverseAlternateKTest(int k, string expectedOrder)
    {
        Linked_List altKList = new Linked_List(1);
        altKList.Append(2);
        altKList.Append(3);
        altKList.Append(4);
        altKList.Append(5);
        altKList.Append(6);
        altKList.Append(7);
        altKList.Append(8);

        altKList.ReverseAlternateK(k);
        
        altKList.PrintList().ShouldBe(expectedOrder);
    }
}


