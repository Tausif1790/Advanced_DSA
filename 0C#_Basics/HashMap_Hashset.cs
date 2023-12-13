using System;
using System.Collections.Generic;

https://www.tutorialsteacher.com/csharp/csharp-dictionary

class Program
{
	static void Main()
	{
		// HashSet Operations
		HashSet<int> set = new HashSet<int>();

		// Adding elements to the HashSet
		set.Add(42);
		set.Add(24);

		// Get a Element 
		int GetElement = 42;   //Key

		// Removing an element from the HashSet
		set.Remove(24);

		// Checking if an element is present in the HashSet
		bool contains = set.Contains(42);

		// Getting the count of elements in the HashSet
		int setCount = set.Count;

		// Clearing all elements from the HashSet
		set.Clear();

		//---------------// Dictionary Operations//-----------------------------------------
		Dictionary<string, int> dictionary = new Dictionary<string, int>();

		// Adding a key-value pair to the Dictionary
		dictionary.Add("key", 42);

		// Get an element
		dictionary[key];

		// Removing a key-value pair from the Dictionary
		dictionary.Remove("key");

		// Checking if a key is present in the Dictionary
		bool containsKey = dictionary.ContainsKey("key");

		// Getting the count of key-value pairs in the Dictionary
		int dictCount = dictionary.Count;

		// Clearing all key-value pairs from the Dictionary
		dictionary.Clear();

		Console.WriteLine($"HashSet Count: {setCount}"); // Output: HashSet Count: 0
		Console.WriteLine($"Dictionary Count: {dictCount}"); // Output: Dictionary Count: 0
		Console.WriteLine($"HashSet Contains 42: {contains}"); // Output: HashSet Contains 42: True
		Console.WriteLine($"Dictionary Contains Key: {containsKey}"); // Output: Dictionary Contains Key: False
	}
}
