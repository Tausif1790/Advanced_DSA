using System;
using System.Collections.Generic;

class HelloWorld {
    static void Main() {
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
        if (myDictionary.ContainsKey(keyToCheck)) {
            Console.WriteLine($"Value for key '{keyToCheck}': {myDictionary[keyToCheck]}");
        } else {
            Console.WriteLine($"Key '{keyToCheck}' not found.");
        }

        // Update the value for an existing key
        myDictionary["one"] = 10;
        Console.WriteLine($"Updated value for key 'one': {myDictionary["one"]}");

        // Display all keys
        List<string> keys = myDictionary.Keys();
        Console.WriteLine("All Keys:");
        foreach (var key in keys) {
            Console.WriteLine(key);
        }

        // Display the updated size of the dictionary
        Console.WriteLine($"Updated Dictionary Size: {myDictionary.Count}");
    }
}

// Simplified and commented version of MyDictionary
public class MyDictionary<K, V> {
    private List<KeyValuePair<K, V>>[] buckets;
    private int size;

    public MyDictionary() {
        InitializeBuckets();
        size = 0;
    }

    private void InitializeBuckets() {
        // Initialize an array of lists (buckets) for storing key-value pairs
        buckets = new List<KeyValuePair<K, V>>[4];
        for (int i = 0; i < 4; i++) {
            buckets[i] = new List<KeyValuePair<K, V>>();
        }
    }

    public int Count {
        get { return size; }
    }

    public void Add(K key, V value) {
        int index = GetBucketIndex(key);

        // Check if the key already exists in the dictionary
        foreach (var pair in buckets[index]) {
            if (pair.Key.Equals(key)) {
                throw new ArgumentException("An element with the same key already exists in the dictionary.");
            }
        }

        // Add the key-value pair to the specified bucket
        buckets[index].Add(new KeyValuePair<K, V>(key, value));
        size++;

        // Check for rehash if the load factor exceeds 0.7
        double loadFactor = (size * 1.0) / buckets.Length;
        if (loadFactor > 0.7) {
            Rehash();
        }
    }

    private void Rehash() {
        // Double the number of buckets and redistribute elements
        List<KeyValuePair<K, V>>[] oldBuckets = buckets;
        buckets = new List<KeyValuePair<K, V>>[oldBuckets.Length * 2];
        InitializeBuckets();

        // Redistribution of elements to new buckets without calling Add method
        foreach (List<KeyValuePair<K, V>> bucket in oldBuckets) {
            foreach (KeyValuePair<K, V> pair in bucket) {
                int index = GetBucketIndex(pair.Key);
                buckets[index].Add(pair);
            }
        }
    }

    public bool ContainsKey(K key) {
        int index = GetBucketIndex(key);
        foreach (var pair in buckets[index]) {
            if (pair.Key.Equals(key)) {
                return true;
            }
        }
        return false;
    }

    public V this[K key] {
        get { return Get(key); }
        set { AddOrUpdate(key, value); }
    }

    private void AddOrUpdate(K key, V value) {
        int index = GetBucketIndex(key);
        for (int i = 0; i < buckets[index].Count; i++) {
            if (buckets[index][i].Key.Equals(key)) {
                // Update the existing key-value pair
                buckets[index][i] = new KeyValuePair<K, V>(key, value);
                return;
            }
        }

        // Key is not found, add a new key-value pair
        buckets[index].Add(new KeyValuePair<K, V>(key, value));
        size++;

        // Check for rehash if the load factor exceeds 0.7
        double loadFactor = (size * 1.0) / buckets.Length;
        if (loadFactor > 0.7) {
            Rehash();
        }
    }

    public V Get(K key) {
        int index = GetBucketIndex(key);
        foreach (var pair in buckets[index]) {
            if (pair.Key.Equals(key)) {
                return pair.Value;
            }
        }
        return default(V);
    }

    public List<K> Keys() {
        List<K> keys = new List<K>();
        foreach (var bucket in buckets) {
            foreach (var pair in bucket) {
                keys.Add(pair.Key);
            }
        }
        return keys;
    }

    private int GetBucketIndex(K key) {
        // Compute the bucket index using the key's hash code
        int hashCode = key.GetHashCode();
        int index = Math.Abs(hashCode) % buckets.Length;
        return index;
    }
}


// int hashCode = key.GetHashCode();: This line retrieves the hash code of the provided key
//  using the GetHashCode method. The hash code is an integer value that represents the
//   content of the object. It is used to efficiently organize and
//    locate items in hash-based data structures, like dictionaries.
