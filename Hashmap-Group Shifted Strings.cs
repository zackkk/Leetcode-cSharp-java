Given a string, we can "shift" each of its letter to its successive letter, 
for example: "abc" -> "bcd". We can keep "shifting" which forms the sequence:

"abc" -> "bcd" -> ... -> "xyz"
Given a list of strings which contains only lowercase alphabets, group all strings that belong to the same shifting sequence.

For example, given: ["abc", "bcd", "acef", "xyz", "az", "ba", "a", "z"], 
Return:

[
  ["abc","bcd","xyz"],
  ["az","ba"],
  ["acef"],
  ["a","z"]
]


public class Solution {
    // each pattern has same diff between letters
    // point: how to generate key for each pattern: (diff + 26) % 26
    public IList<IList<string>> GroupStrings(string[] strings) {
        Array.Sort(strings);
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        for(int i = 0; i < strings.Length; i++) {
            string key = "";
            for(int j = 1; j < strings[i].Length; j++) key += (char)((strings[i][j] - strings[i][j-1] + 26) % 26);
            if(dict.ContainsKey(key) == false) dict[key] = new List<string>();
            dict[key].Add(strings[i]); 
        }
        return new List<IList<string>>(dict.Values);
    }
}