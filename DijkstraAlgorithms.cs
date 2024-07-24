using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    public class DijkstraAlgorithms
    {

        public static Dictionary<string, Dictionary<string, int>> graph = new Dictionary<string, Dictionary<string, int>>()
        {
            //Dictonary represents the <string , int > ===> destination node and heuristic value
            { "A", new Dictionary<string, int>{{"B", 1}, {"C", 4}} },
            { "B", new Dictionary<string, int>{{"A", 1}, {"C", 2}, {"D", 5}} },
            { "C", new Dictionary<string, int>{{"A", 4}, {"B", 2}, {"D", 1}} },
            { "D", new Dictionary<string, int>{{"B", 5}, {"C", 1}} }
        };


        public  void Dijkstra(string start)
        {

            //start stores the value of the start node 'Key'
            var distances = new Dictionary<string, int>();
            var previous = new Dictionary<string, string>();
            var nodes = new List<string>();

            foreach (var node in graph)
            {

                ///Check if the start node is final destination node
                if (node.Key == start)
                {
                    distances[node.Key] = 0;
                }
                //Firstly set the value to the infinity or int's max value
                else
                {
                    distances[node.Key] = int.MaxValue;
                }

                nodes.Add(node.Key);
            }
            //nodes = > A,B,C,D
            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in graph[smallest])
                {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                    }
                }
            }

            foreach (var distance in distances)
            {
                Console.WriteLine($"Distance from {start} to {distance.Key} is {distance.Value}");
            }
        }

       
    }
}
