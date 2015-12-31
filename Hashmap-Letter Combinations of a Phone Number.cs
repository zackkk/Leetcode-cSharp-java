Given a digit string, return all possible letter combinations that the number could represent.

A mapping of digit to letters (just like on the telephone buttons) is given below.

Input:Digit string "23"
Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].


public class Solution {
    public IList<string> LetterCombinations(string digits) {
        Dictionary<char, string> dict = new Dictionary<char, string>();
        dict['0'] = "";
        dict['1'] = "";
        dict['2'] = "abc";
        dict['3'] = "def";
        dict['4'] = "ghi";
        dict['5'] = "jkl";
        dict['6'] = "mno";
        dict['7'] = "pqrs";
        dict['8'] = "tuv";
        dict['9'] = "wxyz";
        IList<string> result = new List<string>(){};
        for(int i = 0; i < digits.Length; i++){
            string letters = dict[digits[i]];
            IList<string> tmp = new List<string>();
            for(int j = 0; j < letters.Length; j++){
                if(result.Count == 0){
                    tmp.Add(letters[j].ToString());
                }
                else{
                    foreach(string str in result){
                        tmp.Add(str + letters[j]);
                    }
                }
            }
            result = tmp;
        }
        return result;
    }
}