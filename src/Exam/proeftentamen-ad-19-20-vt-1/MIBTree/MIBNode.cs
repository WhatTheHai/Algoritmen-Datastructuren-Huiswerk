using System;

namespace AD
{
    public class MIBNode : IComparable<MIBNode>
    {
        public string oid;
        public string name;

        public MIBNode(string oid, string name)
        {
            this.oid = oid;
            this.name = name;
        }

        public int CompareTo(MIBNode other)
        {
            return oid.CompareTo(other.oid);
        }
    }
}
