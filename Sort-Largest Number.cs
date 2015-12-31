Given a list of non negative integers, arrange them such that they form the largest number.

For example, given [3, 30, 34, 5, 9], the largest formed number is 9534330.

Note: The result may be very large, so you need to return a string instead of an integer.


public class Solution {
    // sort using s1+s2 vs s2+s1
    public string LargestNumber(int[] nums) {
        List<string> list = new List<string>();
        foreach(int num in nums) list.Add(num.ToString());
        list.Sort(new Comparison<string>((x, y) => string.Compare(x+y, y+x)));
        
        if(list[list.Count-1] == "0") return "0"; // test case [0,0] should return "0", not "00"
        
        StringBuilder sb = new StringBuilder();
        for(int i = list.Count - 1; i >= 0; i--) sb.Append(list[i]);
        return sb.ToString();
    }
}