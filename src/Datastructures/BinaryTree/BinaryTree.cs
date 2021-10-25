using System;

namespace AD
{
    public partial class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryNode<T> root;

        //----------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------

        public BinaryTree() {
            root = null;
        }

        public BinaryTree(T rootItem) {
            root = new BinaryNode<T>(rootItem, null, null);
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public BinaryNode<T> GetRoot() {
            return root;
        }

        public int Size() {
            return Size(root);
        }

        public int Size(BinaryNode<T> node) {
            if (node == null) {
                return 0;
            }

            return 1 + Size(node.right) + Size(node.left);
        }

        public int Height() {
            return Height(root);
        }

        public int Height(BinaryNode<T> node) {
            if (node == null) {
                return -1;
            }

            return 1 + Math.Max(Height(node.left), Height(node.right));
        }

        public void MakeEmpty() {
            root = null;
        }

        public bool IsEmpty() {
            return root == null;
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
        {
            if (t1.root == t2.root && t1.root != null) {
                throw new ArgumentException();
            }

            root = new BinaryNode<T>(rootItem, t1.root, t2.root);

            //Check if node is in one tree
            if (this != t1) {
                t1.root = null;
            }

            if (this != t2) {
                t2.root = null;
            }
        }

        public string ToPrefixString()
        {
            if (root == null) {
                return "NIL";
            }

            return ToPrefixString(root);
        }

        public string ToPrefixString(BinaryNode<T> node) {
            string s = "[ " + node.data + " ";
            s += node.left != null ? ToPrefixString(node.left) + " " : "NIL ";
            s += node.right != null ? ToPrefixString(node.right) + " " : "NIL ";
            return s + "]";
        }

        public string ToInfixString()
        {
            if (root == null) {
                return "NIL";
            }
            return "";
        }

        public string ToPostfixString()
        {
            if (root == null) {
                return "NIL";
            }
            return "";
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public int NumberOfLeaves()
        {
            throw new System.NotImplementedException();
        }

        public int NumberOfNodesWithOneChild()
        {
            throw new System.NotImplementedException();
        }

        public int NumberOfNodesWithTwoChildren()
        {
            throw new System.NotImplementedException();
        }
    }
}