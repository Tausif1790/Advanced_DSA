You have a set of non-overlapping intervals. You are given a new interval [start, end],
 insert this new interval into the set of intervals (merge if necessary).

You may assume that the intervals were initially sorted according to their start times.

Input 1:
Given intervals [1, 3], [6, 9] insert and merge [2, 5] .

Input 2:
Given intervals [1, 3], [6, 9] insert and merge [2, 6] .

Output 1:
 [ [1, 5], [6, 9] ]
Output 2:
 [ [1, 9] ]

//------------------------------------------------------//
using System;
using System.Collections.Generic;
// first argumnet is list of intervals in which A[i][0] denotes start time and A[i][1] denotes end time of 'i' interval.
// second argument denotes start time of merge interval and 
// third argument denotes end time of merge interval
// must condition (B<C) 
// You  have to return list of intervals 
class Solution {
    public List<List<int>> solve(List<List<int>> A, int B, int C) {
        int n = A.Count;
        int newIntervalStart = B;
        int newIntervalEnd = C;
        List<List<int>> mergeInterval = new List<List<int>>();

        for (int i = 0; i < n; i++) {
            int s = A[i][0]; // Start of the current interval
            int e = A[i][1]; // End of the current interval

            // If the new interval doesn't overlap with the current interval, add it and continue
            if (newIntervalStart > e) {
                mergeInterval.Add(A[i]);
            } 
            // If the new interval ends before the current interval starts, merge and add the rest
            else if (s > newIntervalEnd) {
                List<int> temp = new List<int> { newIntervalStart, newIntervalEnd };
                mergeInterval.Add(temp);

                // Add the remaining non-overlapping intervals
                while (i < n) {
                    mergeInterval.Add(A[i]);
                    i++;
                }
                return mergeInterval;
            } 
            else {
                // Overlapping case
                // Update the new interval's start and end to include the current interval
                newIntervalStart = Math.Min(newIntervalStart, s);
                newIntervalEnd = Math.Max(newIntervalEnd, e);
            }
        }

        // Add the merged new interval
        List<int> temp2 = new List<int> { newIntervalStart, newIntervalEnd };
        mergeInterval.Add(temp2);     // same //mergedIntervals.Add(new List<int> { newIntervalStart, newIntervalEnd });

        return mergeInterval;
    }
}

//TC: O(n)
//SC: O(n)