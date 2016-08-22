package algo.bst_ch12;

/**
 * Created by sharads on 8/20/2016.
 */
public class Util {
    public static Tree buildTreeFromArr(int[] a){
        // assume first element is root
        Tree t = new Tree(a[0]);
        for (int i = 1; i < a.length; i++) {
            t.treeInsert(a[i]);
        }
        return t;
    }
}
