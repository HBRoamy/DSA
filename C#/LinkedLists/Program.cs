class Program
{
    static void Main(string[] args)
    {
        LL ll1 = new LL();
        ll1.AddLast(13);
        ll1.AddLast(5);
        ll1.AddLast(2);
        ll1.AddLast(8);
        ll1.AddLast(3);
        // // int[] arr = { 1, 1 };
        // //IMPORTANT - CORRECT SYNTAX//List<int> l = new();
        // // System.Console.WriteLine(ll1.MaxArea(arr));
        // System.Console.WriteLine(ll1.AddDigits(38));

        //ll1.Rotate(new int[]{-1,-100,3,99},2);


    }

}



public class LL
{
    //singly linked list
    public int TotalNodes { get; private set; } = 0;

public void Rotate(int[] nums, int k) {
        int len = nums.Length;
        k= k<=len?k:k%len;
        int [] arr = new int[len];
        if(k==0) return;
        
        for(int i=0;i<len-k;i++)
        {
            arr[k+i]=nums[i];
        }
        System.Console.WriteLine(String.Join(", ",arr));
        int o=0;
        for(int j=k;j<len;j++)
        {
            arr[j-k] = nums[j];
            o++;
        }

        System.Console.WriteLine(String.Join(", ",arr));
        for(int m=0;m<len;m++)
        {
            nums[m]=arr[m];
        }
        System.Console.WriteLine(String.Join(", ",nums));
    }    public Node? head;



