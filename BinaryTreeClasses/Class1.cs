



using System.Transactions;

namespace BinaryTreeClasses;

public class BinaryTree
{

    TreeNode _root;
    public BinaryTree()
    {
        _root = null;
    }
    public void Add(int v)
    {
        TreeNode newNode = new TreeNode(v);

        TreeNode current = _root;
        
        while (current !=null)
        {
            
        }
    }

    public int Count()
    {
        throw new NotImplementedException();
    }
}


public class TreeNode
{
    public int _value;
    public TreeNode _left;
    public TreeNode _right;

    internal TreeNode(int v)
    {
        _value = v;
        _left = null;
        _right = null;
    }

}