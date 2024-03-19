class Program
{
    static void Main(string[] args)
    {
        // Dictionary<String, int> dict = new Dictionary<string, int>();
        HashMap<String, Int32> hm = new HashMap<string, Int32>();
        hm.Put("Harshit", 1);
        hm.Put("India", 3);
        hm.Put("Lol", 4);
        System.Console.WriteLine(hm.GetValueAtKey("Harshit"));
        System.Console.WriteLine(String.Join(", ", hm.GetAllKeys()));
        System.Console.WriteLine("Size is : " + hm.Count);
        hm.Put("Harshit", 2);
        hm.Put("B", 5);
        System.Console.WriteLine(String.Join(", ", hm.GetAllKeys()));
        System.Console.WriteLine("Size is : " + hm.Count);
        System.Console.WriteLine(hm.GetValueAtKey("Harshit"));
        // THROWS EXCEPTION // System.Console.WriteLine(hm.GetValueAtKey("Lodadl"));
        System.Console.WriteLine(hm.ContainsKey("India"));
        hm.RemoveKey("India");
        System.Console.WriteLine(hm.ContainsKey("India"));
        System.Console.WriteLine(String.Join(", ", hm.GetAllKeys()));
        System.Console.WriteLine("Size is : " + hm.Count);
        
    }
}

sealed class HashMap<TKey, TValue>
{
    private int size;
    LinkedList<HashMapNode>[] buckets = default!;//Array of LinkedLists

    public int Count { get { return size; } }


    public HashMap()
    {
        InitBuckets(4);
        size = 0;
    }

    private void InitBuckets(int size)
    {
        buckets = new LinkedList<HashMapNode>[size];

        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = new LinkedList<HashMapNode>();
        }
    }

    public void Put(TKey key, TValue value)
    {
        //where to put
        int bucketIndex = GetHashIndex(key);
        int indexWithinBucket = GetIndexWithinGivenBucket(key, bucketIndex);

        if (indexWithinBucket != -1)
        {
            var node = buckets[bucketIndex].ElementAt(indexWithinBucket);
            node.value = value;
        }
        else
        {
            HashMapNode newNode = new HashMapNode(key, value);
            buckets[bucketIndex].AddLast(newNode);
            size++;
        }

        double lambda = (size * 1.0) / buckets.Length;
        if (lambda > 2.0) //setting standard value of lambda as 2.0 so at an average
                          // 2 nodes are present in a linked list in a bucket
        {
            Rehash();
        }
    }

    public IList<TKey> GetAllKeys()
    {
        List<TKey> temp = new List<TKey>();
        for (int i = 0; i < buckets.Length; i++)
        {
            foreach (HashMapNode node in buckets[i])
            {
                temp.Add(node.key);
            }
        }
        return temp;
    }

    private void Rehash()
    {
        LinkedList<HashMapNode>[] oldBucketsArray = buckets;
        InitBuckets(oldBucketsArray.Length * 2);// now the buckets array is double in size
        size = 0;

        for (int i = 0; i < oldBucketsArray.Length; i++)
        {
            foreach (HashMapNode node in oldBucketsArray[i])
            {
                Put(node.key, node.value);
            }
        }
    }
    public TValue GetValueAtKey(TKey key)
    {
        int bucketIndex = GetHashIndex(key);// finding where in the buckets array,
                                            // the key could've been if it were present
        int indexWithinBucket = GetIndexWithinGivenBucket(key, bucketIndex);

        if (indexWithinBucket != -1)
        {
            return buckets[bucketIndex].ElementAt(indexWithinBucket).value;
        }
        else
        {
            throw new KeyNotFoundException($"Key {key} not found");
        }
    }

    public TValue RemoveKey(TKey key)
    {
        int bucketIndex = GetHashIndex(key);// finding where in the buckets array,
                                            // the key could've been if it were present
        int indexWithinBucket = GetIndexWithinGivenBucket(key, bucketIndex);

        if (indexWithinBucket != -1)
        {
            HashMapNode nodeToBeDeleted = buckets[bucketIndex].ElementAt(indexWithinBucket);
            buckets[bucketIndex].Remove(nodeToBeDeleted);
            size--;
            return nodeToBeDeleted.value;
        }
        else
        {
            throw new KeyNotFoundException($"Key {key} not found");
        }
    }

    public bool ContainsKey(TKey key)
    {
        int bucketIndex = GetHashIndex(key);// finding where in the buckets array,
                                            // the key could've been if it were present
        int indexWithinBucket = GetIndexWithinGivenBucket(key, bucketIndex);

        if (indexWithinBucket != -1)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private int GetIndexWithinGivenBucket(TKey key, int bucketIndex)
    {
        LinkedList<HashMapNode> bucketUnderConsideration = buckets[bucketIndex];
        int index = 0;

        foreach (var item in bucketUnderConsideration)
        {
            if ((item.key!).Equals(key))
            {
                return index;
            }
            index++;
        }

        return -1;
    }
    private int GetHashIndex(TKey key)
    {
        int hashCode = key!.GetHashCode();
        int bucketIndex = Math.Abs(hashCode) % buckets.Length;// this is remainder, not quotient
        return bucketIndex;
    }

    private sealed class HashMapNode
    {
        public TKey key;
        public TValue value;

        public HashMapNode(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }
    }

}