Write a function that takes an integer and returns the number of 1 bits present in its binary representation.

Input 1:
11
Input 2:
6

Example Output
Output 1:
3
Output 2:
2

//------------------TC: O(1), SC: O(1)-------------------//
class Solution {
    // Function to count the number of set bits (1s) in the binary representation of 'A'
    public int numSetBits(int A) {
        int count = 0;
        for(int i = 0; i < 32; i++){
            if(checkBit(A, i)){
                count++;
            }
        }
        return count;
    }
    // Returns true if the bit is set, false otherwise
    bool checkBit(int A, int k){
        if((A & (1 << k)) == 0){
            return false;
        }
        return true;
    }

    /* The following function is commented because it is incorrect.
     * It checks for a set bit (bit is 1) and returns true if the bit is set.
     * However, the correct behavior should be to check if the bit is clear (bit is 0).
     * The function above, which checks if the bit is clear, is the correct implementation.
     * This is why the commented function should not be used.
     */
    // bool checkBit(int A, int k){
    //     if((A & (1<<k)) == 1){
    //         return true;
    //     }
    //     return false;
    // }
}


//------------------// Using Right shift operator // TC: O(1), SC: O(1)-------------------//
class Solution {
    public int numSetBits(int A) {
        int count = 0;
        while(A > 0){
            if((A & 1) != 0){            // if(n&1) -> is not working
                count++;
            }
            A = A >> 1;
        }
        return count;
    }
}