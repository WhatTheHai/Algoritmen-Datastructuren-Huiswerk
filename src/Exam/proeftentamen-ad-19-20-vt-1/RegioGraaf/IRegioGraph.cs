using System;
using System.Collections.Generic;
using System.Text;

namespace AD
{
    public partial interface IGraph
    {
        //----------------------------------------------------------------------
        // Methods that have to be implemented during exam
        //----------------------------------------------------------------------
        string AllPaths();
        void AddVertex(string name, string regio);
        void AddUndirectedEdge(string source, string dest, double cost);
        public void RegioDijkstra(string name);
    }
}
