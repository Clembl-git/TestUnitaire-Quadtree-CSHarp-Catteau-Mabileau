using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree_BC
{
    public class Quadtree : Node
    { 
        public Node _tree { get; set; }
        
        public Quadtree(double size) : base(new Point(0,0), size)
        {  
        }
    }
}