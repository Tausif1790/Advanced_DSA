Given an one-dimensional integer array A of size N and an integer B.
Count all distinct pairs with difference equal to B.
Here a pair is defined as an integer pair (x, y),
 where x and y are both numbers in the array and their absolute difference is B.

A = [8, 12, 16, 4, 0, 20]
B = 4

A = [1, 1, 1, 2, 2]
B = 0

Output: 5
Output: 2

//---------------------// TC: O(nlogn) // My working code remove 2 lines (commented) //----------------------//
class Solution {
    public int solve(List<int> A, int B) {
        A.Sort();
        int n = A.Count;
        int i = 0;
        int j = 1;
        int count = 0;

        while(j < n && i < n) {
            int diff = Math.Abs(A[i] - A[j]);

            if(diff < B) {
                j++;                  // Increment j if the difference is less than B
            }
            else if(diff > B) {
                i++;                  // Increment i if the difference is greater than B

                if (i == j) {
                    j++;              // Move j to the next element if i and j are pointing to the same element
                }
            }
            else {
                count++;              // Increment count if the difference is equal to B
                //i++;                // removed (creates problem)
                j++;

                while(j < n && A[j] == A[j-1]) {
                    //i++;            // removed (creates problem)
                    j++;              // Skip duplicate elements
                } 
            }
        }

        return count; 
    }
}


//---------------------// TC: O(nlogn) // TAs code //----------------------//
class Solution {
    public int solve(List<int> A, int B) {
        A.Sort();                                // Sort the input list in ascending order
        int n = A.Count;
        int i = 0;
        int j = 1;
        int count = 0;
        
        while(j < n && i < n) {
            int diff = Math.Abs(A[i] - A[j]);
            
            if(diff <= B) {                    // If the absolute difference is less than or equal to B
                if(diff == B) {
                    count++;                    // Increment the count if the difference is exactly B
                }    
                j++;                            // Increment j to move to the next element
                
                while(j < n && A[j] == A[j-1]) {
                    j++;                        // Avoid duplicate elements
                }
            } else {                            // diff > B
                i++;                            // Increment i if the difference is greater than B
                if (i == j) {
                    j++;                        // Move j to the next element if i and j are pointing to the same element
                }
            }
        }
        return count;
    }
}


//-------------------// this code is not working //------------------------//
class Solution {
    public int solve(List<int> A, int B) {
        A.Sort();
        int n = A.Count;
        int i = 0;
        int j = 1;
        int count = 0;
        while(j < n && i < n){
            int diff = Math.Abs(A[i] - A[j]);
            if(diff < B){
                //Console.WriteLine($"Incrementing j: {j}");
                j++;
            }
            else if(diff > B){
                //Console.WriteLine($"Incrementing i: {i}");
                i++;
                if (i == j) {
                    //Console.WriteLine($"Incrementing j: {j}");
                    j++;
                }
            }
            else{
                count++;
                //Console.WriteLine($"Count incremented. i: {i}, j: {j}");
                i++;
                j++;
                // avoid duplicate
                while(j < n && A[j] == A[j-1]){
                    //Console.WriteLine($"Incrementing i and j to avoid duplicates: {i}, {j}");
                    j++;
                    i++;
                } 
            }
        }

        return count;
    }
}
