A = [1, 3, 2, 3, 3]
 B = [5, 6, 1, 3, 9]
Input 2:
 A = [3, 8, 7, 5]
 B = [3, 1, 7, 19]

Output 1: 20
Output 2: 30
//----------------------------------//
public class Solution {
    public int solve(ArrayList<Integer> A, ArrayList<Integer> B) {
        // Initialize variables
        int n = A.size();   // Size of arrays
        int ans = 0;        // Final answer
        ArrayList<Pair> pair = new ArrayList<Pair>();  // List to store pairs of time and profit
        PriorityQueue<Integer> pq = new PriorityQueue<Integer>();  // Priority queue to keep track of profits

        // Populate the pair list with elements from A and B
        for(int i=0; i<n; i++){
            pair.add(new Pair(A.get(i), B.get(i)));
        }

        // Sort the list based on the 'time' attribute
        pair.sort((a, b) -> a.time - b.time);

        int T = 0;  // Variable to keep track of time
        for(int i=0; i<n; i++){
            // Check if it's the right time to buy the car
            if(pair.get(i).time - 1 >= T){
                pq.add(pair.get(i).profit);  // Add profit to the priority queue
                T++;  // Increment time
            }
            else{
                // If buying at current time is not optimal, check if the current car's profit is greater than the least profitable bought car
                if(pq.peek() < pair.get(i).profit){
                    pq.poll();  // Remove the least profitable bought car
                    pq.add(pair.get(i).profit);  // Add the profit of the current car
                }
            }
        }

        // Calculate the final answer by summing up profits
        while(!pq.isEmpty()) {
            ans = (ans + pq.poll()) % 1000000007;
        }
        return ans;  // Return the final answer
    }

    // Pair class to represent a pair of time and profit
    public class Pair{
        public int time;
        public int profit;
        public Pair(int time, int profit){
            this.time = time;
            this.profit = profit;
        }
    }
}
