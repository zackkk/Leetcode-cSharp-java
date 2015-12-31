Given two words (beginWord and endWord), and a dictionarys word list, 
find the length of shortest transformation sequence from beginWord to endWord, 

such that:
-Only one letter can be changed at a time
-Each intermediate word must exist in the word list

For example,

Given:
beginWord = "hit"
endWord = "cog"
wordList = ["hot","dot","dog","lot","log"]

As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog", return its length 5.

Note:
Return 0 if there is no such transformation sequence.
All words have the same length.
All words contain only lowercase alphabetic characters.


public class Solution {
    // bfs, when tranformation, 
    // change each character in the word would be faster than comparing all words in set wordList (big size)
    public int LadderLength(string beginWord, string endWord, ISet<string> wordList) {
        Queue<string> queue = new Queue<string>();
        queue.Enqueue(beginWord);
        HashSet<string> visited = new HashSet<string>();
        visited.Add(beginWord); // avoid duplicates
        int level = 1;

        while (queue.Count > 0){
            int curLevelNum = queue.Count;
            for (int i = 0; i < curLevelNum; i++){
                string curWord = queue.Dequeue();              

                // look for next level 
                for (int j = 0; j < curWord.Length; j++){
                    StringBuilder testWordBuilder = new StringBuilder(curWord); // try all letters on all positions
                    for (char c = 'a'; c <= 'z'; c++){
                        testWordBuilder[j] = c;
                        string testWord = testWordBuilder.ToString();
                        if (testWord == endWord) return level + 1;
                        if (!visited.Contains(testWord) && wordList.Contains(testWord)){
                            visited.Add(testWord);
                            queue.Enqueue(testWord);
                        }
                    }
                }
            }
            level++;
        }
        return 0; // didn't get to the endWord
    }
}