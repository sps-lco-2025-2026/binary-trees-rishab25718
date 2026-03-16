using BinaryTreeClasses;

namespace BinaryTreeTests;

[TestClass]
public sealed class Test1
{
    
    [TestMethod]
    public void TestMethod1()
    {
        BinaryTree bTree = new();
        bTree.Add(5);
        Assert.AreEqual(1,bTree.Count());
    }
}
