The Fibonacci numbers are the numbers in the following integer sequence.
0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, ……..

In mathematical terms, the sequence Fn of Fibonacci numbers is defined by the recurrence relation:
Fn = Fn-1 + Fn-2
Given a number A, find and return the Ath Fibonacci Number using recursion. 
Given that F0 = 0 and F1 = 1.

//------------------------------------------------//
class Solution {
    public int findAthFibonacci(int A) {
        if(A==0 || A==1){
            return A;
        }

        int sa1 = findAthFibonacci(A-1);
        int sa2 = findAthFibonacci(A-2);

        return sa1 + sa2;
    }
}

/*
TC
step 1: x = How many time you are generating this function? => n + 1 => n
step 2: y = Inside the function in stack space, what is TC? => O(1)

TC: x * y => O(n)

SC
step 1: x = Stack hieght => n + 1 => O(n)
step 2: y = Inside the function in stack space, what is Sc? => O(1)

SC: x * y => O(n)
*/
