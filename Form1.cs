using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Binary Search Tree\n");

            BinaryTree binaryTree = new BinaryTree();


            binaryTree.Insert(55);
            binaryTree.Insert(35);
            binaryTree.Insert(60);
            binaryTree.Insert(65);
            binaryTree.Insert(45);
            binaryTree.Insert(40);
            binaryTree.Insert(25);
            binaryTree.Insert(20);
            binaryTree.Insert(57);
            binaryTree.Insert(68);
            binaryTree.Insert(15);

            int _data = 25;

            if (binaryTree.Find(_data) == null)
            {
                //MessageBox.Show(_data + " not found");
            }
            else
            {
                //MessageBox.Show(_data + " found");
            }
            //Console.WriteLine(binaryTree.FindRecursive(55));
            //binaryTree.FindBad("Left");
            binaryTree.FindAndFixBadLeft();
            binaryTree.FindAndFixBadRight();
        }
    }
    public class BinaryTree
    {
        private TreeNode root;
        public TreeNode Root
        {
            get { return root; }
        }
        //O(Log n)
        public TreeNode Find(int data)
        {
            //if the root is not null then we call the find method on the root
            if (root != null)
            {
                // call node method Find
                return root.Find(data);
            }
            else
            {//the root is null so we return null, nothing to find
                return null;
            }
        }
        public TreeNode FindAndFixBadLeft()
        {
            //if the root is not null then we call the find method on the root
            if (root != null)
            {
                // call node method Find
                return root.FindAndFixBadLeft();
            }
            else
            {//the root is null so we return null, nothing to find
                return null;
            }
        }
        public TreeNode FindAndFixBadRight()
        {
            //if the root is not null then we call the find method on the root
            if (root != null)
            {
                // call node method Find
                return root.FindAndFixBadRight();
            }
            else
            {//the root is null so we return null, nothing to find
                return null;
            }
        }

        public TreeNode FindBad(string bad)
        {
            if (root != null)
            {
                if (bad == "Left")
                {
                    return root.FindBadLeft();
                }
                else
                {
                    return root.FindBadRight();
                }
            }
            return null;
        }
        //O(Log n)
        public TreeNode FindRecursive(int data)
        {
            //if the root is not null then we call the recursive find method on the root
            if (root != null)
            {
                //call Node Method FindRecursive
                return root.FindRecursive(data);
            }
            else
            {//the root is null so we return null, nothing to find
                return null;
            }
        }
        public void Insert(int data)
        {
            //if the root is not null then we call the Insert method on the root node
            if (root != null)
            {
                root.Insert(data);
            }
            else
            {//if the root is null then we set the root to be a new node based on the data passed in
                root = new TreeNode(data);
            }
        }
        public void InOrderTraversal()
        {
            if (root != null)
                root.InOrderTraversal();
        }
    }
    public class TreeNode
    {   //property to store the nodes data could be a key and object pair
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
        }//Right Child
        private TreeNode leftNode;
        public TreeNode LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }//left Child
        private bool isDeleted;//soft delete variable
        public bool IsDeleted
        {
            get { return isDeleted; }
        }
        //Node constructor
        public TreeNode(int value)
        {
            data = value;
        }
        //Method to set soft delete
        public void Delete()
        {
            isDeleted = true;
        }
        //Number return in ascending order
        //Left->Root->Right Nodes recursively of each subtree
        
        public TreeNode FindAndFixBadLeft()
        {
            int parentNode;
            //this node is the starting current node
            TreeNode currentNode = this;
            while (currentNode != null && currentNode.leftNode != null)
            {
                //looking if left is greater than root node (which is bad)
                if (currentNode.leftNode.data > data)
                {
                    MessageBox.Show(currentNode.leftNode.data + " is a bad left node");
                    parentNode = currentNode.data;
                    currentNode.data = currentNode.leftNode.data;
                    currentNode.leftNode.data = parentNode;
                }
                else if (currentNode.rightNode != null && currentNode.rightNode.data < data)
                {
                    //return leftNode.FindAndFixBadRight();
                    MessageBox.Show(currentNode.rightNode.data + " is a bad right node");
                    parentNode = currentNode.data;
                    currentNode.data = currentNode.rightNode.data;
                    currentNode.rightNode.data = parentNode;
                }
                else
                {
                    if(currentNode.rightNode != null)
                    rightNode.FindAndFixBadRight();
                    return leftNode.FindAndFixBadLeft();
                }
            }
            //bad node not found
            return null;
        }

        public TreeNode FindAndFixBadRight()
        {
            int parentNode;
            //this node is the starting current node
            TreeNode currentNode = this;
            while (currentNode != null && currentNode.rightNode != null)
            {
                //looking if left is greater than root node (which is bad)
                if (currentNode.rightNode.data < data)
                {
                    MessageBox.Show(currentNode.rightNode.data + " is a bad right node");
                    parentNode = currentNode.data;
                    currentNode.data = currentNode.rightNode.data;
                    currentNode.rightNode.data = parentNode;
                }
                else if (currentNode.leftNode !=null && currentNode.leftNode.data > data)
                {
                    //return leftNode.FindAndFixBadLeft();
                    MessageBox.Show(currentNode.leftNode.data + " is a bad left node");
                    parentNode = currentNode.data;
                    currentNode.data = currentNode.leftNode.data;
                    currentNode.leftNode.data = parentNode;
                }
                else
                {
                    if (currentNode.leftNode != null)
                        leftNode.FindAndFixBadLeft();
                    return rightNode.FindAndFixBadRight();
                }
            }
            //bad node not found
            return null;
        }

        public void InOrderTraversal()
        {
            //first go to left child its children will be null so we print its data
            if (leftNode != null)
                leftNode.InOrderTraversal();
            //Then we print the root node
            Console.Write(data + " ");
            //Then we go to the right node which will print itself as both its children are null
            if (rightNode != null)
                rightNode.InOrderTraversal();
        }
        public TreeNode Find(int value)
        {
            //this node is the starting current node
            TreeNode currentNode = this;
            //loop through this node and all of the children of this node
            while (currentNode != null)
            {
                //if the current nodes data is equal to the value passed in return it
                if (value == currentNode.data && isDeleted == false)//soft delete check
                {
                    return currentNode;
                }
                else if (value > currentNode.data)//if the value passed in is greater than the current data then go to the right child
                {
                    currentNode = currentNode.rightNode;
                }
                else//otherwise if the value is less than the current nodes data the go to the left child node
                {
                    currentNode = currentNode.leftNode;
                }
            }
            //Node not found
            return null;
        }
        public TreeNode FindBadLeft()
        {
            //this node is the starting current node
            TreeNode currentNode = this;
            while (currentNode != null && currentNode.leftNode != null)
            {
                //looking if left is greater than root node (which is bad)
                if (currentNode.leftNode.data > data)
                {
                    MessageBox.Show(currentNode.leftNode.data + " is a bad left node");
                    return null;
                }
                else
                {
                    return leftNode.FindBadLeft();
                }
            }
            //bad node not found
            return null;
        }
        public TreeNode FindBadRight()
        {
            //this node is the starting current node
            TreeNode currentNode = this;
            while (currentNode != null && currentNode.rightNode != null)
            {
                //looking if right is greater than root node (which is bad)
                if (currentNode.rightNode.data < data)
                {
                    MessageBox.Show(currentNode.rightNode.data + " is a bad right node");
                    return null;
                }
                else
                {
                    return rightNode.FindBadRight();
                }
            }
            //bad not found
            return null;
        }
        public TreeNode FindRecursive(int value)
        {
            //value passed in matches nodes data return the node
            if (value == data && isDeleted == false)
            {
                return this;
            }
            else if (value < data && leftNode != null)//if the value passed in is less than the current data then go to the left child
            {
                return leftNode.FindRecursive(value);
            }
            else if (rightNode != null)//if its great then go to the right child node
            {
                return rightNode.FindRecursive(value);
            }
            else
            {
                return null;
            }
        }
        public void Insert(int value)
        {
            //if the value passed in is greater or equal to the data then insert to right node
            if (value >= data)
            {   //if right child node is null create one
                if (rightNode == null)
                {
                    rightNode = new TreeNode(value);
                }
                else
                {//if right node is not null recursivly call insert on the right node
                    rightNode.Insert(value);
                }
            }
            else
            {//if the value passed in is less than the data then insert to left node
                if (leftNode == null)
                {//if the leftnode is null then create a new node
                    leftNode = new TreeNode(value);
                }
                else
                {//if the left node is not null then recursively call insert on the left node
                    leftNode.Insert(value);
                }
            }
        }
    }
}
