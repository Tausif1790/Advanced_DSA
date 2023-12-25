public class Solution {
    public class condition implements Comparator<ArrayList<Integer>>{
       @Override
       public int compare (ArrayList<Integer> o1, ArrayList<Integer> o2){  
            int smaller_str_size=Math.min(o1.size(),o2.size());
    //case 1) 1st priority: finding 1st different ele   :    here case: ac, ab
            for(int i=0;i<smaller_str_size; i++) {            
                if(o1.get(i) == o2.get(i) ) continue;
                else {
                    if(o1.get(i)<o2.get(i))  return -1;                  
                    else if(o1.get(i) > o2.get(i)) return 1;
                    else return 0;
                }
           }
    // case2  (never found diff ele till smaller str)  if all eles of both are same till smaller- say abc & abcd  
           if(o1.size() < o2.size()) return -1;    
           else if(o1.size() > o2.size()) return 1;
           else return 0;
       }
    }

    public ArrayList<ArrayList<Integer>> generateSub(ArrayList<Integer> A, ArrayList<Integer> curr_sub , int i, ArrayList<ArrayList<Integer>> power_set){
        int n=A.size();
        ArrayList<Integer> temp=new ArrayList<>(curr_sub);              
        if(i==n){
            power_set.add(temp);        // temp is actually the current subset, & curr_sub= actually not the currentsubset  
            return power_set;
        }    
       
        //a)
        power_set = generateSub(A, temp, i+1, power_set);          
        temp.add (A.get(i) );    
        power_set = generateSub(A, temp, i+1, power_set);

        //b)______________________________________________
        // temp.add (A.get(i) );    
        // power_set = generateSub(A, temp, i+1, power_set);
        // temp.remove(temp.size()-1);    
        // power_set = generateSub(A, temp, i+1, power_set);

        return power_set;
    }

    public ArrayList<  ArrayList<Integer>> subsets(ArrayList<Integer> A) {
        Collections.sort(A);                                                                
        ArrayList<ArrayList<Integer>> power_set=new ArrayList<>();        
        ArrayList<Integer> curr_sub= new ArrayList<>();
        int i=0;
        power_set = generateSub ( A, curr_sub, i, power_set);            
        Collections.sort(power_set, new condition());                                  
        return power_set;
    }
}