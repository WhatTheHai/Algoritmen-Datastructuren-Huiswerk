using NUnit.Framework;
using System.Text.RegularExpressions;

namespace AD
{
    public partial class RegioGraafTests
    {
        private IGraph BuildGraph_FromExercise()
        {
            Graph graph = new Graph();
            graph.AddVertex("A", "Q");
            graph.AddVertex("B", "R");
            graph.AddVertex("C", "R");
            graph.AddVertex("D", "R");
            graph.AddVertex("E", "R");
            graph.AddVertex("F", "S");
            graph.AddVertex("G", "R");

            graph.AddUndirectedEdge("A", "B", 2);
            graph.AddUndirectedEdge("A", "C", 3);
            graph.AddUndirectedEdge("A", "G", 4);

            graph.AddUndirectedEdge("B", "C", 8);
            graph.AddUndirectedEdge("B", "D", 10);
            graph.AddUndirectedEdge("B", "F", 3);

            graph.AddUndirectedEdge("C", "E", 5);

            graph.AddUndirectedEdge("D", "E", 2);
            graph.AddUndirectedEdge("D", "F", 4);
            return graph;
        }

        private IGraph BuildGraphOther()
        {
            Graph graph = new Graph();
            graph.AddVertex("A", "P");
            graph.AddVertex("B", "Q");
            graph.AddVertex("C", "Q");
            graph.AddVertex("D", "Q");
            graph.AddVertex("E", "R");
            graph.AddVertex("F", "R");

            graph.AddUndirectedEdge("A", "B", 1);
            graph.AddUndirectedEdge("A", "C", 5);

            graph.AddUndirectedEdge("B", "C", 2);
            graph.AddUndirectedEdge("B", "E", 4);

            graph.AddUndirectedEdge("C", "D", 6);
            graph.AddUndirectedEdge("C", "E", 1);

            graph.AddUndirectedEdge("D", "F", 2);

            graph.AddUndirectedEdge("E", "F", 2);
            return graph;
        }

