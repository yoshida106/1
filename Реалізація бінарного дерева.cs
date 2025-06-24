public class BinaryTreeNode
{
    public int Value { get; set; }
    public BinaryTreeNode Left { get; set; }
    public BinaryTreeNode Right { get; set; }
    
    public BinaryTreeNode(int value)
    {
        Value = value;
    }
}

public class BinaryTree
{
    public BinaryTreeNode Root { get; private set; }
    
    public void Add(int value)
    {
        Root = AddRecursive(Root, value);
    }
    
    private BinaryTreeNode AddRecursive(BinaryTreeNode node, int value)
    {
        if (node == null)
        {
            return new BinaryTreeNode(value);
        }
        
        if (value < node.Value)
        {
            node.Left = AddRecursive(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = AddRecursive(node.Right, value);
        }
        
        return node;
    }
    
    public bool Contains(int value)
    {
        return ContainsRecursive(Root, value);
    }
    
    private bool ContainsRecursive(BinaryTreeNode node, int value)
    {
        if (node == null)
        {
            return false;
        }
        
        if (value == node.Value)
        {
            return true;
        }
        
        return value < node.Value 
            ? ContainsRecursive(node.Left, value) 
            : ContainsRecursive(node.Right, value);
    }
    
    public void Remove(int value)
    {
        Root = RemoveRecursive(Root, value);
    }
    
    private BinaryTreeNode RemoveRecursive(BinaryTreeNode node, int value)
    {
        if (node == null)
        {
            return null;
        }
        
        if (value == node.Value)
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            if (node.Right == null)
            {
                return node.Left;
            }
            
            node.Value = MinValue(node.Right);
            node.Right = RemoveRecursive(node.Right, node.Value);
        }
        else if (value < node.Value)
        {
            node.Left = RemoveRecursive(node.Left, value);
        }
        else
        {
            node.Right = RemoveRecursive(node.Right, value);
        }
        
        return node;
    }
    
    private int MinValue(BinaryTreeNode node)
    {
        int minValue = node.Value;
        while (node.Left != null)
        {
            minValue = node.Left.Value;
            node = node.Left;
        }
        return minValue;
    }
    
    public void TraverseInOrder(BinaryTreeNode node, Action<BinaryTreeNode> action)
    {
        if (node != null)
        {
            TraverseInOrder(node.Left, action);
            action(node);
            TraverseInOrder(node.Right, action);
        }
    }
}