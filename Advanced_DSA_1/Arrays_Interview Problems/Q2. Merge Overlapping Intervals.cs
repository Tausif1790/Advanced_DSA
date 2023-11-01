Given a collection of intervals, merge all overlapping intervals. (not ordered)

Input 1:
[1,3],[2,6],[8,10],[15,18]

Output 1:
[1,6],[8,10],[15,18]

//--------------------------------------------------//
using System.Collections.Generic;
using System;

public class Interval {
      public int start;
      public int end;
      public Interval() { start = 0; end = 0; }
      public Interval(int s, int e) { start = s; end = e; }
}
 
class Solution {
    public List<Interval> merge(List<Interval> intervals) {
        // Create a list to store the merged intervals.
        List<Interval> mergedIntervals = new List<Interval>();

        // Sort the intervals by their start values.
        intervals.Sort((a, b) => a.start - b.start);       //TC: O(nlog(n))  //SC: O(1)

        int n = intervals.Count;
        int cs = intervals[0].start;               // current start
        int ce = intervals[0].end;                 // current end

        for(int i=1; i<n; i++){
            int s = intervals[i].start;            // current start after above cs
            int e = intervals[i].end;              // ||

            if(s <= ce){                           //a2 <= bl in notes // Overlapping intervals; update the current end. // in first input [1,3],[2,6]
                ce = Math.Max(e, ce);              // we dont care about start, because start is sorted (first record start will be considered)
                //cs = Math.Min(s, cs);
            }
            else{
                // Non-overlapping interval found; add the current merged interval and update the current start and end.
                Interval temp = new Interval(cs, ce);
                mergedIntervals.Add(temp);
                cs = s;
                ce = e;
            }
        }

        Interval temp2 = new Interval(cs, ce);      // Add the last merged interval.
        mergedIntervals.Add(temp2);
        return mergedIntervals;
    }
}

//TC: O(n)
//SC: O(n)