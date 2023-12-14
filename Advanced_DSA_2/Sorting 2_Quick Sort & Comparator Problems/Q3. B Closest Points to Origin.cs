We have a list A of points (x, y) on the plane. Find the B closest points to the origin (0, 0).
Here, the distance between two points on a plane is the Euclidean distance.
You may return the answer in any order. The answer is guaranteed to be unique (except for the order that it is in.)
NOTE: Euclidean distance between two points P1(x1, y1) and P2(x2, y2) is sqrt( (x1-x2)2 + (y1-y2)2 ).
//-----------------------------------------------------------------------//
class Solution {
    public List<List<int>> solve(List<List<int>> A, int B) {
        List<List<int>> ans = new List<List<int>>();
        // Sorting the list of points based on distance from the origin
        A.Sort(new DistanceFromOriginComparator());

        for(int i=0; i<B; i++){
            ans.Add(A[i]);
        }

        return ans;
    }
}

class DistanceFromOriginComparator : IComparer<List<int>>{
    // Custom comparator to compare two points based on their distance from the origin
    public int Compare(List<int> a, List<int> b){
        double d1 = Math.Sqrt(a[0]*a[0] + a[1]*a[1]);
        double d2 = Math.Sqrt(b[0]*b[0] + b[1]*b[1]);

        if(d1 < d2){
            return -1;
        }
        else if(d1 > d2){
            return 1;
        }
        return 0;
    }
}
