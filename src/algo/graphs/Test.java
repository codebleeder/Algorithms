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

    public static void testBFS(){
        int[][] map = {
                {1, 4},
                {0, 5},
                {5, 6, 3},
                {2, 6, 7},
                {0},
                {1, 2, 6},
                {5, 2, 3, 7},
                {3, 6}
        };

        Graph g = new Graph(map);
        BreadFirstSearch.bfs(g, g.nodes[1]);
        Util.printPath(g, g.nodes[1], g.nodes[7]);
    }

    public static void graphTests(String testCase){
        switch (testCase){
            case "testGraphPrint":
                    testGraphPrint();
                    break;
            case "testBFS":
                    testBFS();
                    break;
        }
    }
}
