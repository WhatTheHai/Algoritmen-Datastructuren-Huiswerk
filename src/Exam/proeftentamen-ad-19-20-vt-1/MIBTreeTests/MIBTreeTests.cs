using NUnit.Framework;

namespace AD
{
    [TestFixture]
    public partial class MIBTreeTests
    {
        [Test]
        public void Ex2a_FindNodeSuccess()
        {
            // Arrange
            MIBTree tree = new MIBTree();

            // Assert
            Assert.AreEqual("1.3.6.1", tree.FindNode("1.3.6.1").oid);
            Assert.AreEqual("internet", tree.FindNode("1.3.6.1").name);
        }
        [Test]
        public void Ex2a_FindNodeFail()
        {
            // Arrange
            MIBTree tree = new MIBTree();

            // Assert
            Assert.AreEqual(null, tree.FindNode("1.3.6.2"));
        }
        [Test]
        public void Ex2b_AllNodesAvailableSuccess()
        {
            // Arrange
            MIBTree tree = new MIBTree();

            // Assert
            Assert.AreEqual(true, tree.AllNodesAvailable("1.3.6.1.4.1.311"));
        }
        [Test]
        public void Ex2b_AllNodesAvailableFail()
        {
            // Arrange
            MIBTree tree = new MIBTree();

            // Assert
            Assert.AreEqual(false, tree.AllNodesAvailable("1.3.6.1.4.1.311.1"));
        }
    }
}
