public class MyLinkedList
{
    public MyLinkedItem? First { get; private set; }
    
    public MyLinkedItem? Last { get; private set; }
    
    private int count;

    public MyLinkedList()
    {
        First = null;
        Last = null;
        count = 0;
    }

    public int Count() => count;

    public void AddLast(int value)
    {
        var newNode = new MyLinkedItem(value);
        
        if (Last == null)
        {
            First = newNode;
            Last = newNode;
        }
        else
        {
            Last.Next = newNode;
            newNode.Prev = Last;
            Last = newNode;
        }
        
        count++;
    }

    public void AddFirst(int value)
    {
        var newNode = new MyLinkedItem(value);
        
        if (First == null)
        {
            First = newNode;
            Last = newNode;
        }
        else
        {
            newNode.Next = First;
            First.Prev = newNode;
            First = newNode;
        }
        
        count++;
    }

    public MyLinkedItem? Find(int value)
    {
        var current = First;
        while (current != null)
        {
            if (current.Value == value)
                return current;
            current = current.Next;
        }
        return null;
    }

    public void Clear()
    {
        First = null;
        Last = null;
        count = 0;
    }

    public void AddBefore(MyLinkedItem node, int value)
    {
        if (node == null)
            throw new ArgumentNullException(nameof(node));
        
        if (node == First)
        {
            AddFirst(value);
            return;
        }
        
        var newNode = new MyLinkedItem(value);
        newNode.Prev = node.Prev;
        newNode.Next = node;
        node.Prev!.Next = newNode;
        node.Prev = newNode;
        
        count++;
    }

    public void AddAfter(MyLinkedItem node, int value)
    {
        if (node == null)
            throw new ArgumentNullException(nameof(node));
        
        if (node == Last)
        {
            AddLast(value);
            return;
        }
        
        var newNode = new MyLinkedItem(value);
        newNode.Prev = node;
        newNode.Next = node.Next;
        node.Next!.Prev = newNode;
        node.Next = newNode;
        
        count++;
    }

    public void Delete(int value)
    {
        var nodeToDelete = Find(value);
        if (nodeToDelete != null)
        {
            Delete(nodeToDelete);
        }
    }

    public void Delete(MyLinkedItem node)
    {
        if (node == null)
            throw new ArgumentNullException(nameof(node));
        
        if (node.Prev != null)
            node.Prev.Next = node.Next;
        else
            First = node.Next;
        
        if (node.Next != null)
            node.Next.Prev = node.Prev;
        else
            Last = node.Prev;
        
        count--;
    }

    public void PrintList()
    {
        var current = First;
        while (current != null)
        {
            Console.Write($"{current.Value} ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}