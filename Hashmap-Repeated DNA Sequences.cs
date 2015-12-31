All DNA is composed of a series of nucleotides abbreviated as A, C, G, and T, 
for example: "ACGAATTCCG". When studying DNA, it is sometimes useful to identify repeated sequences within the DNA.

Write a function to find all the 10-letter-long sequences (substrings) that occur more than once in a DNA molecule.

For example,

Given s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT",

Return:
["AAAAACCCCC", "CCCCCAAAAA"].


public class Solution {
    // Brute force - check all substrings - this version got accepted as well.
    public IList<string> FindRepeatedDnaSequences(string s) {
        Dictionary<string, int> dict = new Dictionary<string, int>(); // the frequency of all 10-letter-long string
        IList<string> result = new List<string>();
        
        for(int i = 0; i < s.Length - 9; i++){
            string str = s.Substring(i, 10);;
            if(dict.ContainsKey(str)){ 
                if(!result.Contains(str)) // avoid duplicates
                    result.Add(str); 
            }
            else dict[str] = 1;
        }
        return result;
    }
    
    
    // use a integer to represent a 10-letter-long string to save space - two bits represent a letter
    // A - 00
    // C - 01
    // G - 10
    // T - 11
    public IList<string> FindRepeatedDnaSequences2(string s) {
        Dictionary<int, int> dict = new Dictionary<int, int>(); // the frequency of bit representation of 10-letter-long string
        IList<string> result = new List<string>();
        
        for(int i = 0; i < s.Length - 9; i++){
            int key = 0;
            // Get hash code (int representation) of a substring
            for(int j = 0; j < 10; j++){
                key <<= 2;
                if(s[i+j] == 'A') { key |= 0; continue; }
                if(s[i+j] == 'C') { key |= 1; continue; }
                if(s[i+j] == 'G') { key |= 2; continue; }
                if(s[i+j] == 'T') { key |= 3; continue; }
            }
            if(dict.ContainsKey(key)){ 
                string str = s.Substring(i, 10);
                if(!result.Contains(str)) // avoid duplicates
                    result.Add(str); 
            }
            else dict[key] = 1;
        }
        return result;
    }
}