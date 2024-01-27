Given a string A denoting an expression. It contains the following operators '+', '-', '*', '/'.
Check whether A has redundant braces or not.
NOTE: A will be always a valid expression and will not contain any white spaces.
 A = "((a+b))"
Input 2:
 A = "(a+(a+b))"
Output 1: 1
Output 2: 0

//--------------------------------------------------//
class Solution {
    public int braces(string A) {
        int n = A.Length;
        Stack<char> st = new Stack<char>();

        for (int i = 0; i < n; i++) {
            char ch = A[i];

            if (isOperator(ch)) { // If it's an operand, push onto the stack
                st.Push(ch);
            } else if (ch == ')') {
                if (st.Peek() == '(') { // If the top of the stack is '(', it means redundant brackets
                    return 1;
                } else {
                    while (st.Count > 0 && st.Peek() != '(') {
                        st.Pop(); // Pop operators inside the brackets
                    }
                    st.Pop(); // Remove the '(' bracket
                }
            } else {
                continue; // Skip characters other than operators and brackets
            }
        }

        return 0; // No redundant brackets found
    }

    public bool isOperator(char ch) {
        if (ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '(') {
            return true; // Returns true if the character is an operand or an opening bracket
        }
        return false; // Returns false if the character is not an operand or an opening bracket
    }
}
