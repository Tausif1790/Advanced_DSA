Given a sorted array of integers (not necessarily distinct) A and an integer B,
 find and return how many pair of integers ( A[i], A[j] ) such that i != j have sum equal to B.
Since the number of such pairs can be very large, return number of such pairs modulo (109 + 7).

A = [1, 1, 1]
B = 2

A = [1, 5, 7, 10]
B = 8

Output 1: 3
Output 2: 1

//------------------------// TC: O(n) //-----------------------------------//
class Solution {
    public int solve(List<int> A, int B) {
        long mod = (int)Math.Pow(10, 9) + 7;
        long count = 0;
        int i = 0;
        int j = A.Count - 1;
        while(i < j) {
            long sum = A[i] + A[j];

            // Adjust pointers based on the comparison with the target sum B
            if(sum > B) {
                j--;
            }
            else if(sum < B) {
                i++;
            }
            else {
                long countI = 1;
                long countJ = 1;
                // Count occurrences of A[i]
                while(i < j && A[i] == A[i + 1]) {
                    countI++;
                    i++;
                }
                // Count occurrences of A[j]
                while(i < j && A[j] == A[j - 1]) {
                    countJ++;
                    j--;
                }
                // If A[i] and A[j] are different, count the pairs
                if (A[i] != A[j]) {
                    count += (long)(countI % mod * countJ % mod) % mod;
                } else {
                    // If A[i] and A[j] are the same, count combinations (nC2)
                    // A[i] and A[j] are the same, meaning i and j are in the same set of repeated numbers, (1,3,4,4,4,4,6,9) for k=8
                    // Use the combination formula for counting pairs within the same set
                    count += (long)(countI% mod * (countI% mod - 1) / 2) % mod;
                }
                i++;
                j--;
            }
        }
        return (int)(count % mod);
    }
}

If A[i] and A[j] are the same:

In this case, you have the same element at indices i and j in the array.
You want to count the number of pairs formed by these identical elements.
 This is essentially counting combinations (nC2) of the occurrences of the element.
The formula used is (countI % mod * (countI % mod - 1) / 2) % mod.
 Here, (countI % mod - 1) represents choosing 2 occurrences from countI occurrences (n-1C2),
  and then dividing by 2 to account for double counting (since order doesn't matter in combinations).


count += countI * (countI- 1) / 2;
for [4,4,4,4], sum = 8
ans = 6

