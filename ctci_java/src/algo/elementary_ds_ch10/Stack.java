package algo.elementary_ds_ch10;

/**
 * Created by sharads on 7/27/2016.
 */
public class Stack {

    private int top;
    private int[] arr;

    public Stack(){
        this.top = -1;
        this.arr = new int[10];
    }

    public boolean is_empty(){
        if (top == -1) return true;
        else return false;
    }

    public void push(int e){
        arr[top+1] = e;
        top++;
    }

    public int pop() throws IndexOutOfBoundsException{
            top--;
            return arr[top+1];
    }


}
