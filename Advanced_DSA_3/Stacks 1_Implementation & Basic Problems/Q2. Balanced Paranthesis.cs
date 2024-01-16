Problem Description
Given an expression string A, examine whether the pairs and the orders of “{“,”}”, ”(“,”)”, ”[“,”]” are correct in A.
Refer to the examples for more clarity.

//--------------------------------------------------//
class Solution {
    public int solve(string A) {
        Stack<char> st = new Stack<char>();           // Stack to store open brackets
        for(int i = 0; i < A.Length; i++){
            char ch = A[i];
            if(isOpenBracket(ch)){
                st.Push(ch);
            }
            else{
                if(st.Count == 0){
                    return 0;             // If there's no corresponding open bracket, it's invalid
                }

                char top = st.Pop();         // Pop the top bracket from the stack
                if(!isValid(top, ch)){
                    return 0;             // If the popped bracket doesn't match the current closing bracket, it's invalid
                }
            }
        }

        if(st.Count == 0){
            return 1;                 // If the stack is empty, all brackets are matched and it's valid
        }

        return 0;                     // If there are still unmatched open brackets, it's invalid
    }

    public bool isValid(char top, char ch){
        if(top == '{' && ch == '}') return true;
        else if (top == '(' && ch == ')') return true;
        else if (top == '[' && ch == ']') return true;
        return false;
    }

    public bool isOpenBracket(char ch){
        if(ch == '{' || ch == '(' || ch == '['){
            return true;                          // Check if the character is an open bracket
        }
        return false;
    }
}

//TC: O(n)
//SC: O(n)