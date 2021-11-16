using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2BLesson2
{

    //1. Двусвязный список
    //Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска элемента в нём в соответствии с интерфейсом.

    class Program
    {
        public class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }

        }

        //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
        public interface ILinkedList
        {
            int GetCount(Node node); // возвращает количество элементов в списке
            void AddNode(Node startNode, int value);  // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            Node RemoveNode(Node startNode, int index); // удаляет элемент по порядковому номеру
            Node RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(Node startNode, int searchValue); // ищет элемент по его значению
        }

        public class LinkedList : ILinkedList
        {
            public void AddNode(Node startNode, int value)
            {
                var node = startNode;

                while (node.NextNode != null)
                {
                    node = node.NextNode;
                }

                var newNode = new Node { Value = value };
                node.NextNode = newNode;
            }

            public void AddNodeAfter(Node node, int value)
            {
                var newNode = new Node { Value = value };
                var nextItem = node.NextNode;
                node.NextNode = newNode;
                newNode.NextNode = nextItem;
            }

            public Node FindNode(Node startNode, int searchValue)
            {

                var currentNode = startNode;

                while (currentNode != null)
                {
                    if (currentNode.Value == searchValue)
                        return currentNode;

                    currentNode = currentNode.NextNode;
                }

                return null; // если ничего не нашли, то null

            }

            public int GetCount(Node node)
            {

                var count = 0;
                while (node != null)
                {
                    node = node.NextNode;
                    count++;
                }
                return count;
            }

                public Node RemoveNode(Node node)
                {
                    if (node.NextNode == null)
                        return node;
                    var nextItem = node.NextNode.NextNode;
                    node.NextNode = nextItem;
                    return node;


                }
                public Node RemoveNode(Node startNode, int index)
                {
                    if (index == 0)
                    {
                        var newStartNode = startNode.NextNode;
                        startNode.NextNode = null;

                    }

                    int currentIndex = 0;
                    var currentNode = startNode;
                    while (currentNode != null)
                    {
                        if (currentIndex == index - 1)
                        {
                            RemoveNode(currentNode);
                            return startNode;
                        }

                        currentNode = currentNode.NextNode;
                        currentIndex++;
                    }

                    return startNode;
                }

            }

            static void Main(string[] args)
            {

                var linkedList = new LinkedList();
                var node = new Node() { Value = 1 };
                var node1 = new Node { Value = 2, PrevNode = node };
                var node2 = new Node { Value = 9, PrevNode = node1 };
                var node3 = new Node { Value = 7, PrevNode = node2 };
                var node4 = new Node { Value = 5, PrevNode = node3 };
                var node5 = new Node { Value = 20, PrevNode = node4 };
                linkedList.AddNode(node, 10);
                linkedList.AddNodeAfter(node, 3);
                linkedList.FindNode(node, 20);
                linkedList.RemoveNode(node);
                linkedList.RemoveNode(node5, 2);
                linkedList.GetCount(node4);

                Console.ReadLine();

            }
        }
    }


