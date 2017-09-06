package algo.heapsort_ch6;

import java.util.Arrays;

/**
 * Created by sharads on 8/11/2016.
 */
public class Test {
    public static boolean test_index(Heap h) {
        if (h.left(2) != 4) return false;
        if (h.right(2) != 5) return false;
        if (h.parent(7) != 3) return false;
        return true;
    }

    public static boolean testMaxHeapify(){
        int[] A = {16, 4, 10, 14, 7, 9, 3, 2, 8, 1};
        int heap_length = 9;
        Heap.maxHeapify(A, 1, heap_length);
        System.out.println(A);
        return (A[1] == 14 && A[3] == 8 && A[7] == 2 && A[8]==4);
    }

    public static void testBuildMaxHeap() {
        int [] A = {4, 1, 3, 2, 16, 9, 10, 14, 8, 7};
        Heap.buildMaxHeap(A);
        System.out.println(Arrays.toString(A));
    }

    public static boolean testHeapSort() {
        int [] A = {2, 4, 8, 14, 16, 1, 7, 10, 9, 3};
        Heap.heapSort(A);
        int [] A_sorted = {1, 2, 3, 4, 7, 8, 9, 10, 14, 16};
        boolean testResult = true;
        for (int i=0; i < A.length; i++){
            if (A[i] != A_sorted[i]) testResult = false;
        }
        return testResult;
    }

    public static boolean testExtractMax(){
        int [] a = {2, 4, 8, 14, 16, 1, 7, 10, 9, 3};
        Heap.buildMaxHeap(a);
        System.out.println("max heap: ");
        System.out.println(Arrays.toString(a));
        int [] aAfterExtract = {14, 10, 8, 9, 4, 1, 7, 2, 3};
        boolean maxCorrect = false;
        boolean equalToAfterExtract = true;

        if (Heap.extractMax(a) == 16) maxCorrect = true;
        for (int i=0; i < aAfterExtract.length; i++){
            if (a[i] != aAfterExtract[i]) equalToAfterExtract = false;
        }
        System.out.println("After extraction: ");
        System.out.println(Arrays.toString(a));
        return maxCorrect && equalToAfterExtract;
    }

    private static boolean compareArrays(int[] a, int[] b, int length){
        if (length > a.length) {
            System.out.println("length is greater than first array!");
            return false;
        }
        boolean equalFlag = true;
        for (int i=0; i<length; i++){
            if (a[i] != b[i]) equalFlag = false;
        }
        return equalFlag;
    }

    private static void printArray(String message, int[] a){
        System.out.println(message);
        System.out.println(Arrays.toString(a));
    }

    public static boolean testIncreaseKey() {
        int[] a = {16, 14, 10, 8, 7, 9, 3, 2, 4, 1};
        boolean wrongKeyFlag = false;
        int [] aAfterIncreaseKey = {16, 15, 10, 14, 7, 9, 3, 2, 8, 1};

        if (Heap.increaseKey(a, 0, 10) == false) wrongKeyFlag = true;
        printArray("original heap:", a);
        Heap.increaseKey(a, 8, 15);
        printArray("after increase key: ", a);
        boolean correctKeyFlag = compareArrays(a, aAfterIncreaseKey, a.length);
        return correctKeyFlag && wrongKeyFlag;
    }

    public static boolean testInsertKey(){
        int [] a = {16, 14, 10, 8, 7, 9, 3, 2, 4, 1};
        int [] b = new int[11];
        System.arraycopy(a, 0, b, 0, a.length);
        int [] expected = {16, 14, 10, 8, 12, 9, 3, 2, 4, 1, 7};
        boolean invalidHeapSizeFlag = false;
        if (Heap.maxHeapInsert(b, 12, b.length) == false) invalidHeapSizeFlag = true;
        printArray("Before insert: ", b);
        Heap.maxHeapInsert(b, 12, 9);
        printArray("After insert: ", b);
        printArray("expected: ", expected);
        return compareArrays(b, expected, 11) && invalidHeapSizeFlag;
    }
}
