Problem Description
An arithmetic expression is given by a string array A of size N. Evaluate the value of an arithmetic expression in Reverse Polish Notation.
Valid operators are +, -, *, /. Each string may be an integer or an operator.
Note: Reverse Polish Notation is equivalent to Postfix Expression, where operators are written after their operands.

Input 1: A =   ["2", "1", "+", "3", "*"]
Input 2: A = ["4", "13", "5", "/", "+"]
Output 1: 9
Output 2: 6

//---------------// O(n),O(n) //-------------------------//
class Solution {
    public int evalRPN(List<string> A) {
        Stack<int> st = new Stack<int>();
        for(int i = 0; i < A.Count; i++) {
            string str = A[i];

            if (!isOperand(str)) {               // check its not operand
                int intVal = int.Parse(str);
                st.Push(intVal);
            } else {
                int el2 = st.Pop();
                int el1 = st.Pop();

                // Perform operation based on the Operand
                int result = operations(el1, el2, str);
                st.Push(result);
            }
        }
        return st.Peek();
    }

    public int operations(int el1, int el2, string currOperator) {
        int result = 0;
        switch (currOperator) {
            case "+":
                result = el1 + el2;
                break;
            case "-":
                result = el1 - el2;
                break;
            case "*":
                result = el1 * el2;
                break;
            case "/":
                result = el1 / el2;
                break;
            default:
                result = 0;
                break;
        }
        return result;
    }

    public bool isOperand(string str) {
        if (str == "+" || str == "-" || str == "*" || str == "/") {
            return true;
        }
        return false;
    }
}
