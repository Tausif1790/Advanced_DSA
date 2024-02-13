There are N jobs to be done, but you can do only one job at a time.
Given an array A denoting the start time of the jobs and an array B denoting the finish time of the jobs.
Your aim is to select jobs in such a way so that you can finish the maximum number of jobs.
Return the maximum number of jobs you can finish.

Input 1:
 A = [1, 5, 7, 1]
 B = [7, 8, 8, 8]
Input 2:
 A = [3, 2, 6]
 B = [9, 8, 9]

Output 1: 2
Output 2: 1

//------------------//  //---------------------------//
class Solution {
    public int solve(List<int> A, List<int> B) {
        int ans = 0;

        // Create a list of pairs representing start and finish times for each job
        List<List<int>> AB = new List<List<int>>();

        for (int i = 0; i < A.Count; i++) {
            List<int> pair = new List<int> {A[i], B[i]};      // Pairing start and finish times
            AB.Add(pair);
        }
        
        // Sort the list of pairs based on the finish times in ascending order
        AB.Sort((a, b) => a[1].CompareTo(b[1]));              // Sorting based on finish times
        int n = AB.Count;

        // Initialize variables for tracking the number of finished jobs and the end time
        ans = 1;                              // At least one job is finished
        int endTime = AB[0][1];                // Set the end time to the finish time of the first job

        // Iterate through the sorted list of pairs and update the count of finished jobs
        for(int i = 1; i < n; i++){
            // Check if the start time of the current job is greater than or equal to the end time
            if(AB[i][0] >= endTime){
                ans++;                        // Increment the count of finished jobs
                endTime = AB[i][1];            // Update the end time
            }
        }
        return ans;  // Return the maximum number of finished jobs
    }
}
