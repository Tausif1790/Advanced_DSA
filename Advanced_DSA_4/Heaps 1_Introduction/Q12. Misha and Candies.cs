Misha loves eating candies. She has been given N boxes of Candies.
She decides that every time she will choose a box having the minimum number of candies, eat half of the candies and put the remaining candies in the other box that has the minimum number of candies.
Misha does not like a box if it has the number of candies greater than B so she won't eat from that box. Can you find how many candies she will eat?
NOTE 1: If a box has an odd number of candies then Misha will eat the floor(odd / 2)
NOTE 2: The same box will not be chosen again.
Input 1:
 A = [3, 2, 3]
 B = 4
Input 2:
 A = [1, 2, 1]
 B = 2
 Output 1: 2
Output 2: 1
//--------------------------------------------//\
public class Solution {
    public int solve(int[] array, int target) {
        // Initialize the answer variable
        int result = 0;
        // Create a priority queue to store elements
        PriorityQueue<Integer> pq = new PriorityQueue<Integer>();

        // Insert the target plus a constant into the priority queue
        pq.offer(target + 10);

        // Push all elements of the array into the priority queue
        for(int value : array){
            pq.offer(value);
        }

        // Loop until the priority queue is empty
        while(!pq.isEmpty()){
            int value = pq.poll();
            if(value > target){              // If the value exceeds the target, exit the loop
                break;
            }

            // If the value is even
            if(value % 2 == 0){
                result += value / 2;
                // Get the next element from the priority queue
                int temp = pq.poll();
                pq.offer(temp + (value / 2));               // Insert the modified value back into the priority queue
            }
            else{
                result += value / 2;
                int temp = pq.poll();
                pq.offer(temp + (value / 2) + 1);           // Insert the modified value back into the priority queue, adding 1 to half the value
            }
        }
        return result;
    }
}
