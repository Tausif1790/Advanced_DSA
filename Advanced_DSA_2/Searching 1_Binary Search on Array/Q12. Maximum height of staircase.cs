Problem Description
Given an integer A representing the number of square blocks. The height of each square block is 1.
 The task is to create a staircase of max-height using these blocks.
The first stair would require only one block, and the second stair would require two blocks, and so on.
Find and return the maximum height of the staircase.

Input 1: A = 10
Input 2: A = 20

Output 1: 4
Output 2: 5

//------------------------------------------------------------//
class Solution {
    public int solve(int A) {
        int height = 0;
        int blocksUsed = 0;

        while (blocksUsed <= A) {
            height++;
            blocksUsed += height;
        }

        return height - 1;
    }
}
//time complexity : O(sqrt(A))

//-------------------// Using BS //------------------------------//
class Solution {
    public int solve(int A) {
        int start = 0, end = 1000*1000*1000, ans = 0;
        while(start <= end){
            int mid = (start + end)/2;

            if((long)mid * (mid + 1) / 2 == A){     // mid * (mid + 1) / 2 => total no. of block used at mid-th point
                return mid;
            }
            else if((long)mid * (mid + 1) / 2 > A)
                end = mid - 1;   
            else{
                ans = mid;
                start = mid + 1;
            }
        }
        return ans;
    }
}
//TC: O(logN)