    public int AddDigits(int num) {
        if(num>=0 && num<=9) return num;

        int val=0;

        do
        {
            val=0;
            while(num!=0)
            {
            val+=num%10;
            num/=10;
            }
            System.Console.WriteLine("num is "+num);
            System.Console.WriteLine("val is "+val);
            num=val;
        }while(val%10!=val);

        return val;
    }

    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        Dictionary<int, int> d = new();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!d.ContainsKey(nums[i]))
                d.Add(nums[i], i);
            else
            {
                if (Math.Abs(i - d[nums[i]]) <= k)
                    return true;
                else
                d[nums[i]]=i;    
            }
        }
        return false;
    }

    public void DisplayUsingHead(Node root)
    {
        Node? curr = root;
        while (curr != null)
        {
            System.Console.Write(curr.data + " ");
            curr = curr.next;
        }
        System.Console.WriteLine();
    }
    public int Compress(char[] chars)
    {

        int count = 0;
        char c1 = chars[0];
        string s = "";
        for (int i = 0; i < chars.Length; i++)
        {
            System.Console.WriteLine("char " + chars[i]);

            if (chars[i] == c1)
            {
                count += 1;
                System.Console.WriteLine("Yes " + c1 + " " + count);
                if ((i + 1) < chars.Length)
                {
                    if (chars[i + 1] != c1)
                    {
                        if (count == 1)
                        {
                            s += c1.ToString();
                        }
                        else if (count > 1)
                        {

                            s += c1.ToString() + count;
                        }
                        System.Console.WriteLine("str is : " + s);
                    }
                }
                else
                {
                    s += c1.ToString() + count;
                }

            }
            else
            {
                System.Console.WriteLine("Not equal setting to " + c1);
                c1 = chars[i];
                count = 1;
            }
            System.Console.WriteLine();
        }


        System.Console.WriteLine(s + " " + s.Length);
        return s.Length;
    }

    //---------------------------------------------------------------

    public void FoldALinkedList(Node head)
    {
        Node? prev = null,//tail of first half
        slow = head,//head of second half before reversing
        fast = head,//tail of second half
        h1 = head;//head of first half

        while (fast != null && fast.next != null)
        {
            prev = slow;
            slow = slow!.next;
            fast = fast.next.next;
        }

        prev!.next = null;//breaking the list in half

        Node? h2 = Reverse(slow);//slow is now the new head of the 

        while (h1 != null)
        {
            Node? next1 = h1.next;
            Node? next2 = h2!.next;

            h1.next = h2;
            h2.next = next1;
            if (next1 == null) break;
            h1 = next1;
            h2 = next2;

        }


    }

    public Node Reverse(Node? head)
    {
        Node? prev = null, curr = head, next = null;

        while (curr != null)
        {
            next = curr.next;

            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev!;
    }

    public void EvenOddLL(Node head1)
    {
        /*
        Given   a     Linked    List   of   integers,  write a function to
        modify the     linked      list     such    that  all even numbers
        appear     before     all       the    odd numbers in the modified 
        linked list. Also, keep the order of even and odd numbers the same.
        */

        LL odd = new LL();
        LL even = new LL();

        Node? curr = head!;

        while (curr != null)
        {
            if (curr.data % 2 == 0)
            {
                even.AddLast(curr.data);
            }
            else
            {
                odd.AddLast(curr.data);
            }
            curr = curr.next;
        }

        curr = even.head;//even can be null tho
        while (curr!.next != null)
        {
            curr = curr.next;
        }
        curr.next = odd.head;

        even.DisplayLL();
    }

    public void RemoveDuplicatesFromASortedList(Node root)
    {
        //TC should be O(N) because for 2 worst cases, when all elements are distinct, outer loop runs N-1
        // times ( because fast starts from 2nd element of list ) and we dont enter inner loop
        // and case 2 if all elements were same, then the inner loop would run N-1 times and then both loops end as list is exhausted
        // so O(N) time and O(1) space
        Node? slow = head;
        Node? fast = head!.next;

        while (fast != null)
        {
            if (slow!.data == fast.data)// enter if block when x and x+1th elements match
            {
                while (fast.next != null && fast.data == fast.next.data)//checking if the elements after fast
                                                                        // are same and break when they aren't, hence now fast
                                                                        // is the node whose next node is different from itself
                {
                    fast = fast.next;
                }

                slow.next = fast.next;
            }
            slow = slow.next;
            fast = fast.next;
        }


    }
    public LL MergeSort(LL list1, LL list2)
    {
        return new LL();
    }

    public LL MergeTwoSortedLinkedLists(Node head1, Node head2)
    {
        LL result = new LL();
        Node? tmp1 = head1, tmp2 = head2;
        while (tmp1 != null && tmp2 != null)
        {
            if (tmp1.data <= tmp2.data)
            {
                result.AddLast(tmp1.data);
                tmp1 = tmp1.next;
            }
            else
            {
                result.AddLast(tmp2.data);
                tmp2 = tmp2.next;
            }
        }

        while (tmp1 != null)
        {
            result.AddLast(tmp1.data);
            tmp1 = tmp1.next;
        }
        while (tmp2 != null)
        {
            result.AddLast(tmp2.data);
            tmp2 = tmp2.next;
        }

        return result;
    }
    public int MiddleOfList()
    {

        Node start = new Node(-1);
        start.next = head;
        Node fast = start;
        Node slow = start;

        while (fast != null && fast.next != null)
        {
            fast = fast.next.next!;
            slow = slow.next!;
        }

        return slow.data;
    }
    public void RemoveKthElementFromTheEnd(int k)
    {
        // k=1 means last element, K=2 means second Last

        Node start = new Node(-1);
        start.next = head;

        Node slow = start;
        Node fast = start;

        for (int i = 0; i < k; i++)
        {
            fast = fast.next!;
        }

        while (fast.next != null)
        {
            slow = slow.next!;
            fast = fast.next!;
        }

        slow.next = slow.next!.next;
        head = start.next;
    }
    public void ReverseList()
    {
        Node? prev = null;
        Node? current = head;
        Node? next = null;

        while (current != null)
        {
            next = current.next;

            current.next = prev;
            prev = current;
            current = next;

        }

        head = prev;
        DisplayLL();
    }

    public void DeleteAt(int index)
    {
        if (index < 0 || index > TotalNodes)
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            DeleteFirst();
            //It already decrements the nodes counter
        }
        else if (index == TotalNodes - 1)
        {
            DeleteLast();
            //It already decrements the nodes counter
        }
        else
        {
            Node? curr = head;

            for (int i = 1; i < index; i++)
            {
                curr = curr!.next;
            }
            curr!.next = curr.next!.next;
            TotalNodes--;
        }

    }

    public int GetAt(int index)
    {
        if (index < 0 || index > TotalNodes)
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            return GetFirst();
        }
        else if (index == TotalNodes - 1)
        {
            return GetLast();
        }
        else
        {
            Node? curr = head;

            for (int i = 1; i <= index; i++)
            {
                curr = curr!.next;
            }
            return curr!.data;
        }
    }

    public void AddAt(int data, int index)
    {
        if (index < 0 || index > TotalNodes)
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            AddFirst(data);
            //It already increments the nodes counter
        }
        else if (index == TotalNodes)
        {
            AddLast(data);
            //It already increments the nodes counter

        }
        else
        {
            Node? curr = head;

            for (int i = 1; i < index; i++)
            {
                curr = curr!.next;
            }

            Node newNode = new Node(data);
            newNode.next = curr!.next;
            curr.next = newNode;
            TotalNodes++;
        }

    }

    public void Display_Recursive()
    {
        System.Console.Write("Head --> ");
        Display_Recursive_Util(head);
        System.Console.Write("NULL");
    }
    private void Display_Recursive_Util(Node? root)
    {
        if (root == null)
        {
            return;
        }
        System.Console.Write(root.data + " --> ");
        Display_Recursive_Util(root.next);
    }
    public void AddFirst(int data)
    {
        Node newNode = new Node(data);
        if (this.head == null)
        {
            head = newNode;
        }
        else
        {
            newNode.next = head;
            head = newNode;
        }
        TotalNodes++;
    }

    public void AddLast(int data)
    {

        Node newNode = new Node(data);
        if (this.head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.next != null)
            {
                current = current.next!;
            }
            current.next = newNode;
        }
        TotalNodes++;
    }

    public void AddLast_Recursive(int data)
    {
        head = AddLast_Recursive_Util(head, data);
    }
    private Node AddLast_Recursive_Util(Node? root, int data)
    {
        if (root == null)
        {
            TotalNodes++;
            return new Node(data);
        }
        else
        {
            root.next = AddLast_Recursive_Util(root.next, data);
        }

        return root;
    }
    public void DeleteFirst()
    {
        if (head == null)
        {
            System.Console.WriteLine("List Empty!!");
            return;
        }

        head = head?.next;

        TotalNodes--;
    }

    public void DeleteLast()
    {
        if (head == null)
        {
            System.Console.WriteLine("List Empty!!");
            return;
        }

        Node? current = head;

        if (head.next == null)
        {
            head = null;
        }
        else
        {
            while (current.next!.next != null)
            {
                current = current.next;
            }
            current.next = null;
        }


        TotalNodes--;
    }

    public void DisplayLL()
    {
        if (head == null)
        {
            System.Console.WriteLine("Can't display, List is Empty!!");
            return;
        }

        Node current = head;

        System.Console.Write("Head --> ");
        while (current != null)
        {
            System.Console.Write(current.data + " --> ");
            current = current.next!;
        }
        System.Console.Write("NULL \n");
    }

    public void DisplayReverse_Iterative()
    {
        if (head == null)
        {
            System.Console.WriteLine("List Empty.");
            return;
        }
        Stack<int> stack = new Stack<int>();

        Node? current = head!;
        while (current != null)
        {
            stack.Push(current.data);
            current = current.next;
        }

        System.Console.Write("NULL <-- ");
        while (stack.Count != 0)
        {
            System.Console.Write(stack.Pop() + " <-- ");
        }
        System.Console.Write("Head \n");

    }
    public void DisplayReverse_Recursive()
    {
        if (head == null)
        {
            System.Console.WriteLine("List Empty.");
            return;
        }
        System.Console.Write("NULL <-- ");
        DisplayReverse_Recursive_Util(head);
        System.Console.Write("Head \n");
    }

    public int GetFirst()
    {
        if (head == null)
        {
            throw new IndexOutOfRangeException("List Empty");
        }
        return head.data;
    }

    public int GetLast()
    {
        if (head == null)
        {
            throw new IndexOutOfRangeException("List Empty");
        }

        Node? current = head;

        while (current.next != null)
        {
            current = current.next;
        }
        return current.data;
    }

    private void DisplayReverse_Recursive_Util(Node? root)
    {
        if (root == null)
        {
            return;
        }

        DisplayReverse_Recursive_Util(root.next);
        System.Console.Write(root.data + " <-- ");
    }





    //-------------------------------NODE CLASS-------------------------------------//
    public class Node
    {
        public int data;
        public Node? next;

        public Node(int data)
        {
            this.data = data;
            next = null;
        }
    }

}

