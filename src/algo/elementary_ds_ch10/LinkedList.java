package algo.elementary_ds_ch10;

/**
 * Created by sharads on 8/3/2016.
 */
public class LinkedList<T> {
    public Node<T> head;

    public LinkedList(T headElement) {
        head = new Node<T>(headElement, null, null);
        head.next = this.head;
        head.prev = this.head;
    }

    public LinkedList() {
        this(null);
    }

    public void insert(T x) {
        Node<T> n = new Node(x, this.head, this.head);

        n.next = this.head.next;
        this.head.next.prev = n;
        this.head.next = n;
        n.prev = this.head;
    }

    public Node<T> search(T key) {
        Node<T> here = this.head.next;
        while(here != this.head && here.key != key) {
            here = here.next;
        }
        return here;
    }

    public void delete(Node<T> x) {
        x.next.prev = x.prev;
        x.prev.next = x.next;
    }
}
