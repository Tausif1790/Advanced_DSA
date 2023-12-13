Scooby has 3 three integers A, B, and C.
Scooby calls a positive integer special if it is divisible by B and it is divisible by C.
 You need to tell the number of special integers less than or equal to A.
Input 1:
 A = 12
 B = 3
 C = 2
Input 2:
 A = 6
 B = 1
 C = 4

Output 1: 2
Output 2: 1
 //---------------------------------------------------------------------//
class Solution {
    public int solve(int A, int B, int C) {
        int count = A/lcmOfTwoNymber(B, C);
        return count;
    }

    public int gcd(int a, int b){
        if(b == 0){
            return a;
        }
        return gcd(b, a%b);
    }

    public int lcmOfTwoNymber(int a, int b){
        int lcm = (a*b)/gcd(a, b);
        return lcm;
    }
}

/*
This approach computes the LCM of B and C using the formula (a * b) / gcd(a, b). Then,
 it calculates how many multiples of the LCM are less than or equal to A, which directly gives you
 the count of special integers. This reduces the time complexity compared to iterating through all numbers up to A.


*/

//TLE
/*
class Solution {
    public int solve(int A, int B, int C) {
        int count = 0;
        for(int i=1; i<=A; i++){
            if(i%B == 0 && i%C ==0){
                //Console.WriteLine("Debug: i = " + i + ", currGdc = " + A%B);
                count++;
            }
        }

        return count;
    }
}
*/