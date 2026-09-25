using Homework3.Logic;
using Shouldly;

namespace Homework3.Tests;

public class DoublyLinkedListTests
{
    [Fact]
    public void ReverseListTest()
    {
        DoublyLinkedList doublyLinkedList = new DoublyLinkedList(0);

        doublyLinkedList.Prepend(1);
        doublyLinkedList.Prepend(2);
        doublyLinkedList.Prepend(3);

        doublyLinkedList.PrintList().ShouldBe("|| 0 || 1 || 2 || 3 ||");

        doublyLinkedList.Reverse();

        doublyLinkedList.PrintList().ShouldBe("|| 3 || 2 || 1 || 0 ||");
    }

    [Fact] 
    public void PartitionListTest()
    {
        DoublyLinkedList doublyLinkedList = new DoublyLinkedList(5);

        doublyLinkedList.Prepend(8);
        doublyLinkedList.Prepend(13);
        doublyLinkedList.Prepend(2);
        doublyLinkedList.Prepend(4);
        doublyLinkedList.Prepend(7);

        doublyLinkedList.PartitionList(7);

        doublyLinkedList.PrintList().ShouldBe("|| 5 || 2 || 4 || 8 || 13 || 7 ||");
    }
}
