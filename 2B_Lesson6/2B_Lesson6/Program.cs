using System;
using System.Collections.Generic;

namespace _2B_Lesson6
{

    //Модифицируйте DFS и BFS из предыдущего урока, но уже для графа, также с выводом каждого шага
    public class Graph
    {

        private int Vertices { get; set; }
        private List<Int32>[] Adj { get; set; }

        public Graph(int v)
        {
            Vertices = v;
            Adj = new List<Int32>[v];
            for (int i = 0; i < v; i++)
            {
                Adj[i] = new List<int>();
            }
        }

        public void Addedge(int c, int v)
        {
            Adj[c].Add(v);
        }

        public void DFS(int v)
        {
            bool[] visited = new bool[Vertices];
            Stack<Int32> stack = new Stack<int>();
            visited[v] = true;
            stack.Push(v);
            while (stack.Count != 0)
            {
                v = stack.Pop();
                Console.WriteLine("next ->" + v);
                foreach (int i in Adj[v])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        stack.Push(i);
                    }

                }
            }
        }
        public void BFS(int v)
        {
            bool[] visited = new bool[Vertices];
            Queue<Int32> queue = new Queue<int>();
            visited[v] = true;
            queue.Enqueue(v);
            while (queue.Count != 0)
            {
                v = queue.Dequeue();
                Console.WriteLine("next ->" + v);
                foreach (int i in Adj[v])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }

                }
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {

            var graph = new Graph(5);
            graph.Addedge(1, 2);
            graph.Addedge(1, 3);
            graph.Addedge(3, 4);
            Console.WriteLine("\nDFS:");
            graph.DFS(1);
            Console.WriteLine("\nBFS:");
            graph.BFS(1);
            Console.ReadLine();

        }
    }

}



