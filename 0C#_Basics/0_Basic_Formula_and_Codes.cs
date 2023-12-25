//---------------// GCD, LCM //---------------------//
1. a*b = gcd(a, b)*lcm(a, b);

//By Euclid algo GCD

class Solution {
    public int gcd(int A, int B) {
        if(B == 0){
            return A;
        }
        return gcd(B, A%B);
    }
}
//TC: Log(max(a,b))

//----------------------------------------------------//
