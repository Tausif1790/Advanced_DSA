Given two integers A and B. Find the value of A-1 mod B where B is a prime number and gcd(A, B) = 1.
A-1 mod B is also known as modular multiplicative inverse of A under modulo B.

Problem Constraints
1 <= A <= 10^9
1<= B <= 10^9
B is a prime number

Input 1:

 A = 3
 B = 5
Input 2:

 A = 6
 B = 23

 //--------------------------------------------------------//
  class Solution {
    public int solve(int A, int B) {
        long ans = 0;

        // A/A = 1
        // A * A^-1 = 1          // we have to find  A^-1
        // (A * A^-1)%B = 1 % B
        // (A%B * (A^-1)%B )%B = 1 % B        // we have to find (A^-1)%B 
                                        // where range of (A^-1)%B = [1,B-1], [0,B-1] is not posible



        for(int i=1; i<B; i++){
            long temp = (A%B * i )%B;
            if(temp == 1){
                ans = i;
            }
        }

        return (int)ans;
    }
}
