package algo.elementary_ds_ch10;

/**
 * Created by sharads on 8/3/2016.
 */
public class ListObject {
    public int key;
    public ListObject next;
    public ListObject prev;

    public ListObject(int key, ListObject next, ListObject prev) {
        this.key = -1;
        this.next = next;
        this.prev = prev;
    }

    public ListObject(int key){
        this.key = key;
        this.next = null;
        this.prev = null;
    }
}
