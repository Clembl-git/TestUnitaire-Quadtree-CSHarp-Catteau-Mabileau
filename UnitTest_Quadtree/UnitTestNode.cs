using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuadTree_BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Quadtree
{
    [TestClass]
    public class UnitTestNode
    {

        [ClassInitialize]
        public static void setUp(TestContext context)
        {
          Node node = new Node(new Point(0, 0), 100);
        }

        [TestMethod]
        public void ShouldHave1Point()
        {
            Point point = new Point(1, 2);

            Node node = new Node(new Point(0, 0), 100);
            node.addPoint(point);
            int expected = 1;

            Assert.AreEqual(expected, 1);
        }

        [TestMethod]
        public void ShouldHave0PointBecauseOutOfBonds()
        {
            Node node = new Node(new Point(0, 0), 100);
            node.addPoint(new Point(101, 103));

            Assert.AreEqual(0, node.getNbPoint());
        }

        [TestMethod]
        public void ShouldHave0PointBecauseOutOfBonds2()
       {
            Node node = new Node(new Point(0, 0), 100);
            node.addPoint(new Point(100, (-1)));

            Assert.AreEqual(0, node.getNbPoint());
        }

        [TestMethod]
        public void PlaceMultiplePointAndSplitIntoChildrens()
        {
            Random random = new Random();
            Quadtree tree = new Quadtree(100);
            tree.addPoint(new Point(1, 1));
            tree.addPoint(new Point(10, 1));
            tree.addPoint(new Point(20, 20));
            tree.addPoint(new Point(30, 30));
            //4 points & no children
            Assert.AreEqual(4, tree.getNbPoint());
            Assert.AreEqual(false, tree.haveChildren());

            tree.addPoint(new Point(1, 4));
            //0 point & 4 childrens           
            Assert.AreEqual(0, tree.getNbPoint());
            Assert.AreEqual(true, tree.haveChildren());
            Assert.AreEqual(4, tree.getChilds().Count);

            //Still 0 point, all added in childrens nodes
            tree.addPoint(new Point(40, 40));
            Assert.AreEqual(0, tree.getNbPoint());
            tree.addPoint(new Point(4, 3));
            tree.addPoint(new Point(4, 10));
            tree.addPoint(new Point(5, 4));
            Assert.AreEqual(0, tree.getNbPoint());
        }

        [TestMethod]
        public void ShouldHave4Childs()
        {
            Node node = new Node(new Point(0, 0), 100);
            node.addPoint(new Point(20, 20));
            node.addPoint(new Point(40, 20));
            node.addPoint(new Point(20, 80));
            node.addPoint(new Point(80, 80));
            node.addPoint(new Point(80, 80));
            
            Assert.AreEqual(4, node.getChilds().Count);
            Assert.AreEqual(0, node.getNbPoint());
        }

        [TestMethod]
        public void ShouldHave0PointAndChildrens()
        {
            Node node = new Node(new Point(0, 0), 100);
            node.addPoint(new Point(20, 20));
            node.addPoint(new Point(40, 20));
            node.addPoint(new Point(20, 80));
            node.addPoint(new Point(80, 20));
            node.addPoint(new Point(80, 80));

            Assert.AreEqual(0, node.getNbPoint());
            Assert.AreEqual(true, node.haveChildren());
        }

        [TestMethod]
        public void ShouldHave1PointAnd4Childrens()
        {
            Node node = new Node(new Point(0, 0), 100);
            node.addPoint(new Point(20, 20));
            node.addPoint(new Point(40, 20));
            node.addPoint(new Point(50, 50));
            node.addPoint(new Point(80, 20));
            node.addPoint(new Point(80, 80));

            Assert.AreEqual(1, node.getNbPoint());
            Assert.AreEqual(4, node.getChilds().Count);
        }

        [TestMethod]
        public void ShouldHave1Voisins()
        {
            Node node = new Node(new Point(0, 0), 100);
            node.addPoint(new Point(40, 40));

            Assert.AreEqual(1, node.getPointsVoisins(new Point(80, 80)).Count);
        }


        [TestMethod]
        public void ShouldHave3VoisinsAndNoChildren()
        {
            Node node = new Node(new Point(0, 0), 100);
            node.addPoint(new Point(20, 20));
            node.addPoint(new Point(40, 20));
            node.addPoint(new Point(40, 40)); 

            Assert.AreEqual(3, node.getPointsVoisins(new Point(40, 40)).Count);
            Assert.AreEqual(false, node.haveChildren());
        }

        [TestMethod]
        public void ShouldHave4VoisinsAndNoChildrens()
        {
            Node node = new Node(new Point(0, 0), 100);
            node.addPoint(new Point(20, 20));
            node.addPoint(new Point(40, 20));
            node.addPoint(new Point(40, 40));
            node.addPoint(new Point(42, 42)); 

            Assert.AreEqual(4, node.getPointsVoisins(new Point(25, 25)).Count);
            Assert.AreEqual(false, node.haveChildren());
        }

        [TestMethod]
        public void ShouldHave0VoisinsAndChildrens()
        {
            Node node = new Node(new Point(0, 0), 100);
            node.addPoint(new Point(20, 20));
            node.addPoint(new Point(40, 20));
            node.addPoint(new Point(40, 40));
            node.addPoint(new Point(45, 45));
            node.addPoint(new Point(44, 44));

            Assert.AreEqual(0, node.getPointsVoisins(new Point(25, 25)).Count);
            Assert.AreEqual(true, node.haveChildren());
        }

        [TestMethod]
        public void ShouldHave1VoisinAndChildrens()
        {
            Node node = new Node(new Point(0, 0), 100);
            node.addPoint(new Point(90, 90));
            node.addPoint(new Point(84, 78));
            node.addPoint(new Point(86, 86));
            node.addPoint(new Point(80, 80));
            //Will stay on root node
            node.addPoint(new Point(50, 50));


            Assert.AreEqual(true, node.haveChildren());
            Assert.AreEqual(1, node.getPointsVoisins(new Point(75, 75)).Count);
        }


        [TestMethod]
        public void PointShouldBeDepth0()
        {
            Node node = new Node(new Point(0, 0), 100);
            node.addPoint(new Point(1, 1));

            int depth1stChild = node.getNodePointDepth();

            Assert.AreEqual(0, depth1stChild);
        }

        [TestMethod]
        public void PointShouldBeDepth1()
        {
            Node node = new Node(new Point(0, 0), 100);
            node.addPoint(new Point(1, 1));
            node.addPoint(new Point(51, 51));
            node.addPoint(new Point(42, 42));
            node.addPoint(new Point(1, 51));
            node.addPoint(new Point(90, 51));

            int depth1stChild = node.getChilds()[Node.Loc.NE].getNodePointDepth();

            Assert.AreEqual(1, depth1stChild);
        }
        [TestMethod]
        public void PointShouldBeDepth2()
        {
            Node node = new Node(new Point(0, 0), 100);
            node.addPoint(new Point(90, 90));
            node.addPoint(new Point(51, 51));
            node.addPoint(new Point(51, 99));
            node.addPoint(new Point(99, 51));
            node.addPoint(new Point(82, 82));

            int depth2ndChild = node.getChilds()[Node.Loc.NE]
                                    .getChilds()[Node.Loc.NE].getNodePointDepth();

            Assert.AreEqual(2, depth2ndChild);
        }
        [TestMethod]
        public void PointShouldBeInNodeDepth3()
        {
            Node node = new Node(new Point(0, 0), 100);
            node.addPoint(new Point(90, 90));
            node.addPoint(new Point(89, 89));
            node.addPoint(new Point(82, 72));
            node.addPoint(new Point(80, 80));
            node.addPoint(new Point(82, 82));
            node.addPoint(new Point(83, 83));
            node.addPoint(new Point(87, 82));

            int depth3ndChild = node.getChilds()[Node.Loc.NE]
                                    .getChilds()[Node.Loc.NE]
                                    .getChilds()[Node.Loc.NE].getNodePointDepth();

            Assert.AreEqual(3, depth3ndChild);
        }
        [ClassCleanup]
        public static void ClassCleanup() { }
    }
}
