package algo.graphs;

/**
 * Created by sharads on 8/26/2016.
 */
public class Test {
    public static void testGraphPrint(){
        int[][] map = {{1},
                {2},
                {0, 3},
                {2}};

        Graph g = new Graph(map);
        Util.printGraph(g);
    }

    public static void graphTests(String testCase){
        switch (testCase){
            case "testGraphPrint":
                    testGraphPrint();
                    break;
        }
    }
}
