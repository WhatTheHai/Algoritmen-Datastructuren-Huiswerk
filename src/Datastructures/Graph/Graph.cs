using System;
using System.Collections.Generic;
using System.Linq;


namespace AD
{
    public partial class Graph : IGraph
    {
        public static readonly double INFINITY = System.Double.MaxValue;

        public Dictionary<string, Vertex> vertexMap;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Graph() {
            vertexMap = new Dictionary<string, Vertex>();
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Adds a vertex to the graph. If a vertex with the given name
        ///    already exists, no action is performed.
        /// </summary>
        /// <param name="name">The name of the new vertex</param>
        public void AddVertex(string name) {
            this.CreateOrReturnVertex(name);
        }


        /// <summary>
        ///    Gets a vertex from the graph by name. If no such vertex exists,
        ///    a new vertex will be created and returned.
        /// </summary>
        /// <param name="name">The name of the vertex</param>
        /// <returns>The vertex withe the given name</returns>
        public Vertex GetVertex(string name)
        {
            return CreateOrReturnVertex(name);
        }
        private Vertex CreateOrReturnVertex(string name) {
            if (vertexMap.ContainsKey(name))
                return vertexMap[name];

            Vertex createVertex = new Vertex(name);
            vertexMap.Add(name, createVertex);
            return createVertex;
        }


        /// <summary>
        ///    Creates an edge between two vertices. Vertices that are non existing
        ///    will be created before adding the edge.
        ///    There is no check on multiple edges!
        /// </summary>
        /// <param name="source">The name of the source vertex</param>
        /// <param name="dest">The name of the destination vertex</param>
        /// <param name="cost">cost of the edge</param>
        public void AddEdge(string source, string dest, double cost = 1) {
            Vertex vSource = this.CreateOrReturnVertex(source);
            Vertex vDest = this.CreateOrReturnVertex(dest);

            vSource.adj.AddFirst(new Edge(vDest, cost));
        }


        /// <summary>
        ///    Clears all info within the vertices. This method will not remove any
        ///    vertices or edges.
        /// </summary>
        public void ClearAll()
        {
            foreach (var vertex in vertexMap) {
                vertex.Value.Reset();
            }
        }

        /// <summary>
        ///    Performs the Breatch-First algorithm for unweighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Unweighted(string name) {
            ClearAll();
            Vertex startV;
            if (vertexMap[name] != null) {
                startV = vertexMap[name];
            }
            else {
                throw new SystemException();
            }

            Queue <Vertex> q = new Queue<Vertex>();
            q.Enqueue(startV);
            startV.distance = 0;

            while (q.Any()) {
                Vertex prev = q.Dequeue();
                //Check every adj
                foreach (var edge in prev.adj) {
                    Vertex next = edge.dest;
                    //If it's not infinity it's checked
                    if (next.distance == INFINITY) {
                        next.distance = prev.distance + 1;
                        q.Enqueue(next);
                        //w.prev = v; Not needed?
                    } 
                }
            }
        }

        /// <summary>
        ///    Performs the Dijkstra algorithm for weighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Dijkstra(string name)
        {
            ClearAll();
            Vertex startV;
            if (vertexMap[name] != null) {
                startV = vertexMap[name];
            } else {
                throw new SystemException();
            }

            PriorityQueue<Vertex> priorityQ = new PriorityQueue<Vertex>();
            priorityQ.Add(startV);
            startV.distance = 0;

            while (priorityQ.size != 0) {
                Vertex prev = priorityQ.Remove();

                //Only check if it's not known
                if (prev.known == false) {
                    prev.known = true;
                    foreach (var edge in prev.adj) {
                        Vertex next = edge.dest;
                        double newDistance = prev.distance + edge.cost;
                        //Overwrite if the newer found distance is smaller
                        if (next.distance > newDistance) {
                            next.distance = newDistance;
                            next.prev = prev;
                        }
                        priorityQ.Add(next);
                    }
                }
                
            }
        }

        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Converts this instance of Graph to its string representation.
        ///    It will call the ToString method of each Vertex. The output is
        ///    ascending on vertex name.
        /// </summary>
        /// <returns>The string representation of this Graph instance</returns>
        public override string ToString()
        {
            string s = "";
            foreach (string key in vertexMap.Keys.OrderBy(x => x)) {
                s += vertexMap[key];
            }

            return s;
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------



        public bool IsConnected()
        {
            throw new System.NotImplementedException();
        }

    }
}