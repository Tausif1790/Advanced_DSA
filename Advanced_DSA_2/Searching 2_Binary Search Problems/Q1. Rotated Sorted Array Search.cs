Given a sorted array of integers A of size N and an integer B, 
where array A is rotated at some pivot unknown beforehand.
For example, the array [0, 1, 2, 4, 5, 6, 7] might become [4, 5, 6, 7, 0, 1, 2].
Your task is to search for the target value B in the array. If found, return its index; otherwise, return -1.
You can assume that no duplicates exist in the array.
NOTE: You are expected to solve this problem with a time complexity of O(log(N)).

Input 1:
A = [4, 5, 6, 7, 0, 1, 2, 3]
B = 4 
Input 2:
A : [ 9, 10, 3, 5, 6, 8 ]
B : 5

Output 1: 0 
Output 2: 3

//-----------------------// O(log(N)) //--------------------------------//
class Solution {
    public int search(List<int> A, int B) {
        int target = B;
        int start = 0;
        int end = A.Count - 1;

        while(start <= end){
            int midIdx = (start + end) / 2;

            // If the target is found at the middle index
            if(target == A[midIdx]){
                return midIdx;
            }

            // Check if the target value is in the 2nd part of the rotated array
            if(target < A[0]){
                // Target value in part 2 and midValue in part 1
                if(A[midIdx] >= A[0]){
                    start = midIdx + 1;
                }
                else{   
                    // Target value in part 2 and midValue in part 2
                    // Apply binary search (target and midValue in the same part)
                    if(A[midIdx] < target){
                        start = midIdx + 1;
                    }
                    else{
                        end = midIdx - 1;
                    }
                }
            }

            // Check if the target value is in the 1st part of the rotated array
            if(target >= A[0]){
                // Target value in part 1 and midValue in part 2
                if(A[midIdx] < A[0]){
                    end = midIdx - 1;
                }
                else{
                    // Target value in part 1 and midValue in part 1
                    // Apply binary search (target and midValue in the same part)
                    if(A[midIdx] < target){
                        start = midIdx + 1;
                    }
                    else{
                        end = midIdx - 1;
                    }
                }
            }
        }

        // If the target is not found
        return -1;
    }
}
