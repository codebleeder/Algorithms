package algo.elementary_ds_ch10;
import java.lang.Math;

/**
 * Created by sharads on 8/3/2016.
 */
public class Queue {
    private int[] arr;
    private int head;
    private int tail;
    private int length;

    public Queue(){
        arr = new int[10];
        length = 0;
        tail = 0;
        head = 0;
    }

    public void enqueue(int item) {

        if (length++ > arr.length) System.out.println("Queue overflow");
        else {
            arr[tail] = item;
            if (tail == arr.length-1) {
                tail = 0;
            }
            else tail++;
            length++;
        }
    }

    public int dequeue() {
        int x = 0;
        if (length == 0) System.out.println("Queue underflow!");
        else {
            x = arr[head];
            if (head == arr.length - 1) head = 0;
            else head++;
            length--;
        }
        return x;
    }

    public boolean isEmpty(){
        return this.length == 0;

    }
}
