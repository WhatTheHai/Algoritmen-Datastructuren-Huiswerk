using System;

namespace AD
{
    public partial class FirstChildNextSibling<T> : IFirstChildNextSibling<T>
    {
        public FirstChildNextSiblingNode<T> root;

        public IFirstChildNextSiblingNode<T> GetRoot()
        {
            return root;
        }

        public int Size() {
            int size = 0;
            if (root != null) {
                size = Size(root);
            }

            return size;
        }

        public int Size(FirstChildNextSiblingNode<T> node) {
            int size = 0;

            if (node.firstChild != null) {
                size += Size(node.firstChild);
            }

            if (node.nextSibling != null) {
                size += Size(node.nextSibling);
            }
            size++;
            return size;
        }

        public void PrintPreOrder()
        {
            if (root != null) {
                Console.Write(PrintPreOrder(root, ""));
            }
        }

        public string PrintPreOrder(FirstChildNextSiblingNode<T> node, string spaces) {
            string s = spaces + node.data + "\n";

            if (node.firstChild != null) {
                s += PrintPreOrder(node.firstChild, spaces + "   ");
            }

            if (node.nextSibling != null) {
                s += PrintPreOrder(node.nextSibling, spaces);
            }

            return s;
        }

        public override string ToString() {
            return root != null ? ToString(root) : "NIL";
        }

        public string ToString(FirstChildNextSiblingNode<T> node) {
            string s = node.data.ToString();

            if (node.firstChild != null) {
                s += ",FC(" + ToString(node.firstChild) + ")";
            }
            if (node.nextSibling != null) {
                s += ",NS(" + ToString(node.nextSibling) + ")";
            }
            return s;
        }

    }
}