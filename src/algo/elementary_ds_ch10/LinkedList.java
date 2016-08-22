package algo.elementary_ds_ch10;

/**
 * Created by sharads on 8/3/2016.
 */
public class LinkedList {
    private ListObject head;

    public LinkedList() {
        this.head = new ListObject(-1, this.head, this.head);
        this.head.next = this.head;
        this.head.prev = this.head;
    }

    public void insert(ListObject x) {
        x.next = this.head.next;
        this.head.next.prev = x;
        this.head.next = x;
        x.prev = this.head;
    }

    public ListObject search(int key) {
        ListObject x = this.head.next;
        while (x != this.head && x.key != key) {
            x = x.next;
        }
        return x;
    }

    public void delete(ListObject x) {
        x.next.prev = x.prev;
        x.prev.next = x.next;

    }
}
