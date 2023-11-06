Given an array of positive integers A, two integers appear only once, and all the other integers appear twice.
Find the two integers that appear only once.
Note: Return the two numbers in ascending order.

Input 1: A = [1, 2, 3, 1, 2, 4]
Input 2: A = [1, 2]
Output 1: [3, 4]
Output 2: [1, 2]

expected:
TC: O(n)
SC: O(1)

//-------------------------------------------------------------//
class Solution {
    public List<int> solve(List<int> A) {
        int n = A.Count;
        List<int> ans = new List<int>();

        int xor = 0;

        // XOR of all el
        foreach(int el in A){
            xor = xor ^ el;                          // example:- 010010
        }

        int rmsb = xor & twosCompliment(xor);            //Right most significant bit // example:- 000010

        int x = 0;                                 // XOR of all el whose 1st bit is 0 (from above example)
        int y = 0;                                 // XOR of all el whose 1st bit is 1 (from above example)

        foreach(int el in A){
            if((el & rmsb) == 0){
                x = x ^ el;
            }
            else{
                y = y ^ el;
            }
        }
        ans.Add(Math.Min(x, y));
        ans.Add(Math.Max(x, y));
        return ans;
    }

    int twosCompliment(int a){
        int num = ~a;
        num = num + 1;
        return num;
    }

}
