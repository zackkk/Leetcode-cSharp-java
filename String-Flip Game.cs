You are playing the following Flip Game with your friend: 
Given a string that contains only these two characters: + and -, 
you and your friend take turns to flip two consecutive "++" into "--". 
The game ends when a person can no longer make a move and therefore the other person will be the winner.

Write a function to compute all possible states of the string after one valid move.

For example, given s = "++++", after one move, it may become one of the following states:

[
  "--++",
  "+--+",
  "++--"
]
If there is no valid move, return an empty list [].


public class Solution {
    // can only flip "++" to "--"
    public IList<string> GeneratePossibleNextMoves(string s) {
        IList<string> result = new List<string>();
        for (int i = 0; i < s.Length - 1; i++) {
            if (s[i] == '+' && s[i+1] == '+') {
                result.Add(s.Substring(0, i) + "--" + s.Substring(i + 2, s.Length - i - 2));
            }
        }
        return result;
    }
}