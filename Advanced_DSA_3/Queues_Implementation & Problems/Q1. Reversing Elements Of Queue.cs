 A = [1, 2, 3, 4, 5]
 B = 3
Input 2:
 A = [5, 17, 100, 11]
 B = 2

Output 1: [3, 2, 1, 4, 5]
Output 2: [17, 5, 100, 11]

//----------------------------------------------//
class Solution {
    public List<int> solve(List<int> A, int B) {
        Queue<int> q = new Queue<int>();
        for(int i=B-1; i>=0; i--){
            q.Enqueue(A[i]);
        }
        for(int j=0; j < B; j++){
            A[j] = q.Dequeue();
        }
        return A;
    }
}
