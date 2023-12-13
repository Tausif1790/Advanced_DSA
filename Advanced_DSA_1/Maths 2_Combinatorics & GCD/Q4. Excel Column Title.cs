Problem Description
Given a positive integer A, return its corresponding column title as it appears in an Excel sheet.
For example:
    1 -> A
    2 -> B
    3 -> C
    ...
    26 -> Z
    27 -> AA
    28 -> AB 

Problem Constraints
1 <= A <= 109

A = 3
A = 27

Output 1: "C"
Output 2: "AA"

//----------------------------------------------------------------//
class Solution {
    public string convertToTitle(int A) {
        List<char> GetAlphabets = GetAlphabetList();
        string ans = "";

        // Convert the integer to Excel column title
        while(A > 0){
            int remainder = (A - 1) % 26;
            ans = GetAlphabets[remainder] + ans;
            A = (A-1) / 26;                  // Update A to the quotient for the next iteration
        }
        
        return ans;
    }

    public List<char> GetAlphabetList()
    {
        List<char> alphabetList = new List<char>();

        // ASCII values for A to Z are 65 to 90
        for (int asciiValue = 65; asciiValue <= 90; asciiValue++)
        {
            char letter = (char)asciiValue;
            alphabetList.Add(letter);
        }

        return alphabetList;
    }
}

//TC: O(Log base26 n)
//SC: O(1)

// TC: line no. 10 -> n/26 n/26*26 .....