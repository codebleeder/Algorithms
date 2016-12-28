package algo.ctci.ch2;


import java.util.Arrays;

/**
 * Created by Sharad on 10/23/2016.
 */
public class TestUtil {
    public boolean testBuildLinkedList(){
        Util u = new Util();
        Integer[] arr = new Integer[]{10, 1, 2, 3, 4};
        LinkedList l = u.buildLinkedList(arr);

        System.out.println("input array: " + Arrays.toString(arr));
        u.printLinkedList(l);

        Node n = l.head;
        int i=0;
        while (n != null){
            if (n.data != arr[i]) return false;
            n = n.next;
            i++;
        }
        return true;
    }

}
