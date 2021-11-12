using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2BLesson4_2
{
    //2.  Реализуйте двоичное дерево и метод вывода его в консоль
    //    Реализуйте класс двоичного дерева поиска с операциями вставки, удаления, поиска.
    //    Дерево должно быть сбалансированным(это требование не обязательно). 
    //    Также напишите метод вывода в консоль дерева, чтобы увидеть, насколько корректно работает ваша реализация.


    public class TreeNode
    {
        private int data; 
        public int Data
        {
            get { return data; }
        }

        private TreeNode rightNode;
        public TreeNode RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }

        private TreeNode leftNode;
        public TreeNode LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }

        private bool isDeleted;
        public bool IsDeleted
        {
            get { return isDeleted; }
        }

        
        public TreeNode(int value)
        {
            data = value;
        }

        
        public void Delete()
        {
            isDeleted = true;
        }

        public TreeNode Find(int value)
        {
            
            TreeNode currentNode = this;

           
            while (currentNode != null)
            {
                
                if (value == currentNode.data && isDeleted == false)
                {
                    return currentNode;
                }
                else if (value > currentNode.data)
                {
                    currentNode = currentNode.rightNode;
                }
                else
                {
                    currentNode = currentNode.leftNode;
                }
            }
           
            return null;
        }


        
        public void Insert(int value)
        {
           
            if (value >= data)
            {   
                if (rightNode == null)
                {
                    rightNode = new TreeNode(value);
                }
                else
                {
                    rightNode.Insert(value);
                }
            }
            else
            {
                if (leftNode == null)
                {
                    leftNode = new TreeNode(value);
                }
                else
                {
                    leftNode.Insert(value);
                }
            }
        }


        
        public void PreOrderTraversal()
        {
            
            Console.Write(data + " " );
            
            
            if (leftNode != null)
                leftNode.PreOrderTraversal();
            
            
            if (rightNode != null)
            {
                rightNode.PreOrderTraversal();
                
            }
        }

        public int Height()
        {
            
            if (this.leftNode == null && this.rightNode == null)
            {
                return 1; 
            }

            int left = 0;
            int right = 0;

            
            if (this.leftNode != null)
                left = this.leftNode.Height();
            if (this.rightNode != null)
                right = this.rightNode.Height();

            
            if (left > right)
            {
                return (left + 1);
            }
            else
            {
                return (right + 1);
            }

        }

        public bool IsBalanced()
        {
            int LeftHeight = LeftNode != null ? LeftNode.Height() : 0;
            int RightHeight = RightNode != null ? RightNode.Height() : 0;

            int heightDifference = LeftHeight - RightHeight;

            if (Math.Abs(heightDifference) > 1)
            {
                return false;
            }
            else
            {
                return ((LeftNode != null ? LeftNode.IsBalanced() : true) && (RightNode != null ? RightNode.IsBalanced() : true));
            }
        }
    }

    public interface ITree
    {

       
        void Insert(int data); // добавить узел
        void Remove(int data); // удалить узел по значению
        TreeNode Find( int data); //получить узел дерева по значению
        bool IsBalanced();
        void PreorderTraversal(); //вывести дерево в консоль
    }  

    public class Tree : ITree
    {

        private TreeNode root;
        public TreeNode Root
        {
            get { return root; }
        }


        
        public TreeNode Find(int data)
        {
            
            if (root != null)
            {
                
                return root.Find(data);
            }
            else
            {
                return null;
            }
        }

       
        public void Insert(int data)
        {
            
            if (root != null)
            {
                root.Insert(data);
            }
            else
            {
                root = new TreeNode(data);
            }
        }

        
        public void Remove(int data)
        {
            
            TreeNode current = root;
            TreeNode parent = root;
            bool isLeftChild = false;

           
            if (current == null)
            {
                return;
            }

           
            while (current != null && current.Data != data)
            {
                
                parent = current;

               
                if (data < current.Data)
                {
                    current = current.LeftNode;
                    isLeftChild = true;
                }
                else
                {
                    current = current.RightNode;
                    isLeftChild = false;
                }
            }

            if (current == null)
            {
                return;
            }

           
            if (current.RightNode == null && current.LeftNode == null)
            {
                
                if (current == root)
                {
                    root = null;
                }
                else
                {
                   
                    if (isLeftChild)
                    {
                        
                        parent.LeftNode = null;
                    }
                    else
                    {   
                        parent.RightNode = null;
                    }
                }
            }
            else if (current.RightNode == null) 
            {
                
                if (current == root)
                {
                    root = current.LeftNode;
                }
                else
                {
                    
                    if (isLeftChild)
                    {
                        
                        parent.LeftNode = current.LeftNode;
                    }
                    else
                    {   
                        parent.RightNode = current.LeftNode;
                    }
                }
            }
            else if (current.LeftNode == null) 
            {
                
                if (current == root)
                {
                    root = current.RightNode;
                }
                else
                {
                   
                    if (isLeftChild)
                    {   
                        parent.LeftNode = current.RightNode;
                    }
                    else
                    {   
                        parent.RightNode = current.RightNode;
                    }
                }
            }
            else
            {
               
               
                TreeNode successor = GetSuccessor(current);
               
                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                {
                    parent.LeftNode = successor;
                }
                else
                {
                    parent.RightNode = successor;
                }

            }

        }

        private TreeNode GetSuccessor(TreeNode node)
        {
            TreeNode parentOfSuccessor = node;
            TreeNode successor = node;
            TreeNode current = node.RightNode;

            
            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.LeftNode;
            }
            
            if (successor != node.RightNode)
            {
              
                parentOfSuccessor.LeftNode = successor.RightNode;
                
                successor.RightNode = node.RightNode;
            }
            
            successor.LeftNode = node.LeftNode;

            return successor;
        }

        
        public void PreorderTraversal()
        {
            if (root != null)
                root.PreOrderTraversal();
        }

       

       
        public bool IsBalanced()
        {
            if (root == null)
            {
                return true;
            }

            return root.IsBalanced();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Binary Search Tree\n");

            var binaryTree = new Tree();
            
            binaryTree.Insert(75);
            binaryTree.Insert(57);
            binaryTree.Insert(90);
            binaryTree.Insert(32);
            binaryTree.Insert(7);
            binaryTree.Insert(44);
            binaryTree.Insert(60);
            binaryTree.Insert(86);
            binaryTree.Insert(93);
            binaryTree.Insert(99);
            binaryTree.Insert(100);
            binaryTree.Find(57);
            binaryTree.Remove(90);
            binaryTree.Insert(125);
           
            Console.WriteLine("\nPre Order Traversal (Root->Left->Right)");
            binaryTree.PreorderTraversal();
           
            Console.ReadLine();



        }
    }

}


