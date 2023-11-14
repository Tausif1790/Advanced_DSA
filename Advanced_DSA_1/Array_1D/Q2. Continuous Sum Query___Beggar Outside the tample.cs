There are A beggars sitting in a row outside a temple. Each beggar initially has an empty pot.
 When the devotees come to the temple, they donate some amount of coins to these beggars. 
 Each devotee gives a fixed amount of coin(according to their faith and ability) to some K beggars sitting next to each other.
Given the amount P donated by each devotee to the beggars ranging from L to R index,
 where 1 <= L <= R <= A, find out the final amount of money in each beggar's pot at the end of the day, 
 provided they don't fill their pots by any other means.
For ith devotee B[i][0] = L, B[i][1] = R, B[i][2] = P, given by the 2D array B

Input 1:- (1-idexing)
A = 5
B =[[1, 2, 10],
    [2, 3, 20],
    [2, 5, 25]]

Output 1:-
10 55 45 25 25

//------------------------------------------//
class Solution {
    public List<int> solve(int A, List<List<int>> B) {
        int[] arr = new int[A];
        int n = B.Count;

        for(int i=0; i<n; i++){
            int l = B[i][0];
            int r = B[i][1];
            int val = B[i][2];

            arr[l-1] += val;

            if(r < arr.Length){
                arr[r] -= val;
            }

        }

        for(int i=1; i<A; i++){
            arr[i] = arr[i-1] + arr[i];
        }

        return new List<int>(arr);
    }
}

//TC: (n+q)
//SC: (1)

//-------Brute force------------//
for every query -
    go and do the addition form idx to till end of the arry 

//TC: (n*q)
//SC: (1)