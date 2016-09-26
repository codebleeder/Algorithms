package algo.elementary_ds_ch10;

/**
 * Created by sharads on 9/26/2016.
 */
public class ListObject2 {
    public KeyValue key;
    public ListObject2 next;
    public ListObject2 prev;


    public ListObject2(KeyValue key, ListObject2 next, ListObject2 prev) {
        this.key = key;
        this.next = next;
        this.prev = prev;
    }

    public ListObject2(KeyValue key){
        this.key = key;
        this.next = null;
        this.prev = null;
    }
}
