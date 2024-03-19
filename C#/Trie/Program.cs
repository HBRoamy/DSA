class Trie
{
    static void Main(string[] args)
    {
        string[] words = {"the", "a", "there", "their", "any", "abc"};

        Node curr = root;
        CreateTrie(words);
        var _1 = curr.children[0];
        var _2 = curr.children[0].children[1];
        var _3 = curr.children[0].children[1].children[2];

        System.Console.WriteLine($"{_1.data} {_2.data} {_3.data}");
    }

    static Node root = new Node();

    static void CreateTrie(string[] words)
    {
        Node curr = root;
        foreach (string word in words)
        {
            foreach (char ch in word)
            {
                if(curr.children[ ch - 'a' ]==null)
                {
                    curr.children[ch-'a'] = new Node();
                    curr.children[ch-'a'].data = ch;
                }
                curr = curr.children[ch-'a'];
                
            }
            curr.endOfWord=true;
            curr=root;
        }
    }
    
    class Node
    {
        // Root Node of a Trie is always empty
        // It works with string
        // TC of insertion is O(L) --> L is length of string
        // Its a K-ary Tree
        //there is not need to have a char data field to keep track of a letter as we can infer the letter 
        //from the children array
        public Node[] children;
        public bool endOfWord;
        public char data;
        public Node()
        {
            children = new Node[26];// 0 is a, 1 is b, ...... 25 is z
                                    // so if a node is stored at children[1], the data of the node
                                    // is considered to be 'b'
            endOfWord = false;
        }
    }
}