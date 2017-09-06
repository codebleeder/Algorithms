package algo.elementary_ds_ch10;

/**
 * Created by sharads on 9/26/2016.
 */
public class LinkedList2 {
    private ListObject2 head;

    public LinkedList2() {
        KeyValue kv = new KeyValue("", "");
        this.head = new ListObject2(kv);
        this.head.next = this.head;
        this.head.prev = this.head;
    }

    public LinkedList2(KeyValue headElement) {
        this.head = new ListObject2(headElement, this.head, this.head);
        this.head.next = this.head;
        this.head.prev = this.head;
    }

    public void insert(ListObject2 x) {
        x.next = this.head.next;
        this.head.next.prev = x;
        this.head.next = x;
        x.prev = this.head;
    }

    public ListObject2 search(String key) {
        ListObject2 x = this.head.next;
        while (x != this.head && x.key.key != (key)) {
            x = x.next;
        }
        return x;
    }

    public void delete(ListObject2 x) {
        x.next.prev = x.prev;
        x.prev.next = x.next;

    }
}


