Alex has a cat named Boomer. He decides to put his cat to the test for eternity.
He starts on day 1 with one stash of food unit, every next day, the stash doubles.
If Boomer is well behaved during a particular day, only then she receives food worth equal to the stash produced on that day.
Boomer receives a net worth of A units of food. What is the number of days she received the stash?

Input 1: A = 5   // 101
Input 2: A = 8   //1000
A = 95           //1011111

Output 1: 2
Output 2: 1
Output 3: 6

//--------------------------------------------------------//
class Solution {
    public int solve(int A) {
        int count = 0;

        while(A>0){
            if((A & 1) == 1){       // Check if the least significant bit of A is 1 (a set bit).
                count++;
            }

            A = A>>1;       // Right-shift A to examine the next bit.
        }

        return count;
    }
}

//TC: O(log(A))
//SC: O(1)