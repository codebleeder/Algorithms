package algo.ctci.ch2;
import java.util.HashSet;

/**
 * Created by Sharad on 10/23/2016.
 */
public class Ch2 {
    public void removeDups1(Node head){
        HashSet<Integer> set = new HashSet<>();
        Node n = head;
        Node prev = null;

        while (n != null){
            if (set.contains(n.data)) {
                prev.next = n.next;

            }
            else {
                set.add(n.data);
                prev = n;
            }
            n = n.next;
        }
    }

    public void removeDups1b(Node n){
        while (n != null) {
            Node runner = n.next;
            Node prev = n;
            while (runner != null){
                if (runner.data == n.data) {
                    prev.next = runner.next;
                    runner = runner.next;
                    //runner = runner.next.next;
                }
                else {
                    prev = runner;
                    runner = runner.next;
                }
            }
            n = n.next;
        }
    }

    public Node returnKthToLast2(Node n, int k) {
        Node kth = null;
        Node x = n;
        int count = 1;
        while (x != null) {
            if (count == k) {
                kth = n;
            }
            else if (count > k) {
                kth = kth.next;
            }
            x = x.next;
            count++;
        }
        return kth;
    }

    public boolean deleteMiddleNode3(Node n) {
        if (n == null || n.next == null) return false;
        n.data = n.next.data;
        n.next = n.next.next;
        return true;
    }

    public LinkedList partition4(int x, Node head) {
        Node i = head;
        LinkedList oLesser = new LinkedList();
        LinkedList oHigher = new LinkedList();



        while (i != null) {
            if (i.data >= x) oHigher.insert(i.data);
            else oLesser.insert(i.data);
            i = i.next;
        }
        Node nLesserX = oLesser.head;
        Node nLesserY = new Node();

        while(nLesserX != null) {
            nLesserY = nLesserX;
            nLesserX = nLesserX.next;
        }

        nLesserY.next = oHigher.head;
        return oLesser;
    }

    public LinkedList sumLists5(LinkedList oList1, LinkedList oList2) {
        int carry = 0;
        int digit = 0;
        LinkedList oListOut = new LinkedList();

        Node oNode1 = oList1.head;
        Node oNode2 = oList2.head;
        while (oNode1 != null) {
            digit = oNode1.data + oNode2.data + carry;
            if (digit > 10) {
                carry = 1;
                digit = digit % 10;
            }
            else carry = 0;
            oListOut.insertNode(digit);
            oNode1 = oNode1.next;
            oNode2 = oNode2.next;
        }
        return oListOut;
    }
}