public class Stack
{
    LL ll;
    public int Count { get { return ll.TotalNodes; } }
    public Stack()
    {
        ll = new LL();
    }
    public Stack(LL newLL)
    {
        ll = newLL;
    }
    public int Peek()
    {
        if (Count > 0)
        {
            return ll.GetFirst();
        }
        else
        {
            throw new Exception("List Empty");
        }
    }
    public void Push(int data)
    {
        ll.AddFirst(data);
    }
    public int Pop()
    {
        if (Count > 0)
        {
            int first = Peek();
            ll.DeleteFirst();
            return first;
        }
        else
        {
            throw new Exception("List Empty");
        }
    }
}

public class Queue
{
    LL queue;

    public Queue()
    {
        queue = new LL();
    }
    public Queue(LL newLL)
    {
        queue = newLL;
    }

    public void Enqueue(int data)
    {
        queue.AddLast(data);
    }

    public int Dequeue()
    {
        if (queue.TotalNodes <= 0)
        {
            throw new Exception("Queue Empty");
        }
        int ans = queue.GetFirst();
        queue.DeleteFirst();
        return ans;
    }
}
//------------------------------------------------------------------------------------------
/*

Singly Linked Lists full Memo
(keep a tail)
(use for loop)

Create a LL recursively/iteratively --V
Add first/last --V
remove first/last --V
Display --V
Display reverse iteratively using stack /recursively using BackTracking --V
GetFirst/GetLast --V
AddAt/RemoveAt/GetAt --V
Reverse the LL (iterative/pointer iterative) --V
LL to Stack (Can use in-built DS for LL) --V
LL to Queue (Can use in-built DS for LL) --V
Remove Kth element from the end (cant use or calculate size, to be done with slow and fast pointer) --V
Middle of LL (cant use or calculate size , to be done with slow and fast pointer) --V
Merge 2 sorted LLs --V
Remove duplicates from a sorted LL--V

Reverse only data
MergeSort on LL
any other sort on a LL
Odd Even List
K reverse in LL
Is LL palindrome
flatten a LL
implement SkipList
Fold a LL
Add 2 LL
Check if 2 LLs are equal
Intersection point of LLs
detect Loop/cycle in a linked list using HashMap/ Floyd Warshall Loop Detection algo
Merge K sorted lists
remove duplicates from an unsorted linked list whose head node is given to you and return head. Then print it.

*/
