You have a string, denoted as A.
To transform the string, you should perform the following operation repeatedly:
Identify the first occurrence of consecutive identical pairs of characters within the string.
Remove this pair of identical characters from the string.
Repeat steps 1 and 2 until there are no more consecutive identical pairs of characters.
The final result will be the transformed string.

Input 1: A = "abccbc"
Input 2: A = "ab"

Output 1: "ac"
Output 2: "ab"

//------------------------------------------------------------//
using System.Text;

class Solution {
    public string solve(string A) {
        Stack<char> st = new Stack<char>();
        for(int i=0; i<A.Length; i++){
            char ch = A[i];
            if(st.Count != 0 && st.Peek() == ch){
                st.Pop();
            }
            else{
                st.Push(ch);
            }
        }

        StringBuilder sb = new StringBuilder();
        while(st.Count != 0){
            sb.Append(st.Pop());
        }

        // Convert StringBuilder to string, then reverse the string
        string reversedString = sb.ToString();
        char[] reversedArray = reversedString.ToCharArray();
        Array.Reverse(reversedArray);

        // Create a new string from the reversed array
        return new string(reversedArray);

        //Time Limit Exceeded
        // string ans = "";
        // while(st.Count != 0){
        //     ans = st.Pop() + ans;
        // }

        // return ans;
    }
}

//TC: O(n)
//SC: O(n)