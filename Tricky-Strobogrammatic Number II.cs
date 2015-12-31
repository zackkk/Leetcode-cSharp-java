A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).

Find all strobogrammatic numbers that are of length = n.

For example,
Given n = 2, return ["11","69","88","96"].


public class Solution {
    // recursion from case n-2
    public IList<string> FindStrobogrammatic(int n) {
        return Helper(n, n);
    }
    
    IList<string> Helper(int n, int m){
        if(n == 0) return new List<string>(){""};
        if(n == 1) return new List<string>(){"0", "1", "8"};
        
        IList<string> result = new List<string>();
        IList<string> list = Helper(n-2, m);
        foreach(string str in list){
            if(m != n) result.Add("0" + str + "0"); // "00" can't be added to the most outside layer
            result.Add("6" + str + "9");
            result.Add("9" + str + "6");
            result.Add("1" + str + "1");
            result.Add("8" + str + "8");
        }
        return result;
    }
}