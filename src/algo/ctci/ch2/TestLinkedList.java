package algo.ctci.ch2;

/**
 * Created by Sharad on 10/23/2016.
 */
public class TestLinkedList {
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
}
