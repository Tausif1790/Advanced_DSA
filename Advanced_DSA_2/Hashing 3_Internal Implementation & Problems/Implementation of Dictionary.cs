using System;
using System.Collections.Generic;

class HelloWorld
{
    static void Main()
    {
        // Create an instance of MyDictionary with string keys and int values
        MyDictionary<string, int> myDictionary = new MyDictionary<string, int>();

        // Add some testing data
        myDictionary.Add("one", 1);
        myDictionary.Add("two", 2);
        myDictionary.Add("three", 3);

        // Display the size of the dictionary
        Console.WriteLine($"Dictionary Size: {myDictionary.Count}");

        // Access values by keys
        Console.WriteLine($"Value for key 'two': {myDictionary["two"]}");

        // Check if a key exists
        string keyToCheck = "four";
        if (myDictionary.ContainsKey(keyToCheck))
        {
            Console.WriteLine($"Value for key '{keyToCheck}': {myDictionary[keyToCheck]}");
        }
        else
        {
            Console.WriteLine($"Key '{keyToCheck}' not found.");
        }

        // Update the value for an existing key
        myDictionary["one"] = 10;
        Console.WriteLine($"Updated value for key 'one': {myDictionary["one"]}");

        // Display all keys
        List<string> keys = myDictionary.Keys();
        Console.WriteLine("All Keys:");
        foreach (var key in keys)
        {
            Console.WriteLine(key);
        }

        // Display the updated size of the dictionary
        Console.WriteLine($"Updated Dictionary Size: {myDictionary.Count}");
    }
}

public class HMNode
{
    public object Key { get; }           // The key of the node (immutable)
    public object Value { get; set; }    // The value associated with the key

    public HMNode(object key, object value)
    {
        Key = key;
        Value = value;
    }
}

public class MyDictionary<K, V>
{
    private List<HMNode>[] buckets;       // Array of lists to store HMNode objects
    private int size;                     // Number of key-value pairs in the dictionary

    public MyDictionary()
    {
        InitializeBuckets(4);              // Initialize the buckets array with size 4
        size = 0;                         // Initialize the size to zero
    }

    private void InitializeBuckets(int size)
    {
        buckets = new List<HMNode>[size];    // Create an array of lists with an initial size of 4
        for (int i = 0; i < size; i++)
        {
            buckets[i] = new List<HMNode>();  // Initialize each list in the array
        }
    }

    public int Count
    {
        get { return size; }              // Property to get the number of key-value pairs in the dictionary
    }

    public void Add(K key, V value)
    {
        int index = GetBucketIndex(key);  // Get the index of the bucket where the key-value pair will be stored

        // Check if the key already exists in the dictionary
        foreach (var node in buckets[index])
        {
            if (node.Key.Equals(key))
            {
                throw new ArgumentException("An element with the same key already exists in the dictionary.");
            }
        }

        // Add the key-value pair to the specified bucket
        buckets[index].Add(new HMNode(key, value));
        size++;

        // Check for rehash
        double lambda = (size * 1.0) / buckets.Length;
        if (lambda > 0.7)
        {
            Rehash();                      // Perform rehash if the load factor exceeds 0.7
        }
    }

    private void Rehash()
    {
        List<HMNode>[] oldBuckets = buckets;   // Save the reference to the old buckets array
        buckets = new List<HMNode>[oldBuckets.Length * 2];  // Create a new array of lists with double the previous size
        InitializeBuckets(buckets.Length);              // Initialize the new buckets array with the doubled size

        // Redistribution of elements to new buckets without calling Add method
        foreach (List<HMNode> bucket in oldBuckets)
        {
            foreach (HMNode node in bucket)
            {
                int index = GetBucketIndex((K)node.Key);  // Get the new index for the node based on its key
                buckets[index].Add(node);          // Add the node to the new bucket
            }
        }
    }

    public bool ContainsKey(K key)
    {
        int index = GetBucketIndex(key);  // Get the index of the bucket where the key might exist
        foreach (var node in buckets[index])
        {
            if (node.Key.Equals(key))
            {
                return true;               // Return true if the key is found in the bucket
            }
        }
        return false;                      // Return false if the key is not found in the bucket
    }

    public V this[K key]
    {
        get { return Get(key); }           // Property to get the value associated with the specified key
        set { AddOrUpdate(key, value); }   // Property to set the value associated with the specified key
    }

    private void AddOrUpdate(K key, V value)
    {
        int index = GetBucketIndex(key);  // Get the index of the bucket where the key-value pair will be stored
        for (int i = 0; i < buckets[index].Count; i++)
        {
            if (buckets[index][i].Key.Equals(key))
            {
                // Update the existing key-value pair
                buckets[index][i] = new HMNode(key, value);
                return;
            }
        }

        // Key is not found, add a new key-value pair
        buckets[index].Add(new HMNode(key, value));
        size++;

        // Check for rehash
        double lambda = (size * 1.0) / buckets.Length;
        if (lambda > 0.7)
        {
            Rehash();                      // Perform rehash if the load factor exceeds 0.7
        }
    }

    public V Get(K key)
    {
        int index = GetBucketIndex(key);  // Get the index of the bucket where the key might exist
        foreach (var node in buckets[index])
        {
            if (node.Key.Equals(key))
            {
                return (V)node.Value;       // Return the value associated with the key if found
            }
        }
        return default(V);                 // Return the default value if the key is not found
    }

    public List<K> Keys()
    {
        List<K> keys = new List<K>();
        foreach (var bucket in buckets)
        {
            foreach (var node in bucket)
            {
                keys.Add((K)node.Key);      // Add each key to the list of keys
            }
        }
        return keys;                       // Return the list of keys
    }

    private int GetBucketIndex(K key)
    {
        int hashCode = key.GetHashCode();         // Get the hash code of the key
        int index = Math.Abs(hashCode) % buckets.Length;  // Calculate the index based on the hash code
        return index;                      // Return the calculated index
    }
}
