Problem Description
Given an integer A. Unset B bits from the right of A in binary.

For example, if A = 93 and B = 4, the binary representation of A is 1011101.
If we unset the rightmost 4 bits, we get the binary number 1010000, which is equal to the decimal value 80.

//--------------------------------------------//
class Solution {
    public long solve(long A, int B) {
        for(int i=0; i<B; i++){
            if(checkBit(A, i)){
                A = (A ^ (1<<i));
            }
        }
        return A;
    }

    bool checkBit(long A, int b){
        if((A & (1<<b)) == 0){
            return false;
        }
        return true;
    }
}

//TC: O(1)
//SC: O(1)