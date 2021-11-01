using System;
using System.Collections.Generic;

namespace AD
{
    public partial class Graph
    {
        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented during exam
        //----------------------------------------------------------------------
        public void RegioClearAll() // Calls Vertex.RegionReset() for all vertices
        {
            foreach (var kvp in vertexMap) {
                kvp.Value.RegioReset();
            }
        }

        public string AllPaths() {
            string s = "";

            foreach (var kvp in vertexMap) {
                Vertex v = kvp.Value;

                s += v.name;
                while (v.prev != null) {
                    v = v.prev;
                    s += $"<-{v.name}";
                }

                s += ";\n";
            }

            return s;
        }

        public void AddUndirectedEdge(string source, string dest, double cost)
        {
            this.AddEdge(source, dest, cost);
            this.AddEdge(dest, source, cost);
        }


        public void AddVertex(string name, string regio)
        {
            vertexMap.Add(name, new Vertex(name, regio));
        }


        public void RegioDijkstra(string name) {
            throw new NotImplementedException();
            // RegioClearAll();
            // Vertex startV;
            // if (vertexMap[name] != null) {
            //     startV = vertexMap[name];
            // } else {
            //     throw new SystemException();
            // }
            //
            // PriorityQueue<Vertex> priorityQ = new PriorityQueue<Vertex>();
            // priorityQ.Add(startV);
            // startV.distance = 0;
            //
            // while (priorityQ.size != 0) {
            //     Vertex prev = priorityQ.Remove();
            //
            //     //Only check if it's not known
            //     if (prev.known == false) {
            //         prev.known = true;
            //         foreach (var edge in prev.adj) {
            //             Vertex next = edge.dest;
            //             double newDistance = prev.distance + edge.cost;
            //             //Overwrite if the newer found distance is smaller
            //             if (next.distance > newDistance) {
            //                 prev.known = true;
            //                 next.distance = newDistance;
            //                 next.prev = prev;
            //             }
            //             priorityQ.Add(next);
            //         }
            //     }
            //
            // }
        }
    }
}
