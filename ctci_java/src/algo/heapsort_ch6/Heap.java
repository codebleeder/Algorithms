package algo.heapsort_ch6;

/**
 * Created by sharads on 8/11/2016.
 */
public class Heap {
    private int[] arr;
     int heap_length;

    public Heap () {
        arr = new int[10];
        heap_length = 10;
    }

    public Heap(int heap_length){
        arr = new int[heap_length];
        this.heap_length = heap_length;
    }
    public static int left(int i) {
        return i*2  + 1;
    }

    public static int right(int i) {
        return i*2 + 2;
    }

    public static int parent(int i) {
        return (int) Math.ceil((float)i/2 - 1.0);
    }

    // Assuming heap_length < A.length
    public static void maxHeapify(int[] A, int i, int heap_length) {
        int l = Heap.left(i);
        int r = Heap.right(i);
        int largest = i;

        if (l <= heap_length && A[l] > A[largest]) {
            largest = l;
        }
        else largest = i;
        if ( r <= heap_length && A[r] > A[largest]) {
            largest = r;
        }
        if (largest != i) {
            int temp = A[largest];
            A[largest] = A[i];
            A[i] = temp;
            maxHeapify(A, largest, heap_length);
        }

    }

    public static void heapSort(int[] A) {
        buildMaxHeap(A);
        int heapSize = A.length - 1;
        for (int i = A.length-1; i >= 1; i--) {
            int temp = A[0];
            A[0] = A[i];
            A[i] = temp;
            heapSize--;
            maxHeapify(A, 0, heapSize);
        }

    }

    public static void buildMaxHeap(int[] A) {
        int heapLength = A.length - 1;
        for (int i = (int) Math.floor(heapLength/2); i >=0; i--) {
            maxHeapify(A, i, heapLength);
        }
    }

    public static int heapMax(int[] A) {
        return A[0];
    }

    public static int extractMax(int[] A) {
        int heapSize = A.length-1;
        int max = A[0];
        A[0] = A[heapSize];
        heapSize--;
        maxHeapify(A, 0, heapSize);
        return max;
    }

    public static boolean increaseKey(int[] A, int i, int key) {
        if (A[i] > key) {
            System.out.println("key is provided is less than existing key");
            return false;
        }
        A[i] = key;
        while (A[i] > A[parent(i)] && i>0) {
            int temp = A[i];
            A[i] = A[parent(i)];
            A[parent(i)] = temp;
            i = parent(i);
        }
        return true;
    }

    public static boolean maxHeapInsert(int[] a, int key, int heapSize) {
        if (heapSize >= a.length) {
            System.out.println("heap size provided is greater than or equal to array length!");
            return false;
        }

        heapSize++;
        a[heapSize] = -1;
        return increaseKey(a, heapSize, key);
    }
}
