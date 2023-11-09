Write a program to find the factorial of the given number A using recursion.
Note: The factorial of a number N is defined as the product of the numbers from 1 to N.

//--------------------------------------//
class Solution {
    public int solve(int A) {
        if(A == 0 || A == 1){          //base case
            return 1;
        }

        int sa = solve(A-1);           // logic
        return sa * A;
    }
}

/*
TC
step 1: x = How many time you are generating this function?
x = 1 + 2 + 3 + 4 + 5 + ..... + nth times(2^n)
x = 1 * (2^n -1) / 1 = O(2^n)
step 2: y = Inside the function in stack space, what is TC? => O(1)

TC: x * y => O(2^n)
*/



