This is a follow up of Shortest Word Distance. 
The only difference is now you are given the list of words and your method 
will be called repeatedly many times with different parameters. How would you optimize it?

Design a class which receives a list of words in the constructor, 
and implements a method that takes two words word1 and word2 and return the shortest distance between these two words in the list.

For example,
Assume that words = ["practice", "makes", "perfect", "coding", "makes"].

Given word1 = “coding”, word2 = “practice”, return 3.
Given word1 = "makes", word2 = "coding", return 1.

Note:
You may assume that word1 does not equal to word2, and word1 and word2 are both in the list.


public class WordDistance {
    // list of words could be long, so only process related indexes + merge idea from merge-sort
    Dictionary<string, IList<int>> dict;
    public WordDistance(string[] words) {
        dict = new Dictionary<string, IList<int>>();
        for(int i = 0; i < words.Length; i++){
            if(dict.ContainsKey(words[i]) == false){
                dict[words[i]] = new List<int>();
            }
            dict[words[i]].Add(i);
        }
    }

    public int Shortest(string word1, string word2) {
        IList<int> indexes1 = dict[word1];
        IList<int> indexes2 = dict[word2];
        // find min diff of two arrays, use merge idea from merge sort
        int result = int.MaxValue;
        for(int i = 0, j = 0; i < indexes1.Count && j < indexes2.Count; ){
            result = Math.Min(result, Math.Abs(indexes1[i] - indexes2[j]));
            if(indexes1[i] < indexes2[j]) i++;
            else j++;
        }
        return result;
    }
}

// Your WordDistance object will be instantiated and called as such:
// WordDistance wordDistance = new WordDistance(words);
// wordDistance.Shortest("word1", "word2");
// wordDistance.Shortest("anotherWord1", "anotherWord2");