package algo.elementary_ds_ch10;

/**
 * Created by Sharad on 9/27/2016.
 */
public class Node<T> {
    public Node<T> prev;
    public Node<T> next;
    public T key;

    public Node(T key, Node<T> prev, Node<T> next) {
        this.prev = prev;
        this.next = next;
        this.key = key;
    }
}
