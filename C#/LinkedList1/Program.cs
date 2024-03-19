class Program
{

    static void Main(string[] args)
    {
        LinkedList<int> ll1 = new LinkedList<int>();
        LinkedList<int> ll2 = new LinkedList<int>();

        // //ll1 --> 1 ,2 ,4, 7
        ll1.AddLast(1);
        ll1.AddLast(2);
        ll1.AddLast(4);
        ll1.AddLast(7);
        //l2 -->   3, 6, 8
        ll2.AddLast(3);
        ll2.AddLast(6);
        ll2.AddLast(8);
        // var mergedList = MergeLLs_unOpt(ll1, ll2);
        // for (var node = mergedList.First; node != null; node = node.Next)
        // {
        //     System.Console.Write(node.Value + " ");
        // }
        //DisplayReverseRecursive(ll1.First);
        DisplayLLIteratively(ll1);
        ReverseOnlyDataRecursivey(ll1.First);
        //DisplayLLIteratively(ReverseUsingStack(ll1));
       

    }
   
    static void DisplayReverseRecursive(LinkedListNode<int>? head)
    {
        if (head == null)
        {
            return;
        }
        DisplayReverseRecursive(head.Next);
        System.Console.Write(head.Value + " ");
    }

    static LinkedList<int> MergeLLs_unOpt(LinkedList<int> ll1, LinkedList<int> ll2)
    {

        //Extra space so Space complexity  = O(sizeOfLL1 + sizeOfLL2)
        LinkedList<int> result = new LinkedList<int>();

        var iterator1 = ll1.First;
        var iterator2 = ll2.First;

        while (iterator1 != null && iterator2 != null)
        {

            if (iterator1.Value < iterator2.Value)
            {
                result.AddLast(iterator1.Value);
                iterator1 = iterator1.Next;
            }
            else
            {
                result.AddLast(iterator2.Value);
                iterator2 = iterator2.Next;
            }
        }

        while (iterator1 != null)
        {
            result.AddLast(iterator1.Value);
            iterator1 = iterator1.Next;
        }
        while (iterator2 != null)
        {
            result.AddLast(iterator2.Value);
            iterator2 = iterator2.Next;
        }
        return result;
    }
    static void ReverseOnlyDataRecursivey(LinkedListNode<int>? node)
    {
        if (node?.Next == null)
        { //Base Case
            return;
        }
        else
        {
            ReverseOnlyDataRecursivey(node.Next.Next);
            var temp = node.Value;
            node.Value = node.Next.Value;
            node.Next.Value = temp;

        }


    }

    static void DisplayLLIteratively(LinkedList<int> LL)
    {

        LinkedListNode<int>? head;
        System.Console.Write("head --> ");
        for (head = LL.First; head != null; head = head.Next)
        {
            System.Console.Write(head.Value + " --> ");
        }
        System.Console.Write("tail");
        System.Console.WriteLine();

    }

    static void FindAndRemoveALoopInLL(CustomNode head)
    {

    }
}
static class CustomLL
{
    static CustomNode? head, tail;
    static int totalNodes = 0;
    static void AddLast(int data)
    {
        CustomNode newNode = new CustomNode(data);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            CustomNode currentNode;
            for (currentNode = head; currentNode.Next != null; currentNode = currentNode.Next) ;
            currentNode.Next = newNode;
            tail = newNode;
        }
        totalNodes++;
    }

}
public class CustomNode
{

    public int data;
    public CustomNode? Next;

    public CustomNode(int data)
    {
        this.data = data;
        Next = null;
    }

}



//------------------------------------------------------------------------------------------
/*

Singly Linked Lists full Memo
(keep a tail)
(use for loop)

Create a LL recursively/iteratively
Add first/last
remove first/last
Display
Display reverse recursively using BackTracking
GetFirst/GetLast
AddAt/RemoveAt/GetAt
Reverse the LL (iterative/pointer iterative)
LL to Stack (Can use in-built DS for LL)
LL to Queue (Can use in-built DS for LL)
Kth element from the end (cant use or calculate size, to be done with slow and fast pointer)
Middle of LL (cant use or calculate size , to be done with slow and fast pointer)
Merge 2 sorted LLs
MergeSort on LL
Remove duplicates from a sorted LL
Odd Even List
K reverse in LL
Display Reverse recursively
Reverse LL using pointer and recursion
Reverse LL using Data recursive
Is LL palindrome
Fold a LL
Add 2 LL
Sorting a LL
Check if 2 LLs are equal
Intersection point of LLs
remove Loop/cycle in a linked list
Merge K sorted lists
remove duplicates from a linked list whose head node is given to you and return head. Then print it.

*/