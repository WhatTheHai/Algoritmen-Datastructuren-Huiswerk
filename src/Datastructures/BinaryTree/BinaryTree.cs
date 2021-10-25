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

        public string ToPrefixString() {
            return root == null ? "NIL" : ToPrefixString(root);
        }

        public string ToPrefixString(BinaryNode<T> node) {
            string s = "[ " + node.data + " ";
            s += node.left != null ? ToPrefixString(node.left) + " " : "NIL ";
            s += node.right != null ? ToPrefixString(node.right) + " " : "NIL ";
            return s + "]";
        }

        public string ToInfixString() {
            return root == null ? "NIL" : ToInfixString(root);
        }
        public string ToInfixString(BinaryNode<T> node) {
            string s = "[ ";
            s += node.left != null ? ToInfixString(node.left) + " " : "NIL ";
            s += node.data + " ";
            s += node.right != null ? ToInfixString(node.right) + " " : "NIL ";
            return s + "]";
        }
        public string ToPostfixString()
        {
            return root == null ? "NIL" : ToPostfixString(root);
        }
        public string ToPostfixString(BinaryNode<T> node) {
            string s = "[ ";
            s += node.left != null ? ToPostfixString(node.left) + " " : "NIL ";
            s += node.right != null ? ToPostfixString(node.right) + " " : "NIL ";
            s += node.data + " ";
            return s + "]";
        }

        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public int NumberOfLeaves() {
            return root != null ? NumberOfLeaves(root) : 0;
        }

        public int NumberOfLeaves(BinaryNode<T> node) {
            if (node == null) {
                return 0;
            }

            if (node.left == null && node.right == null) {
                return 1;
            }
            return 0 + NumberOfLeaves(node.left) + NumberOfLeaves(node.right);
        }

        public int NumberOfNodesWithOneChild()
        {
            return root != null ? NumberOfNodesWithOneChild(root) : 0;
        }
        public int NumberOfNodesWithOneChild(BinaryNode<T> node) {
            if (node == null) {
                return 0;
            }

            if (node.left == null && node.right != null) {
                return 1;
            }

            if (node.left != null && node.right == null) {
                return 1;
            }
            return 0 + NumberOfNodesWithOneChild(node.left) + NumberOfNodesWithOneChild(node.right);
        }
        public int NumberOfNodesWithTwoChildren()
        {
            return root != null ? NumberOfNodesWithTwoChildren(root) : 0;
        }
        public int NumberOfNodesWithTwoChildren(BinaryNode<T> node) {
            int counter = 0;

            if (node == null) {
                return 0;
            }

            if (node.left != null && node.right != null) {
                counter++;
            }
            return 0 + counter + NumberOfNodesWithTwoChildren(node.left) + NumberOfNodesWithTwoChildren(node.right);
        }
    }
}