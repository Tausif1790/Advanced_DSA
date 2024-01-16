There is a football event going on in your city. In this event, you are given A passes and players having ids between 1 and 106.
Initially, some player with a given id had the ball in his possession. You have to make a program to display the id of the player who possessed the ball after exactly A passes.
There are two kinds of passes:
1) ID
2) 0
For the first kind of pass, the player in possession of the ball passes the ball "forward" to the player with id = ID.
For the second kind of pass, the player in possession of the ball passes the ball back to the player who had forwarded the ball to him.
In the second kind of pass "0" just means Back Pass.
Return the ID of the player who currently possesses the ball.

Input 1:
 A = 10
 B = 23
 C = [86, 63, 60, 0, 47, 0, 99, 9, 0, 0]

 Output 1: 63

//----------------------// O(A), O(A) //---------------------//
// see in SCL portal
class Solution {
    public int solve(int A, int B, List<int> C) {
        Stack<int> st = new Stack<int>();
        st.Push(B);                 // Initially, player B possesses the ball

        for(int i=0; i<A; i++){
            if(C[i] == 0){          // If the pass is of type '0', it's a Back Pass, pop the current possessor
                st.Pop();
            }else{
                st.Push(C[i]);      // If the pass is of type 'ID', pass the ball 'forward' to the player with the specified ID
            }
        }
        return st.Peek();            // Return the ID of the player who currently possesses the ball
    }
}
