using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree_BC
{
    class Program
    {
        static void Main(string[] args)
        {
            //On ajoute les points au QuadTree
            Quadtree tree = new Quadtree(100);
            foreach (Point p in JeuDeTestAleatoire())
            {
                tree.addPoint(p);
            }

            Console.WriteLine("Le QuadTree viens d'être créé !!!");
            AskSomethingToUser(tree);

        }


        private static void AskSomethingToUser(Quadtree tree)
        {
            AfficheLesConsignes();
            ExecuteActionEnFonctionChoixUtilisateur(tree, Console.ReadLine());
        }
        private static void ExecuteActionEnFonctionChoixUtilisateur(Quadtree tree, String userChoice)
        {
            switch (userChoice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Représentation de l'arbre");
                    Console.WriteLine();
                    tree.graphicTreePrint(1, "");
                    AskSomethingToUser(tree);
                    break;
                case "2":
                    Console.Clear();
                    Point point = CreatePoint();
                    PrintInfoPoints(tree, point);
                    AskSomethingToUser(tree);
                    break;
                default:
                    break;
            }
        }

        private static Point CreatePoint()
        {
            Console.WriteLine("Entrez le x : ");
            double x = Double.Parse(Console.ReadLine());

            Console.WriteLine("Entrez le y : ");
            double y = Double.Parse(Console.ReadLine());

            Point point = new Point(x, y);
            return point;
        }

        private static void PrintInfoPoints(Quadtree tree, Point point)
        {
            Node n = tree.returnNodeIfContainPoint(point);
            if(n != null)
            {   
                Console.WriteLine("Profondeur : " + n.getNodePointDepth().ToString());
                Console.WriteLine("Points voisins : ");
                n.printPointsVoisins();
            } else
            {
                Console.WriteLine("Point non trouvé");
            }
        }

        private static void AfficheLesConsignes()
        {
            Console.WriteLine();
            Console.WriteLine("Tapez 1 pour afficher l'arbre");
            Console.WriteLine("Tapez 2 pour obtenir les infos d'un point");
        }

        public void AddPoint()
        {
            Console.Clear();
            Console.WriteLine();
        }

       
        /// <summary>
        /// Jeu de 50 points aleatoires
        /// </summary>
        /// <returns></returns>
        static public List<Point> JeuDeTestAleatoire()
        {
            List<Point> listPoint = new List<Point>();
            Random random = new Random();
            for (var i = 0; i < 100; i++)
            {
                listPoint.Add(new Point(random.Next(0, 100), random.Next(0, 100)));
            }
            return listPoint;
        }

        /// <summary>
        /// Test avec 5 points => 4 noeuds dont 1 avec 2 points
        /// </summary>
        /// <returns></returns>
        static public List<Point> JeuDeTest1()
        {
            List<Point> listPoint = new List<Point>();
            listPoint.Add(new Point(20, 20));
            listPoint.Add(new Point(20, 20));
            listPoint.Add(new Point(20, 20));
            listPoint.Add(new Point(40, 20));
            listPoint.Add(new Point(20, 80));
            listPoint.Add(new Point(80, 20));
            listPoint.Add(new Point(80, 80));
            return listPoint;
        }

        /// <summary>
        /// Jeu de test avec un point sur une limite
        /// </summary>
        /// <returns></returns>
        static public List<Point> JeuDeTestSurLaLigne()
        {
            List<Point> listPoint = new List<Point>();
            listPoint.Add(new Point(20, 20));
            listPoint.Add(new Point(40, 20));
            listPoint.Add(new Point(50, 50));
            listPoint.Add(new Point(80, 20));
            listPoint.Add(new Point(80, 80));
            return listPoint;
        }

        /// <summary>
        /// Test avec 8 points => 7 noeuds 
        /// </summary>
        /// <returns></returns>
        static public List<Point> JeuDeTest2()
        {
            List<Point> listPoint = new List<Point>();
            listPoint.Add(new Point(20, 20));
            listPoint.Add(new Point(40, 20));
            listPoint.Add(new Point(35, 45));
            listPoint.Add(new Point(40, 48));
            listPoint.Add(new Point(45, 45));
            listPoint.Add(new Point(20, 80));
            listPoint.Add(new Point(80, 20));
            listPoint.Add(new Point(80, 80));
            return listPoint;
        }
    }
}
