Once upon a time, in a land far away, there was a wise old sage who loved exploring the mysteries of numbers. One day, while meditating under a tree, he came up with a problem that challenged his intellect. He
wanted to find the longest distance between any two adjacent 1's in the binary representation of a positive integer A. He believed that this distance held a special significance and could unlock hidden secrets of the
universe. Can you help the wise old sage solve this problem?
Note: If there are less than 2 1's in the binary representation of A, return O

//------------------------------------------------------------------------//
class Solution {
    public int solve(int A) {
        int ans = int.MinValue;
        int B = A;
        int cnt = 0;
        while(A>0){
            if((A & 1) != 0){
                cnt++;
            }
            A = A >> 1;
        }
        if(cnt <= 1){
            return 0;
        }
        
        int dis = 0;
        int flag = 0;
        while(B > 0){
            if((B & 1) != 0){
                flag = 1;
                dis = 1;
            }
            else if((B & 1) == 0 && flag == 1){
                dis++;
            }
            ans = Math.Max(ans, dis);
            
            B = B >> 1;
        }
        
        return ans;
    }
}
