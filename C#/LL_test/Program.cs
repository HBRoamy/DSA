class Program
{
    static void Main(string[] args)
    {
        MyLinkedList obj = new MyLinkedList();
        // obj.AddAtHead(1);
        obj.AddAtTail(1);
        obj.AddAtTail(4);
        obj.AddAtTail(3);
        obj.AddAtTail(5);
        obj.AddAtTail(2);
        // obj.AddAtIndex(1,2);
        // obj.Get(1);
        // obj.DeleteAtIndex(1);
        // obj.Get(1);
        // obj.Get(3);
        // obj.DeleteAtIndex(3);
        // obj.DeleteAtIndex(0);
        // obj.Get(0);
        // obj.DeleteAtIndex(0);
        // obj.Get(0);
        var newHead = ReverseUsingStack(obj.head);
        var c = newHead;
        while(c!=null)
        {
            System.Console.WriteLine(c.val);
            c=c.next;
        }
    }

    
    static Node? ReverseUsingStack(Node head)
   {
        Stack<Node?> st = new();
        var curr = head;
        while(curr!=null)
        {
            st.Push(curr);
            curr=curr.next;

        }
        var newHead = st.Peek();
        while(st.Count>0)
        {
            var first = st.Pop();
            first.next = st.Count!=0?st.Peek():null; 
        }

        return newHead;
   }
}

public class MyLinkedList {

    int totalNodes;
    public Node head;
    public MyLinkedList() {
        totalNodes=0;
        head=null;
    }
    
    public int Get(int index) {
        if(totalNodes==0 || index<0 || index>=totalNodes)
        {
            return -1;
        }
        if(index==0)
        {
            return head.val;
        }
        else
        {
            Node curr = head;

            for(int i=1;i<=index;i++)
            {
                curr=curr.next;
            }
            return curr.val;
        }
    }
    
    public void AddAtHead(int val) {
        Node newNode = new Node(val);
        if(head==null)
        {
            head = newNode;
        }else
        {
            newNode.next = head;
            head = newNode; 

        }
        totalNodes++;
    }
    
    public void AddAtTail(int val) {
        
        if(head==null)
        {
            AddAtHead(val);
        }else
        {
            Node newNode = new Node(val);
            Node curr = head;
            while(curr.next!=null)
            {
                curr=curr.next;
            }
            curr.next = newNode;
            totalNodes++;
        }

    }
    
    public void AddAtIndex(int index, int val) {
        if(index<0 || index>totalNodes) return;
        if(index==totalNodes)
        {
            AddAtTail(val);
        }
        else if(index==0)
        {
            AddAtHead(val);
        }
        else
        {
            Node newNode = new Node(val);
            Node curr = head;

            for(int i=1;i<index;i++)
            {
                curr=curr.next;
            }
            newNode.next=curr.next;
            curr.next = newNode;
            totalNodes++;
        }
    }
    
    public void DeleteAtIndex(int index) {
        if(index<0 || index>=totalNodes) return;
        
        if(index==0)
        {
            head=head.next;
        }else 
        {
            Node curr = head;

            for(int i=1;i<index;i++)
            {
                curr = curr.next;
            }
            curr.next=curr.next.next;
        }
        totalNodes--;
    }
}

public class Node
{
    public int val;
    public Node next;

    public Node(int value)
    {
        val = value;
        next=null;
    }
}
