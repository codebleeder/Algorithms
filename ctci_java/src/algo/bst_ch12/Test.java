package algo.bst_ch12;

/**
 * Created by sharads on 8/20/2016.
 */
public class Test {
    public static boolean testNode(){
        Node x = new Node(9);
        x.left = new Node(x, null, null, 8);
        x.right = new Node (x, null, null, 11);
        return (x.parent == null && x.left.key == 8 && x.right.key == 11 && x.key == 9);
    }

    public static boolean testTreeInstance() {
        Tree t = new Tree(new Node(3));
        Tree t2 = new Tree(3);
        boolean flag1 =  (t.root.key == 3 && t.root.parent == null && t.root.left == null && t.root.right == null);
        boolean flag2 = (t2.root.key == 3 && t2.root.parent == null && t2.root.left == null && t2.root.right == null);
        return flag1 && flag2;
    }

    public static boolean testTreeInsert(){
        Tree t = new Tree(null);
        t.treeInsert(3);
        boolean rootCheckFlag = (t.root.key == 3);
        t.treeInsert(4);
        t.treeInsert(2);
        boolean leftRightCheckFlag = (t.root.right.key == 4 && t.root.left.key == 2);
        return rootCheckFlag && leftRightCheckFlag;
    }

    public static void testInorderTreeWalk(){
        int[] a = {6, 5, 7, 2, 5, 8};
        Tree t = Util.buildTreeFromArr(a);
        t.inorderTreeWalk(t.root);

    }

    public static boolean testIterativeTreeSearch(){
        int[] a = {6, 5, 7, 2, 5, 8};
        Tree t = Util.buildTreeFromArr(a);
        Node x = t.iterativeTreeSearch(t.root, 7);
        boolean f1 = (x.right.key == 8 && x.parent.key == 6 && x.key == 7);
        Node y = t.iterativeTreeSearch(t.root, 2);
        boolean f2 = (y.parent.key == 5 && y.key == 2);
        Node z = t.iterativeTreeSearch(t.root, 10);
        boolean f3 = (z == null);
        return f1 && f2 && f3;
    }

    public static boolean testTreeMinMax(){
        int [] a = {6, 5, 7, 2, 5, 8};
        Tree t = Util.buildTreeFromArr(a);
        boolean f1 = (t.treeMax(t.root).key == 8);
        boolean f2 = (t.treeMin(t.root).key == 2);
        return  f1 && f2;
    }

    public static void testTransplant(){
        int [] a = {6, 5, 7, 2, 5, 8};
        Tree t = Util.buildTreeFromArr(a);
        Node u = t.iterativeTreeSearch(t.root, 5);
        Node v = new Node(9);
        System.out.println("Before transplant: ");
        t.inorderTreeWalk(t.root);
        t.transplant(u, v);
        System.out.println("After transplant: ");
        t.inorderTreeWalk(t.root);
    }

    public static boolean testDelete(){
        int [] a1 = {5, 4};
        Tree t1 = Util.buildTreeFromArr(a1);
        t1.delete(t1.root);
        boolean f1 = (t1.root.key == 4);
        if (f1 == true) System.out.println("case 1: clear!");

        int [] a2 = {5, 6};
        Tree t2 = Util.buildTreeFromArr(a2);
        t2.delete(t2.root);
        boolean f2 = (t2.root.key == 6);
        if (f2 == true) System.out.println("case 2: clear!");

        int [] a3 = {5, 1, 20, 15, 30, 17};
        Tree t3 = Util.buildTreeFromArr(a3);
        System.out.println("Before delete: ");
        t3.inorderTreeWalk(t3.root);
        t3.delete(t3.iterativeTreeSearch(t3.root, 5));
        System.out.println("After delete: ");
        t3.inorderTreeWalk(t3.root);
        boolean f3 = (t3.root.key == 15 && t3.root.left.key == 1 && t3.root.right.key == 20);
        return f1 && f2 && f3;
    }

    public static void testCases(String name){
        switch(name) {
            case "testNode":
                if (testNode() == true) System.out.println("Test Node clear!");
                else System.out.println("Test Node Fail!");
                break;

            case "testTreeInstance":
                if (testTreeInstance() == true) System.out.println("Test Tree Instance clear!");
                else System.out.println("Test Tree Instance Fail!");
                break;

            case "testTreeInsert":
                if (testTreeInsert() == true) System.out.println("Test Tree Insert clear!");
                else System.out.println("Test Tree Insert Fail!");
                break;

            case "testInorderTreeWalk":
                testInorderTreeWalk();
                break;

            case "testIterativeTreeSearch":
                if (testIterativeTreeSearch() == true) System.out.println("Test Tree Search clear!");
                else System.out.println("Test Tree Search Fail!");
                break;

            case "testTreeMinMax":
                if (testTreeMinMax() == true) System.out.println("Test Tree Min and Max clear!");
                else System.out.println("Test Tree Min and Max Fail!");
                break;

            case "testTransplant":
                testTransplant();

            case "testDelete":
                if (testDelete() == true) System.out.println("Test Delete clear!");
                else System.out.println("Test Delete Fail!");
                break;
        }
    }
}
