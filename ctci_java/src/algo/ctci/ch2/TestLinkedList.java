package algo.ctci.ch2;

/**
 * Created by Sharad on 10/23/2016.
 */
public class TestLinkedList {
    private Util u = new Util();

    public boolean testInsert(){
        LinkedList l = new LinkedList();
        l.insert(0);
        l.insert(1);
        Node n = l.head;
        for (int i=0; i<2; i++){
            if (n.data != i){
                return false;
            }
            n = n.next;
        }
        return true;
    }

    public boolean testDelete(){
        LinkedList l = new LinkedList();
        l.insert(0);
        l.insert(1);
        l.insert(2);
        Node n = l.deleteNode(1);
        return (n.data == 0 && n.next.data == 2);
    }

    public void testCloneL(){
        LinkedList l = new LinkedList();
        l = u.buildLinkedList(new Integer[] {1, 2, 3, 4});
        LinkedList l2 = l.cloneL();
        u.printLinkedList(l);
        u.printLinkedList(l2);
    }

    public void testGetNode(){
        LinkedList test = new LinkedList();
        test = u.buildLinkedList(new Integer[]{1, 2, 3, 4, 5});
        Node x = test.getNode(2);
        System.out.println("node = " + x.data);
        if (x.data == 3) System.out.println("pass!");
        else System.out.println("fail!");
    }

    public void testGetLength(){
        LinkedList test = new LinkedList();
        test = u.buildLinkedList(new Integer[]{1, 2, 3, 4, 5});
        if (test.getLength() == 5) System.out.println("pass");
        else System.out.println("fail!");
    }
}
