Given an integer A, find and return the Ath magic number.
A magic number is defined as a number that can be expressed as a power of 5 or a sum of unique powers of 5.
First few magic numbers are 5, 25, 30(5 + 25), 125, 130(125 + 5), ….

//---------------------------------------------------------//
class Solution {
    public int solve(int A) {
        int ans = 0;
        int pow = 1;
        while(A>0){
            if((A & 1) == 1){             // =(A & (1<<1))
                ans += (int)Math.Pow(5, pow);
            }
            
            A = A>>1;                    // Right Shift  // A=5  itr ==> 1 0 1 // 1 0 // 1 // 0
            pow++;
        }
        return ans;
    }
}

//TC: O(log(A))
//SC: O(1)
//The number of iterations depends on the number of bits set in the binary representation of A.
// This is typically O(log(A)), where log denotes the logarithm base 2.
//Therefore, the time complexity of the code is O(log(A)).

