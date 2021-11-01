using System.Linq;

namespace AD
{
    public class MIBTree : BinarySearchTree<MIBNode>
    {
        public MIBTree()
        {
            Insert(new MIBNode("1.3.6.1.4.1.9", "cisco"));
            Insert(new MIBNode("1.3.6.1.1.1.1", "system"));
            Insert(new MIBNode("1.3.6", "dod"));
            Insert(new MIBNode("1.3.6.1.1.1.4", "ip"));
            Insert(new MIBNode("1.3.6.1.3", "experimental"));
            Insert(new MIBNode("1.3.6.1.4.1", "enterprise"));
            Insert(new MIBNode("1.3.6.1.1.1.2", "interfaces"));
            Insert(new MIBNode("1.3.6.1.1", "directory"));
            Insert(new MIBNode("1.3", "org"));
            Insert(new MIBNode("1.3.6.1.4.1.2636", "juniperMIB"));
            Insert(new MIBNode("1.3.6.1.4.1.311", "microsoft"));
            Insert(new MIBNode("1.3.6.1", "internet"));
            Insert(new MIBNode("1", "iso"));
            Insert(new MIBNode("1.3.6.1.4", "private"));
            Insert(new MIBNode("1.3.6.1.1.1", "mib-2"));
            Insert(new MIBNode("1.3.6.1.2", "mgmt"));
        }

        public MIBNode FindNode(string oid) {
            return FindNode(this.root, oid);
        }

        private MIBNode FindNode(BinaryNode<MIBNode> node, string oid) {
            MIBNode found = null;

            if (node.data.oid.Equals(oid)) {
                found = node.data;
            }

            if (found == null && node.left != null) {
                found = FindNode(node.left, oid);
            }
            
            if (found == null && node.right != null) {
                found = FindNode(node.right, oid);
            }

            return found;
        }

        public bool AllNodesAvailable(string oid)
        {
            if (FindNode(oid) != null) {
                string[] split = oid.Split('.');
                int lengthOfSplit = oid.Length - (split.Last().Length + 1);
                if (lengthOfSplit >= 0) {
                    //Easier way of saying substring
                    string splitString = oid[..lengthOfSplit];
                    return AllNodesAvailable(splitString);
                }
                return true;
            }

            return false;
        }
    }
}
