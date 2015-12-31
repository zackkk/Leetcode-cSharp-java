Given a string containing only digits, restore it by returning all possible valid IP address combinations.

For example:
Given "25525511135",

return ["255.255.11.135", "255.255.111.35"]. (Order does not matter)


public class Solution {
    // Fairly small N, so use brute force for all possible lengths of four parts
    public IList<string> RestoreIpAddresses(string s) {
        IList<string> result = new List<string>();
        for(int len1 = 1; len1 <= 3; len1++){
            for(int len2 = 1; len2 <= 3; len2++){
                for(int len3 = 1; len3 <= 3; len3++){
                    for(int len4 = 1; len4 <= 3; len4++){
                        if(len1 + len2 + len3 + len4 != s.Length) continue;
                        string s1 = s.Substring(0, len1);
                        string s2 = s.Substring(len1, len2);
                        string s3 = s.Substring(len1 + len2, len3);
                        string s4 = s.Substring(len1 + len2 + len3, len4);
                        if(IsValid(s1) && IsValid(s2) && IsValid(s3) && IsValid(s4)){
                            result.Add(s1 + "." + s2 + "." + s3 + "." + s4);
                        }
                    }
                }
            }
        }
        return result;
    }
    
    bool IsValid(string s){
        if(s.Length > 1 && s[0] == '0') return false; // point
        int num = Int32.Parse(s);
        return num >= 0 && num <= 255;
    }
}