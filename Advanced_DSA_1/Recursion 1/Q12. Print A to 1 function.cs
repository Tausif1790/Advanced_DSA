You are given an integer A, print A to 1 using using recursion.

Note :- After printing all the numbers from A to 1, print a new line.

//----------------------------------------------------------//
class Solution {
    public void solve(int A) {
        if(A==1){
            Console.Write(A + " ");
             Console.WriteLine();
            return ;
        }

        Console.Write(A + " ");
        solve(A-1);
    }
}

//Time Complexity : O(A)
//Space Complexity : O(A)