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