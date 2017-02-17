package algo.ctci.ch3;

import java.util.EmptyStackException;

/**
 * Created by sharads on 2/11/2017.
 */
public class Stack<T> {
    private class StackNode<T>{
        private T data;
        private StackNode<T> next;

        public StackNode(T data){
            this.data = data;
        }
    }

    private StackNode<T> top;

    public T pop(){
        if (top == null) throw new EmptyStackException();
        else {
            T item = top.data;
            top = top.next;
            return item;
        }
    }

    public void push(T item){
        StackNode<T> s = new StackNode<T>(item);
        s.next = top;
        top = s;
    }

    public T peek(){
        if (top == null) throw new EmptyStackException();
        return top.data;
    }

    public boolean isEmpty(){
        return top == null;
    }
}
