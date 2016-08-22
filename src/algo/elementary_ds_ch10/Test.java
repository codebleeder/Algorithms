package algo.elementary_ds_ch10;

/**
 * Created by sharads on 8/3/2016.
 */
public class Test {
    public static boolean testQueue(){
        Queue q = new Queue();
        q.enqueue(1);
        int x = q.dequeue(); // 1
        if (x != 1) return false;
        q.enqueue(2);
        q.enqueue(3);
        for (int i = 0; i < 2; i++) {
            if (q.dequeue() != i + 2) return false;
        }
        return true;

    }

    public static void testStack(){
        Stack s = new Stack();
        s.push(1);
        s.push(2);
        s.push(3);
        for (int i=0; i < 4; i++) {
            System.out.println(s.pop());
        }
    }

    public static void testLinkedList() {
        LinkedList l = new LinkedList();
        ListObject lo = new ListObject(1);
        l.insert(lo);
        l.insert(new ListObject(2));
        l.insert(new ListObject(3));
        l.insert(new ListObject(4));

        ListObject lo2 = l.search(3);
        l.delete(lo2);
    }
}
