Given an integer array A of size N.
You have to find the product of the three largest integers in array A from range 1 to i, where i goes from 1 to N.
Return an array B where B[i] is the product of the largest 3 integers in range 1 to i in array A. If i < 3, then the integer at index i in B should be -1.

Input 1: A = [1, 2, 3, 4, 5]
Output 1: [-1, -1, 6, 24, 60]

Explanation 1:
 For i = 1, ans = -1
 For i = 2, ans = -1
 For i = 3, ans = 1 * 2 * 3 = 6
 For i = 4, ans = 2 * 3 * 4 = 24
 For i = 5, ans = 3 * 4 * 5 = 60
 So, the output is [-1, -1, 6, 24, 60].
 //---------------------------------------------//
 public class Solution {
    public ArrayList<Integer> solve(ArrayList<Integer> A) {
        int n = A.size();
        ArrayList<Integer> result = new ArrayList<Integer>();
        PriorityQueue<Integer> pq = new PriorityQueue<Integer>();

        int product = 1;
        for(int i=0; i<2; i++){
            pq.add(A.get(i));
            product *= A.get(i);
            result.add(-1);
        }

        pq.add(A.get(2));
        product *= A.get(2);
        result.add(product);

        for(int i=3; i<n; i++){
            if(A.get(i) > pq.peek()){
                int pollValue = pq.poll();
                pq.add(A.get(i));
                product = (product / pollValue) * A.get(i);
                result.add(product);
            }else{
                result.add(product);
            }
        }
        return result;
    }
}
