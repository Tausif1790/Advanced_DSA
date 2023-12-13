using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //imp notes: Key are unordered

        // All keys
        foreach (string key in myDictionary.Keys)
        {
            Console.WriteLine(key);
        }

        // Dictionary
        Console.WriteLine("Dictionary Operations:");
        var myDictionary = new Dictionary<string, int>();

        // Add
        myDictionary.Add("One", 1);
        myDictionary.Add("Two", 2);

        // Access
        int value = myDictionary["One"];
        Console.WriteLine($"Value for 'One': {value}");

        // Check existence
        if (myDictionary.ContainsKey("Two"))
            Console.WriteLine("'Two' exists in the dictionary");

        // Update
        myDictionary["Two"] = 22;

        // Remove
        myDictionary.Remove("One");

        // Iterate
        foreach (var kvp in myDictionary)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        // HashSet
        Console.WriteLine("\nHashSet Operations:");
        var myHashSet = new HashSet<int>();

        // Add
        myHashSet.Add(1);
        myHashSet.Add(2);

        // Check existence
        if (myHashSet.Contains(2))
            Console.WriteLine("2 exists in the hash set");

        // Remove
        myHashSet.Remove(1);

        // Clear
        myHashSet.Clear();

        // Count
        int count = myHashSet.Count;
        Console.WriteLine($"Number of elements in HashSet: {count}");

        // UnionWith
        var otherHashSet = new HashSet<int> { 2, 3, 4 };
        myHashSet.UnionWith(otherHashSet);

        // Iterate
        foreach (var item in myHashSet)
        {
            Console.WriteLine(item);
        }
    }
}