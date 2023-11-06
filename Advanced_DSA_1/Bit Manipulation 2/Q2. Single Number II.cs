Given an array of integers, every element appears thrice except for one, which occurs once.
Find that element that does not appear thrice.
NOTE: Your algorithm should have a linear runtime complexity.
Could you implement it without using extra memory?

Input 1: A = [1, 2, 4, 3, 3, 2, 2, 3, 1, 1]
Input 2: A = [0, 0, 0, 1]
Output 1: 4
Output 2: 1

//---------------------------------------------//
class Solution {
    public int singleNumber(List<int> A) {
        int unique = 0;
        for(int i=31; i>=0; i--){               // go to every bit
            int ones = 0;
            foreach(int el in A){               // at that bit go to every el and count no of ones
                int bitValue = (el & (1<<i));
                if(bitValue != 0){             //bitValue == 1 will not work 
                                                //(because its 0 or more than 0 (more than zero means set))
                    ones++;
                }
            }
            if(ones%3 == 0){                    // put n instead of 3 if no. of repeating el in n
                // nothing to do with zero      //  1 1 0 0 // 2^1 * 0 + 2^0 * 0  =>0
            }
            else{
                unique += (int)Math.Pow(2, i);         //  1 1 0 0 // 2^3 + 2^2
            }
        }
        return unique;
    }
}

// TC: O(n)
// SC: O(1)