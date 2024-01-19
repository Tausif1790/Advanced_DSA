Given an integer, A. Find and Return first positive A integers in ascending order containing only digits 1, 2, and 3.
NOTE: All the A integers will fit in 32-bit integers.

Input 1: A = 3
Input 2: A = 7
Output 1: [1, 2, 3]
Output 2: [1, 2, 3, 11, 12, 13, 21]

//----------------------------// O(n), O(n) //--------------------------------//
class Solution {
    public List<int> solve(int A) {
        List<int> result = new List<int>();
        Queue<int> myQueue = new  Queue<int>();
        if(A <= 3){
            for(int j=0; j<A; j++){
                result.Add(j+1);
            }
            return result;
        }

        myQueue.Enqueue(1);
        myQueue.Enqueue(2);
        myQueue.Enqueue(3);
        result.Add(1);
        result.Add(2);
        result.Add(3);

        int i = 4;                  // curr position
        while(i<=A){                            //result.Count < A
            int x = myQueue.Dequeue();
            int a = x*10 + 1;
            int b = x*10 + 2;
            int c = x*10 + 3;

            result.Add(a);
            if(i == A) return result; 

            result.Add(b);
            if(i+1 == A) return result;

            result.Add(c);
            if(i+2 == A) return result;

            myQueue.Enqueue(a);
            myQueue.Enqueue(b);
            myQueue.Enqueue(c);
            i += 3;
        }

        return result;
    }
}


