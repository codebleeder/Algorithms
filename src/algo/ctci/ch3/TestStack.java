package algo.ctci.ch3;

/**
 * Created by sharads on 2/21/2017.
 */
public class TestStack {
    public boolean testStack(){
        Stack<Integer> stack = new Stack<>();
        stack.push(1);
        stack.push(2);
        stack.push(3);
        if (stack.peek() != 3) {
            System.out.println("test fail: peek()");
            return false;
        }

        if (stack.pop() != 3){
            System.out.println("test fail: pop()");
            return false;
        }

        if (stack.isEmpty() == true){
            System.out.println("test fail: isEmpty()");
            return false;
        }

        stack.pop();
        stack.pop();
        if (stack.isEmpty() == false){
            System.out.println("test fail: isEmpty()");
            return false;
        }
        System.out.println("stack test pass");
        return true;
    }
}
