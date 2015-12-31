Given a string of numbers and operators, return all possible results from computing all the different possible ways 
to group numbers and operators. The valid operators are +, - and *.

Example 1
Input: "2-1-1".

((2-1)-1) = 0
(2-(1-1)) = 2
Output: [0, 2]


Example 2
Input: "2*3-4*5"

(2*(3-(4*5))) = -34
((2*3)-(4*5)) = -14
((2*(3-4))*5) = -10
(2*((3-4)*5)) = -10
(((2*3)-4)*5) = 10
Output: [-34, -14, -10, -10, 10]


public class Solution {
    // tricky: recursive divide and conqure 
    public IList<int> DiffWaysToCompute(string input) {
        IList<int> result = new List<int>();
        for(int i = 0; i < input.Length; i++){
            if(input[i] == '+' || input[i] == '-' || input[i] == '*'){
                string left = input.Substring(0, i);
                string right = input.Substring(i+1, input.Length - 1 - i);
                IList<int> left_result = DiffWaysToCompute(left);
                IList<int> right_result = DiffWaysToCompute(right);
                foreach(int l in left_result){
                    foreach(int r in right_result){
                        if(input[i] == '+') result.Add(l+r);
                        if(input[i] == '-') result.Add(l-r);
                        if(input[i] == '*') result.Add(l*r);
                    }
                }
            }
        }
        if(result.Count == 0) result.Add(Int32.Parse(input)); // only numbers left
        return result;
    }
}