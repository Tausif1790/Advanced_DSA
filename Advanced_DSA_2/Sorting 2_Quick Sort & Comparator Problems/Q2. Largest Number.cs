Problem Description
Given an array A of non-negative integers, arrange them such that they form the largest number.
Note: The result may be very large, so you need to return a string instead of an integer.
Input 1: A = [3, 30, 34, 5, 9]
Input 2: A = [2, 3, 9, 0]
 
Output 1: "9534330"
Output 2: "9320"
//--------------------------//  //-------------------------------------//
using System.Text;

class Solution {
    public string largestNumber(List<int> A) {
        A.Sort(new LargestNumberComparator());      // Sort the list of integers using a custom comparator
        StringBuilder sb = new StringBuilder();     // Use StringBuilder for efficient string concatenation

        for (int i = 0; i < A.Count; i++) {         // Append sorted integers to the StringBuilder
            sb.Append(A[i].ToString());
        }
        if (A[0] == 0) {                            // If the largest number is "0", return "0"
            return "0";
        }

        return sb.ToString();
    }
}

class LargestNumberComparator : IComparer<int>{
    public int Compare(int a, int b){
        string ab = a.ToString() + b.ToString();
        string ba = b.ToString() + a.ToString();

        int cmpResult = ab.CompareTo(ba);           // "ay" CompareTo "by" ==> -ve value //"ay" CompareTo "ax" ==> +ve value // same => 0

        if(cmpResult < 0){
            return 1;
        }
        else if(cmpResult > 0){
            return -1;
        }
        return 0;
    }

    /*  // same function
    class LargestNumberComparator : IComparer<int> {
    public int Compare(int a, int b) {
        // Convert integers to strings for comparison
        string ab = a.ToString() + b.ToString();
        string ba = b.ToString() + a.ToString();

        // Use the default string comparison to determine the order
        return ba.CompareTo(ab);
    }
    */
}

//--------------------------//2nd way-------------------------------------//
using System.Text;

class Solution {
    public string largestNumber(List<int> A) {
        // Convert integers to strings
    List<string> strList = A.Select(x => x.ToString()).ToList();

    // Sort the strings based on custom comparison
    strList.Sort(new LargestNumberComparator());

    // Concatenate the sorted strings to form the largest number
    string ans = string.Join("", strList);

    //// If the largest number is "0", return "0"
        if (A[0] == 0) {
            return "0";
        }

        // Otherwise, return the result as a string
        return ans;
    }
}

class LargestNumberComparator : IComparer<string> {
    public int Compare(string a, string b) {
        string ab = a + b;
        string ba = b + a;
        return ba.CompareTo(ab); // Compare in reverse order for descending sort
    }
}
