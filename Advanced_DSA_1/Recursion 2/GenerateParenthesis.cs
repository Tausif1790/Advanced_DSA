public class Solution {
    List<string> result = new List<string>();
    
    public IList<string> GenerateParenthesis(int n) {
        GenerateAndCheck(n, n, "");
        return result;
    }
    
    public void GenerateAndCheck(int opened, int closed, string str)
    {
        // Base case: If both opened and closed counters are zero, add the current sequence to the result list
        if(opened == 0 && closed == 0)
        {
            result.Add(str);
            return;
        }

        // Generate and check for valid combinations by adding a close parenthesis if the number of closed parentheses is less than opened
        if(closed > opened){
            GenerateAndCheck(opened, closed - 1, str + ")");
        }
        
        // Generate and check for valid combinations by adding an open parenthesis if there are remaining open parentheses
        if(opened > 0){
            GenerateAndCheck(opened - 1, closed, str + "(");
        }
        
    }
}