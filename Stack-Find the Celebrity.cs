Suppose you are at a party with n people (labeled from 0 to n - 1) and among them, there may exist one celebrity. 
The definition of a celebrity is that all the other n - 1 people know him/her but he/she does not know any of them.

Now you want to find out who the celebrity is or verify that there is not one. 
The only thing you are allowed to do is to ask questions like: "Hi, A. Do you know B?" to get information of whether A knows B. You need to find out the celebrity (or verify there is not one) by asking as few questions as possible (in the asymptotic sense).

You are given a helper function bool knows(a, b) which tells you whether A knows B. 
Implement a function int findCelebrity(n), your function should minimize the number of calls to knows.

Note: There will be exactly one celebrity if he/she is in the party. 
Return the celebritys label if there is a celebrity in the party. If there is no celebrity, return -1.


/* The Knows API is defined in the parent class Relation.
      bool Knows(int a, int b); */

public class Solution : Relation {
    // stack
    // celebrity knows no one, but all other people know him
    public int FindCelebrity(int n) {
        Stack<int> stack = new Stack<int>();
        for(int i = 0; i < n; i++) stack.Push(i);
        while(stack.Count > 1){ // eliminate non-celebrity
            int a = stack.Pop(), b = stack.Pop();
            if(Knows(a, b)){  // a knows b, eliminate a
                stack.Push(b);
            }
            else{  // a doesn't know b, eliminate b
                stack.Push(a);
            }
        }
        int c = stack.Pop(); // candidate
        for(int i = 0; i < n; i++){
            if(i != c && (Knows(c, i) || !Knows(i, c))) return -1; // shouldn't know anyone and all others should know him
        }
        return c;
    }
}