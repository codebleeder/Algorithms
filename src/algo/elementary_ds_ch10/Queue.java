package algo.elementary_ds_ch10;
import java.lang.Math;

/**
 * Created by sharads on 8/3/2016.
 */
public class Queue {
    private int[] arr;
    private int head;
    private int tail;

    public Queue(){
        arr = new int[10];
    }

    public void enqueue(int item) {
        arr[tail] = item;
        if (tail == arr.length-1) {
            tail = 0;
        }
        else tail++;
    }

    public int dequeue() {
        int x = arr[head];
        if (head == arr.length-1) head = 0;
        else head++;
        return x;
    }

    public boolean isEmpty(){
        return arr.length == 0;

    }
}
