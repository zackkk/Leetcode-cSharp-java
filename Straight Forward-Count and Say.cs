The count-and-say sequence is the sequence of integers beginning as follows:
1, 11, 21, 1211, 111221, ...

1 is read off as "one 1" or 11.
11 is read off as "two 1s" or 21.
21 is read off as "one 2, then one 1" or 1211.
Given an integer n, generate the nth sequence.

Note: The sequence of integers will be represented as a string.


public class Solution {
    // straight forward
    public string CountAndSay(int n) {
        string prev = "1";
        for (int i = 2; i <= n; i++){
            string cur = "";
            int j = 0;
            while(j < prev.Length){
                // One Count&Say part
                int count = 1;
                char say = prev[j];
                while(j + 1 < prev.Length && prev[j+1] == say) { count++; j++; }
                cur += count.ToString();
                cur += say;
                
                // Next part
                j++;
            }
            prev = cur;
        }
        return prev;
    }
}