using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2B_Lesson_5
{


    public class Node
    {
       public int data;
       public Node left;
       public Node right;

        public Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }

    }

    public class DFSBFS
    {
        public void DFS(Node root)
        {
            Stack<Node> s = new Stack<Node>();
            s.Push(root);

            while (s.Count > 0)            {
                Node x = s.Pop();
                if (x.right != null) s.Push(x.right);
                if (x.left != null) s.Push(x.left);
                Console.WriteLine(" " + x.data);
            }
        }

        public void BFS (Node root)
        {                                                                                                                                                      
            Queue <Node> q = new Queue<Node>();
            q.Enqueue(root);
            
            while(q.Count > 0)
            {
                Node x = q.Dequeue();
                if (x.right != null) q.Enqueue(x.right);
                if (x.left != null) q.Enqueue(x.left);
                Console.WriteLine(" " + x.data);
            }
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {

           
            Node root = new Node(3);
            root.left = new Node(2);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right = new Node(3);
            root.right.left = new Node(6);
            root.right.right = new Node(7);

            
            Console.WriteLine("Depth-First-Search : ");
            DFSBFS b = new DFSBFS();
            b.DFS(root);

            Console.WriteLine("Breadth - First -Search : "); 
            b.BFS(root);

            Console.ReadLine();

        }
    }
}

