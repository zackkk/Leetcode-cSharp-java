Given an absolute path for a file (Unix-style), simplify it.

For example,
path = "/home/", => "/home"
path = "/a/./b/../../c/", => "/c"


public class Solution {
    // stack
    public string SimplifyPath(string path) {
        Stack<string> stack = new Stack<string>();
        foreach(string token in path.Split('/')){
            if(token == "" || token == ".") continue;
            if(token == ".." && stack.Count > 0) stack.Pop();
            else if(token != "..") stack.Push(token);
        }
        StringBuilder sb = new StringBuilder();
        while(stack.Count > 0) sb.Insert(0, "/" + stack.Pop());
        return sb.Length > 0 ? sb.ToString() : "/";
    }
}