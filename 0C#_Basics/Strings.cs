using System;

class Program
{
    static void Main()
    {
        // String Creation
        string str1 = "Hello, ";
        string str2 = "world!";

        // Concatenation
        string concatenated = str1 + str2; // "Hello, world!"

        // Length
        int length = concatenated.Length; // 13

        // Substring
        string substring = concatenated.Substring(0, 5); // "Hello"

        // IndexOf
        int indexOf = concatenated.IndexOf("world"); // 7

        // Replace
        string replaced = concatenated.Replace("world", "C#"); // "Hello, C#!"

        // To Upper/Lower Case
        string upperCase = concatenated.ToUpper(); // "HELLO, WORLD!"
        string lowerCase = concatenated.ToLower(); // "hello, world!"

        // Trim
        string spaced = "   Trim me   ";
        string trimmed = spaced.Trim(); // "Trim me"

        string str = "111";
        string result = str.PadLeft(5, '0'); // Pad with zeros to a total length of 5

        // String Comparison
        bool areEqual = string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase); // false (case-insensitive)

        // Output with Comments
        Console.WriteLine("Concatenated: " + concatenated); // Concatenated: Hello, world!
        Console.WriteLine("Length: " + length); // Length: 13
        Console.WriteLine("Substring: " + substring); // Substring: Hello
        Console.WriteLine("Index of 'world': " + indexOf); // Index of 'world': 7
        Console.WriteLine("Replaced: " + replaced); // Replaced: Hello, C#!
        Console.WriteLine("Upper Case: " + upperCase); // Upper Case: HELLO, WORLD!
        Console.WriteLine("Lower Case: " + lowerCase); // Lower Case: hello, world!
        Console.WriteLine("Trimmed: " + trimmed); // Trimmed: Trim me
        Console.WriteLine("String Comparison (Case-Insensitive): " + areEqual); // String Comparison (Case-Insensitive): False
    }
}

//---------------------------Substring----------------------------------------//

string originalString = "Hello, World!";

// Extract a substring starting at a specific index
string substring1 = originalString.Substring(7); // "World!"

// Extract a substring of a specified length starting at a specific index
string substring2 = originalString.Substring(0, 5); // "Hello"

// Remove characters from a specific index to the end of the string
string removedString = originalString.Remove(5); // "Hello"

// Remove a specific number of characters from a specific index
string removedString2 = originalString.Remove(7, 7); // "Hello, "

// Replace a substring within the original string
string replacedString = originalString.Replace("World", "Universe"); // "Hello, Universe!"

// Check if the string contains a specific substring
bool containsSubstring = originalString.Contains("Hello"); // true

// Check if the string starts with a specific substring
bool startsWithSubstring = originalString.StartsWith("Hello"); // true

// Check if the string ends with a specific substring
bool endsWithSubstring = originalString.EndsWith("World!"); // true

// Find the index of the first occurrence of a substring
int indexOfSubstring = originalString.IndexOf("World"); // 7

// Find the index of the last occurrence of a substring
int lastIndexOfSubstring = originalString.LastIndexOf("l"); // 9

// Split the string based on a separator and get an array of substrings
string[] splitString = originalString.Split(new char[] { ',' }); // ["Hello", " World!"]

// Join an array of strings into a single string with a separator
string[] words = { "Hello", "World", "Universe" };
string joinedString = string.Join(", ", words); // "Hello, World, Universe"

// Convert the string to an array of characters
char[] charArray = originalString.ToCharArray(); // ['H', 'e', 'l', 'l', 'o', ',', ' ', 'W', 'o', 'r', 'l', 'd', '!']

// array to string
string originalString = new string(charArray);

//---------------------------// Using Compare method: //--------------------------------//
int number = 42;
string numberAsString = number.ToString();

string str1 = "ax";
string str2 = "ay";

int result = str1.CompareTo(str2);      // gives -ve //str1 is lexicographically less than str2

if (result < 0) { 
    Console.WriteLine($"{str1} comes before {str2}.");
}
else if (result > 0) {
    Console.WriteLine($"{str1} comes after {str2}.");
}
else {
    Console.WriteLine($"{str1} and {str2} are equal.");
}

// opt:- ax comes before ay.

//------------------------// StringBuilder//---------------//
StringBuilder sb = new StringBuilder();  =>  //we need to use //using System.Text;
sb.Append(A[i].ToString());                  // we can use Append in StringBuilder  
return sb.ToString();                        // convert to sting

// Convert StringBuilder to string, then reverse the string
        string reversedString = sb.ToString();
        char[] reversedArray = reversedString.ToCharArray();
        Array.Reverse(reversedArray);

        // Create a new string from the reversed array
        return new string(reversedArray);
