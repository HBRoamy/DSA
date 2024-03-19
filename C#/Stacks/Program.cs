using System.Collections;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string [] args)
    {
        BucketSort_BasicIdea(new int[]{1,3,2,4});
        BucketSort_BasicIdea(new int[]{2,1,3,4});
        BucketSort_BasicIdea(new int[]{2,4,1,3});
    }

    //----------------------------------------------------------

    static void BucketSort_BasicIdea(int[] arr)
    {
        //Assumption : arr contains numbers upto 1 to arr.Length

        for(int i=0;i<arr.Length;i++)
        {
            while(arr[i]!=arr[arr[i]-1])
            {
                (arr[arr[i]-1], arr[i]) = (arr[i],arr[arr[i]-1]); 
            }
        }

        System.Console.WriteLine(String.Join(", ", arr));
    }

    public static bool CanFinish(int numCourses, int[][] prerequisites) {
        if(prerequisites.Length==0) return true;
        //Console.WriteLine(String.Join(", ", new int[]{1,2}));

        var first = prerequisites[0][0];
        var check = prerequisites[0][1];
        for(int i=0; i < numCourses ;i++)
        {
            if(first==check) return false;
            check = prerequisites[i][1];
        }

        return true;
    }

    #region InfixEvaluation
     static void InfixEvaluation(string validExpression)//single digits, -3+2 not possible
     {
        Stack<int> operands = new();
        Stack<char> operators = new();

        foreach(var c in validExpression)
        {
            if(char.IsNumber(c))
            {
                operands.Push(c-'0');
            }else if(c=='(')
            {
                operators.Push(c);
            }else if(c==')')
            {
                while(operators.Peek()!='(')
                {
                    char ch = operators.Pop();
                    int op2 = operands.Pop();
                    int op1 = operands.Pop();

                    operands.Push(Eval(op1, op2,ch));
                }
                operators.Pop();// to remove the opening parenthesis
            }else if(c=='+' || c=='-' || c=='*' || c=='/')
            {
                while(operators.Count>0 && operators.Peek()!='(' && GetPrecedence(operators.Peek())>=GetPrecedence(c))
                {
                    char ch = operators.Pop();
                    int op2 = operands.Pop();
                    int op1 = operands.Pop();

                    operands.Push(Eval(op1, op2,ch));
                }
                operators.Push(c);
            }
        }
        while(operators.Count>0)
                {
                    char ch = operators.Pop();
                    int op2 = operands.Pop();
                    int op1 = operands.Pop();

                    operands.Push(Eval(op1, op2,ch));
                }

        System.Console.WriteLine(operands.Peek());

     }
     static int GetPrecedence(char toCheck)
     {
        if(toCheck=='+' || toCheck=='-') return 1;
        else return 2;
     }

     static int Eval(int op1, int op2, char oprtr)
     {
        if(oprtr=='+')
        {
            return op1+op2;
        }else if(oprtr=='-')
        {
            return op1-op2;   
        }else if(oprtr=='*')
        {
            return op1*op2;
        }else
        {
            return op1/op2;
        }
     }
    #endregion
    static void MaxSlidingWindow(int[] nums, int k)
    {
        int len = nums.Length;
        List<int> res = new();
        Stack<int> st = new();
        int[] rightMaxIndex = new int[len];

        for(int i=len-1;i>=0;i--)
        {
            while(st.Count>0 && nums[st.Peek()]<= nums[i]) st.Pop();

            rightMaxIndex[i]=st.Count==0?rightMaxIndex[i]=-1:st.Peek();

            st.Push(i);
        }
         System.Console.WriteLine(String.Join(", ",rightMaxIndex));
        st = new();

        int[] ar = new int[len];
        for(int i=0;i<len;i++)
        {
            while(st.Count>0 && nums[st.Peek()]<=nums[i])
            {
                ar[st.Pop()]=i;
            }
            st.Push(i);
        }
        while(st.Count>0)
        {
            ar[st.Pop()]=-1;
        }
         System.Console.WriteLine(String.Join(", ",ar));
       
        
        System.Console.WriteLine(String.Join(", ",res));
    }

    static void LargestRectangleInHistogram(int[] arr)
    {
        int maxArea = 0, len = arr.Length;
        int[] LeftFirstSmallerElementIndex = new int[len];
        Stack<int> st = new();

        for(int i=0;i<len;i++)
        {
            while(st.Count>0 && arr[st.Peek()]>=arr[i]) st.Pop();

            LeftFirstSmallerElementIndex[i] = st.Count==0?-1:st.Peek();

            st.Push(i);
        }

        int[] RightFirstSmallerElementIndex = new int[len];
        st=new Stack<int>();
        for(int i=len-1;i>=0;i--)
        {
            while(st.Count>0 && arr[st.Peek()]>=arr[i]) st.Pop();

            RightFirstSmallerElementIndex[i] = st.Count==0?len:st.Peek();

            st.Push(i);
        }

        for(int i=0;i<len;i++)
        {
            int area = (RightFirstSmallerElementIndex[i]-LeftFirstSmallerElementIndex[i]-1)*arr[i];
            System.Console.Write(area + ", ");
            maxArea = Math.Max(area,maxArea);
        }
        System.Console.WriteLine("\n" + maxArea);
    }

    static void testHisto(int [] heights)
    {
        int len = heights.Length;
        Stack<int> st = new();
        st.Push(-1);//if we reach end of stack then we get -1, simple
        int maxArea=0;
        for(int i=0;i<len;i++)
        {
            while(st.Count>1 && heights[st.Peek()]>=heights[i])
            {
                maxArea = Math.Max(maxArea, heights[st.Pop()] * (i- st.Peek() - 1));
            }
            st.Push(i);
        }
        while(st.Count>1)
        {
            System.Console.WriteLine(heights[st.Peek()]);
            int area = heights[st.Pop()] * (len- st.Peek() - 1);
            maxArea = Math.Max(maxArea, area);
            System.Console.WriteLine(area);
        }
        System.Console.Write("\n" + maxArea);
    }
    static void StockSpan_DistanceFromPreviousGreaterElementOnLeft(int[] arr)
    {
        int[] res = new int[arr.Length];
        Stack<int> st = new();

        for(int i=0;i<arr.Length;i++)
        {
            while(st.Count>0 && arr[st.Peek()]<=arr[i])
            {
                st.Pop();
            }
            if(st.Count==0)
            {
                res[i]=i+1;
            }else{
                res[i]=i-st.Peek();
            }
            st.Push(i);
        }

        System.Console.WriteLine(String.Join(", ",res));
    }

    static void PreviousSmallerElementOnLeft(int[] arr)
    {
        //O(N) as the nested while loop will also pop atmost N times in total among all iterations of its parent
        // for loop
        int[] res = new int[arr.Length];
        Stack<int> st = new();

        for(int i=0;i<arr.Length;i++)
        {
            
            while(st.Count>0 && st.Peek()>=arr[i])
            {
                st.Pop();
            }
            if(st.Count==0)
            {
                res[i]=-1;
            }else{
                res[i]=st.Peek();
            }

            st.Push(arr[i]);
        }

        foreach (var item in res)
        {
            System.Console.Write(item + " ");
        }
    }
    static void PreviousSmallerElementOnLeft2(int[] arr)
    {
        int[] res = new int[arr.Length];
        Stack<int> st = new();

        for (int i = arr.Length-1; i >=0; i--)
        {
            while(st.Count>0 && arr[st.Peek()]>arr[i])
            {
                res[st.Pop()]=arr[i];
            }
            st.Push(i);
        }

        while(st.Count>0)
        {
            res[st.Pop()]=-1;
        }

        foreach (var item in res)
        {
            System.Console.Write(item + " ");
        }
    }

    static bool RedundantBrackets(string exp)
    {
        Stack<char> st = new Stack<char>();
        foreach(char c in exp)
        {
            if(c==')')
            {
                //if we right away see that the top is '(' then we know that
                //this bracket pair doesnt have its own content and hence
                //is useless
                if(st.Count>0 && st.Peek()=='(') return true;
                else{//we keep popping until we see that top is '(' and then 
                    // pop that too
                while(st.Count>0 && st.Peek()!='(')
                {
                    st.Pop();
                }
                
                if(st.Count>0)
                st.Pop();//removed the '(' also
                }

            }else 
            {
                st.Push(c);
                
            }
        }

        return false;
    }
}

/*
Reverse stack with/without extra space
Try Implementing Queue (Not sure if it is a real case or not)
balance brackets
Postfix, prefix expressions
preorder, postorder of trees using stack 
Topological Sort of a graph (Adjacency list and matrix)

*/