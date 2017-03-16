package algo.ctci.ch3;

/**
 * Created by sharads on 1/17/2017.
 */
public class TestCh3 {
    Ch3 ch3;
    public TestCh3(){
        ch3 = new Ch3();
    }
    public boolean testFixedMultiStack(){
        Ch3.FixedMultiStack x = ch3.new FixedMultiStack(3);
        boolean bStackOverflow = false;
        boolean bPop = true;
        boolean bPeek = true;

        x.push(0, 1);
        x.push(0, 2);
        x.push(0, 3);

        try {
            x.push(0, 4);
        } catch (Exception ex){
            bStackOverflow = true;
        } finally {

        }

        for(int i=3; i>0; i--){
            if (i != x.peek(0)) bPeek = false;
            if (i != x.pop(0)) bPop = false;
        }

        return bPeek && bPop && bStackOverflow;
    }
}
