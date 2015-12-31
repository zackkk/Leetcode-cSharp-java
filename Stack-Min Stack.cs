Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

push(x) -- Push element x onto stack.
pop() -- Removes the element on top of the stack.
top() -- Get the top element.
getMin() -- Retrieve the minimum element in the stack.


public class MinStack {
    Stack<int> s1 = new Stack<int>();
    Stack<int> s2 = new Stack<int>();

    public void Push(int x) {
        s1.Push(x);
        if(s2.Count == 0 || x <= GetMin()) s2.Push(x);
    }

    public void Pop() {
        int a = s1.Pop();
        if(a == s2.Peek()) s2.Pop();
    }

    public int Top() {
        return s1.Peek();
    }

    public int GetMin() {
        return s2.Peek();
    }
}