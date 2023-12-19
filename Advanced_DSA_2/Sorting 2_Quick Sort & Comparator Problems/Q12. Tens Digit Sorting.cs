Problem Description
Given an array A of N integers. Sort the array in increasing order of the value at the tens place digit of every number.
If a number has no tens digit, we can assume value to be 0.
If 2 numbers have same tens digit, in that case number with max value will come first
Solution should be based on comparator.

Input 1:
A = [15, 11, 7, 19]
Input 2:
A = [2, 24, 22, 19]

Output 1:
[7, 19, 15, 11]
Output 2:
[2, 19, 24, 22]

//-------------------------------------------------------------//
class Solution {
    public List<int> solve(List<int> numbers) {
        // Sorting based on tens digit using custom comparator
        numbers.Sort(new TensDigitSortingComparator());
        return numbers;
    }
}

class TensDigitSortingComparator : IComparer<int> {
    public int Compare(int x, int y) {
        int tensDigitX = (x % 100) / 10;  // Extracting the tens digit of x
        int tensDigitY = (y % 100) / 10;  // Extracting the tens digit of y

        // Compare based on tens digits
        if (tensDigitX < tensDigitY) {
            return -1;
        } else if (tensDigitX > tensDigitY) {
            return 1;
        } else {
            // If tens digits are equal, compare the numbers themselves
            if (x < y) {
                return 1;
            } else if (x > y) {
                return -1;
            }
            return 0;  // If both numbers are equal
        }
    }
}