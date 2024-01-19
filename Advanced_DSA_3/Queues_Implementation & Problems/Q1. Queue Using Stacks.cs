Problem Description
Implement a First In First Out (FIFO) queue using stacks only.
The implemented queue should support all the functions of a normal queue (push, peek, pop, and empty).
Implement the UserQueue class:

void push(int X) : Pushes element X to the back of the queue.
int pop() : Removes the element from the front of the queue and returns it.
int peek() : Returns the element at the front of the queue.
boolean empty() : Returns true if the queue is empty, false otherwise.
NOTES:

You must use only standard operations of a stack, which means only push to top, peek/pop from top, size, and is empty operations are valid.
Depending on your language, the stack may not be supported natively. You may simulate a stack using a list or deque (double-ended queue) as long as you use only a stack's standard operations.

//----------------------// O(1) //---------------------------//
public class UserQueue {

    Stack<int> st1 = new Stack<int>();
    Stack<int> st2 = new Stack<int>();
    
    /** Initialize your data structure here. */
    public UserQueue() {
        
    }

    /** Push element X to the back of queue. */
    public void Push(int X) {
        st1.Push(X);
    }

    /** Removes the element from in front of queue and returns that element. */
    public int Pop() {
        if(Empty()){
            return -1;
        }
        if(st2.Count == 0){
            move();
        }
        return st2.Pop();
    }

    /** Get the front element of the queue. */
    public int Peek() {
        if(Empty()){
            return -1;
        }
        if(st2.Count == 0){
            move();
        }
        return st2.Peek();
    }

    /** Returns whether the queue is empty. */
    public bool Empty() {
        return st1.Count == 0 && st2.Count == 0;
    }

    public void move(){
        while(st1.Count != 0){
            st2.Push(st1.Pop());
        }
    }
}

/**
 * Your UserQueue object will be instantiated and called as such:
 * UserQueue obj = new UserQueue();
 * obj.push(X);
 * int param2 = obj.pop();
 * int param3 = obj.peek();
 * boolean param4 = obj.empty();
 */