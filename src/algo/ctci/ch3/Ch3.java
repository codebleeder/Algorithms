package algo.ctci.ch3;

import java.util.EmptyStackException;

/**
 * Created by sharads on 1/17/2017.
 */
public class Ch3 {


    public class FixedMultiStack {
        private int numberOfStacks = 3;
        private int stackCapacity;
        private int[] values;
        private int[] sizes;

        public FixedMultiStack(int stackSize){
            values = new int[stackSize * numberOfStacks];
            sizes = new int[numberOfStacks];
            stackCapacity = stackSize;
        }
        public void push(int stackNum, int value) throws StackOverflowError {
            if (isFull(stackNum)) throw new StackOverflowError();
            sizes[stackNum]++;
            values[indexOfTop(stackNum)] = value;
        }

        public boolean isFull(int stackNum) {
            return sizes[stackNum] == stackCapacity;
        }

        private int indexOfTop(int stackNum){
            int offset = stackNum * stackCapacity;
            int size = sizes[stackNum];
            return offset + size - 1;
        }

        public int pop(int stackNum) throws EmptyStackException{
            if (isEmpty(stackNum)) throw new EmptyStackException();
            int value = values[indexOfTop(stackNum)];
            sizes[stackNum]--;
            return value;
        }

        public boolean isEmpty(int stackNum){
            return sizes[stackNum] == 0;
        }

        public int peek(int stackNum){
            if (isEmpty(stackNum)) throw new EmptyStackException();
            return values[indexOfTop(stackNum)];
        }
    }
}
