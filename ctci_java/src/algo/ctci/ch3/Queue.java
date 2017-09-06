package algo.ctci.ch3;

import java.util.EmptyStackException;

/**
 * Created by sharads on 2/28/2017.
 */
public class Queue<T> {
    private class Node<T>{
        private T data;
        private Node<T> next;

        public Node(T data){
            this.data = data;
        }
    }
    private Node<T> first;
    private Node<T> last;

    public void add(T item){
        Node<T> x = new Node(item);
        if (last == null) {
            last = x;
            first = x;
        }
        else {
            last.next = x;
            last = x;
        }
    }

    public T remove(){
        Node<T> x = first;
        first = x.next;
        return x.data;
    }

    public T peek(){
        if (first == null) throw new EmptyStackException();
        return first.data;
    }

    public boolean isEmpty(){
        return first == null;
    }
}
