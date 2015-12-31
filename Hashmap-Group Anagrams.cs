Given an array of strings, group anagrams together.

For example, given: ["eat", "tea", "tan", "ate", "nat", "bat"], 
Return:

[
  ["ate", "eat","tea"],
  ["nat","tan"],
  ["bat"]
]


public class Solution {
    // sort string as key
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, IList<string>> dict = new Dictionary<string, IList<string>>();
        Array.Sort(strs); //  forgot this won't pass
        foreach(string str in strs){
            char[] tmp = str.ToCharArray();
            Array.Sort(tmp);
            string key = new string(tmp); // tmp.ToString() doesn't work
            if(dict.ContainsKey(key) == false){
                dict[key] = new List<string>();
            }
            dict[key].Add(str);
        }
        return new List<IList<string>>(dict.Values);
    }
}