        [Test]
        public void RegioGraaf_a_TestAllPaths_OnEmptyGraph() //<---- not for students
        {
            // Arrange
            IGraph graph = DSBuilder.CreateGraphEmpty();
            string expected = "";

            // Act
            string actual = TestUtils.TrimmedStringWithoutSpaces(graph.AllPaths());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RegioGraaf_a_TestAllPaths_OnGraph14_1()
        {
            // Arrange
            IGraph graph = DSBuilder.CreateGraphFromBook14_1();
            string expected = "V0;V1;V3;V4;V2;V5;V6;";

            // Act
            string actual = TestUtils.TrimmedStringWithoutSpaces(graph.AllPaths());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RegioGraaf_a_TestAllPaths_OnGraph14_1_AfterDijkstra()
        {
            // Arrange
            IGraph graph = DSBuilder.CreateGraphFromBook14_1();
            graph.RegioDijkstra("V0");

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // NOTE: Since there are no regions, we expect
            // this test to succeed also on when
            // Dijkstra is changed for RegioGraaf!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            var expected = TestUtils.TrimmedStringWithoutSpaces(
                "V0; V1<-V0; V3<-V0; V4<-V3<-V0; " +
                "V2<-V3<-V0; " +
                "V5<-V6<-V3<-V0;" +
                "V6<-V3<-V0;");

            // Act
            string actual = TestUtils.TrimmedStringWithoutSpaces(graph.AllPaths());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RegioGraaf_b_AddVertex_1_OneAdded()
        {
            // Arrange
            IGraph graph = DSBuilder.CreateGraphEmpty();
            var expected = "Q";

            // Act
            graph.AddVertex("A", "Q");
            string actual = graph.GetVertex("A").GetRegio();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RegioGraaf_b_AddVertex_2_TwoAdded()
        {
            // Arrange
            IGraph graph = DSBuilder.CreateGraphEmpty();
            var expected1 = "Q";
            var expected2 = "S";

            // Act
            graph.AddVertex("A", "Q");
            graph.AddVertex("F", "S");
            string actual1 = graph.GetVertex("A").GetRegio();
            string actual2 = graph.GetVertex("F").GetRegio();

            // Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [Test]
        public void RegioGraaf_c_AddUndirectedEdge_1_OneAdded()
        {
            // Arrange
            IGraph graph = DSBuilder.CreateGraphEmpty();
            var expected = TestUtils.TrimmedStringWithoutSpaces(
                "A [ X(2000) ] X [ A(2000) ]");
            graph.GetVertex("A");
            graph.GetVertex("X");

            // Act
            graph.AddUndirectedEdge("A", "X", 2000);
            string actual = TestUtils.TrimmedStringWithoutSpaces(graph.ToString());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RegioGraaf_c_AddUndirectedEdge_2_MoreAdded()
        {
            // Arrange
            IGraph graph = DSBuilder.CreateGraphEmpty();
            var expected = TestUtils.TrimmedStringWithoutSpaces(
                "A [ B(20) ] " +
                "B [ A(20) C(30) D(40) ] " +
                "C [ B(30) D(50) ] " +
                "D [ B(40) C(50) ] ");
            graph.GetVertex("A");
            graph.GetVertex("B");
            graph.GetVertex("C");
            graph.GetVertex("D");

            // Act
            graph.AddUndirectedEdge("A", "B", 20);
            graph.AddUndirectedEdge("B", "C", 30);
            graph.AddUndirectedEdge("B", "D", 40);
            graph.AddUndirectedEdge("C", "D", 50);
            string actual = TestUtils.TrimmedStringWithoutSpaces(graph.ToString());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RegioGraaf_c_AddUndirectedEdge_3_DirectedAndUndirected()
        {
            // Arrange
            IGraph graph = DSBuilder.CreateGraphEmpty();
            var expected = TestUtils.TrimmedStringWithoutSpaces(
                "A [ B(20) ] " +
                "B [ A(20) C(30) D(40) ] " +
                "C [ B(30) D(50) ] " +
                "D [ B(40) ] ");
            graph.GetVertex("A");
            graph.GetVertex("B");
            graph.GetVertex("C");
            graph.GetVertex("D");

            // Act
            graph.AddUndirectedEdge("A", "B", 20);
            graph.AddUndirectedEdge("B", "C", 30);
            graph.AddUndirectedEdge("B", "D", 40);
            graph.AddEdge("C", "D", 50);
            string actual = TestUtils.TrimmedStringWithoutSpaces(graph.ToString());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RegioGraaf_d_Dijkstra_1_OnGraphFromExercise_1_AllPaths()
        {
            // Arrange
            IGraph graph = BuildGraph_FromExercise();
            var expected = TestUtils.TrimmedStringWithoutSpaces(
                "A; B <- A; C <- A; " +
                "D <- E <- C <- A; " +
                "E <- C <-A; F <- B <- A; " +
                "G <- A;");

            // Act
            graph.RegioDijkstra("A");
            string actual = TestUtils.TrimmedStringWithoutSpaces(graph.AllPaths());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RegioGraaf_d_Dijkstra_1_OnGraphFromExercise_2_ToString()
        {
            // Arrange
            IGraph graph = BuildGraph_FromExercise();
            var expected = TestUtils.TrimmedStringWithoutSpaces(
                "A(0)[B(2) C(3) G(4)]" +
                "B(2)[A(2) C(8) D(10) F(3)]" +
                "C(3)[A(3) B(8) E(5)]" +
                "D(10)[B(10) E(2) F(4)]" +
                "E(8)[C(5) D(2)]" +
                "F(5)[B(3) D(4)]" +
                "G(4)[A(4)]");

            // Act
            graph.RegioDijkstra("A");
            string actual = TestUtils.TrimmedStringWithoutSpaces(graph.ToString());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RegioGraaf_d_Dijkstra_2_OnOtherGraph_1_AllPaths()
        {
            // Arrange
            IGraph graph = BuildGraphOther();
            var expected = TestUtils.TrimmedStringWithoutSpaces(
                "A; B <- A; C <- B <- A;" +
                "D <- C <- B <- A;" +
                "E <- C <- B <- A;" +
                "F <- E <- C <- B <- A;");

            // Act
            graph.RegioDijkstra("A");
            string actual = TestUtils.TrimmedStringWithoutSpaces(graph.AllPaths());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RegioGraaf_d_Dijkstra_2_OnOtherGraph_2_ToString()
        {
            // Arrange
            IGraph graph = BuildGraphOther();
            var expected = TestUtils.TrimmedStringWithoutSpaces(
                "A(0) [ B(1) C(5) ]" +
                "B(1)[A(1) C(2) E(4)]" +
                "C(3)[A(5) B(2) D(6) E(1)]" +
                "D(9)[C(6) F(2)]" +
                "E(4)[B(4) C(1) F(2)]" +
                "F(6)[D(2) E(2)]");

            // Act
            graph.RegioDijkstra("A");
            string actual = TestUtils.TrimmedStringWithoutSpaces(graph.ToString());

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
