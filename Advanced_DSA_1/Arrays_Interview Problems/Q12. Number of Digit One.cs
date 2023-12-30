Problem Description
Given an integer A, find and return the total number of digit 1 appearing in
 all non-negative integers less than or equal to A.
A = 10
A = 11

Output 1: 2
Output 2: 4

//------------------------// Brute force //----------------------------//
class Solution {
    public int solve(int A) {
        int count = 0;
        for(int i=1; i<=A; i++){
            count = count + count1s(i);
        }
        return count;
    }

    public int count1s(int A){
        int count = 0;
        while(A > 0){
            int lastDigit = A%10;
            if(lastDigit == 1){
                count++;
            }
            A = A/10;
        }
        return count;
    }
}
