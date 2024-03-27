//---------------// GCD, LCM //---------------------//
1. a*b = gcd(a, b)*lcm(a, b);

//By Euclid algo GCD

class Solution {
    public int gcd(int A, int B) {
        if(B == 0){
            return A;
        }
        return gcd(B, A%B);
    }
}
//TC: Log(max(a,b))

//--------------------// Sorting //--------------------------------//
intervals.Sort((a, b) => a.start - b.start);       // 1st way //TC: O(nlog(n))  //SC: O(1)

intervals.Sort(new IntervalSort());                // 2nd way
class IntervalSort : IComparer<Interval>{
    public int Compare(Interval a, Interval b){
        if(a.start < b.start){
            return -1;
        }
        else if(a.start > b.start){
            return 1;
        }
        return 0;
    }
}

// Sort the array using a custom comparison
Array.Sort(myArray, (a, b) => a - b);

//-------------------// //Right most significant bit // example:- 000010 //---------------//
int rmsb = x & twosCompliment(x);
int twosCompliment(int a){
        int num = ~a;
        num = num + 1;
        return num;
    }

//----------------// count factor //-----------------------------------------//
public int CountFactors(int number) {
        if (number <= 0) {
            return 0;
        }
        int count = 0;
        for (int i = 1; i <= Math.Sqrt(number); i++) {
            if (number % i == 0) {
                count++;
                if (number / i != i) {
                    count++;
                }
            }
        }
        return count;
    }

//------------// Compare //---------------------------//
if(A < B){
    return -1;
}
else if(A > B){
    return 1;
}
else{
    return 0;
}
return 0;

(or)
return Math.Sign(pointA - pointB);
(or)
return pointA.CompareTo(pointB);

A.Sort((a,b) => a - b);                 // we can do without create comparator class


//---------------// Reverse StringBuilder/String //------------------//
// Convert StringBuilder to string, then reverse the string
string reversedString = sb.ToString();
char[] reversedArray = reversedString.ToCharArray();
Array.Reverse(reversedArray);

// Create a new string from the reversed array
return new string(reversedArray);

//----------// Explicit conversions (Casting) //---------------------------------//
// Integral Types
        long longValue = 1234567890123456789L;
        int intValue = (int)longValue;
        Console.WriteLine($"Long value: {longValue}, Int value: {intValue}");

        int intNumber = 65;
        char charValue = (char)intNumber;
        Console.WriteLine($"Int value: {intNumber}, Char value: {charValue}");

        // Floating-Point Types
        double doubleValue = 123.456;
        float floatValue = (float)doubleValue;
        Console.WriteLine($"Double value: {doubleValue}, Float value: {floatValue}");

        // Other Conversions
        string numericString = "987";
        int parsedValue = int.Parse(numericString);
        Console.WriteLine($"Parsed value from string: {parsedValue}");

        // Note: Always handle potential exceptions in real-world scenarios, especially when parsing.

        // String to Char
        string charString = "A";
        char charFromString = char.Parse(charString);
        Console.WriteLine($"Parsed char from string: {charFromString}");

        // ToString method

        // Integral Types
        int intValue = 123;
        string intToString = intValue.ToString();
        Console.WriteLine($"Int to String: {intToString}");


