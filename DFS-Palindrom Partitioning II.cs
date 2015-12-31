Given a string s, return all the palindromic permutations (without duplicates) of it. 
Return an empty list if no palindromic permutation could be form.

For example:

Given s = "aabb", return ["abba", "baab"].

Given s = "abc", return [].


public class Solution {
    // Generate half of the string + Generate all dictinct permutations
    public IList<string> GeneratePalindromes(string s) {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for(int i = 0; i < s.Length; i++) {
            dict[s[i]] = dict.ContainsKey(s[i]) ? dict[s[i]] + 1 : 1;
        }
        
        // Generate half of the first half of the string
        StringBuilder half = new StringBuilder();
        IList<char> singleChars = new List<char>(); 
        foreach(KeyValuePair<char, int> entry in dict){
            for(int i = 0; i < entry.Value / 2; i++) half.Append(entry.Key);
            if(entry.Value % 2 != 0) singleChars.Add(entry.Key);
        }
        
        if(singleChars.Count > 1) return new List<string>(); // no palindromic permutation could be form
        
        // Generate permutations for half string
        IList<string> permutations =  new List<string>();
        char[] halfChars = half.ToString().ToCharArray();
        bool[] visited = new bool[halfChars.Length];
        StringBuilder sb = new StringBuilder();
        GeneratePermutations(halfChars, visited, sb, permutations);
        
        // Generate result
        IList<string> result = new List<string>();
        foreach(string permutation in permutations){
            char[] charArray = permutation.ToCharArray();
            Array.Reverse(charArray);
            if(singleChars.Count > 0){
                result.Add(permutation + singleChars[0] + new string(charArray));
            }
            else{
                result.Add(permutation + new string(charArray));
            }
        }
        return result;
    }
    
    void GeneratePermutations(char[] halfChars, bool[] visited, StringBuilder sb, IList<string> permutations) {
        if (sb.Length == halfChars.Length) {
            permutations.Add(sb.ToString());
            return;
        }
        for (int i = 0; i < halfChars.Length; i++) {
            // same elements must be visited in order
            if(visited[i] || (i > 0 && halfChars[i] == halfChars[i-1] && visited[i-1] == false)){ continue; }
            visited[i] = true;
            sb.Append(halfChars[i]);
            GeneratePermutations(halfChars, visited, sb, permutations);
            sb.Remove(sb.Length - 1, 1);
            visited[i] = false;
        }
    }
}