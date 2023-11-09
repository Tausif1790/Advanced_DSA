You are given an integer A, print 1 to A using using recursion.
Note :- After printing all the numbers from 1 to A, print a new line.

A = 10
1 2 3 4 5 6 7 8 9 10 

//------------------------------------------//  
class Solution {
    public void solve(int A) {
       print1ToA(A);
        Console.WriteLine();
    }

    void print1ToA(int A){
        if(A==1){
            Console.Write(A + " ");
            return ;
        }
        print1ToA(A-1);                                  //Console.Write(A + " ");   //from A to 1
        Console.Write(A + " ");                          //solve(A-1);
    }
}

//Time Complexity : O(A)
//Space Complexity : O(A)