public class DoublyNode<T>
{
    public T Value { get; set; }
    public DoublyNode<T>? Next { get; set; }
    public DoublyNode<T>? Prev { get; set; }

    public DoublyNode(T value)
    {
        Value = value;
    }
}
public class DoublyLinkedList<T>
{
    public DoublyNode<T>? First { get; set; }
    public DoublyNode<T>? Last { get; set; }

    public void InsertAtEnd(T value)
    {
        var newNode = new DoublyNode<T>(value);

        if (First == null)
        {
            First = newNode;
            Last = newNode;
        }
        else
        {
            if (Last != null)
            {
                Last.Next = newNode;
                newNode.Prev = Last;
            }
            Last = newNode;
        }
    }

    public DoublyNode<T> RemoveFromFront()
    {
        if (First == null)
        {
            throw new InvalidOperationException("Empty");
        }
        
        var nodeToRemove = First;
        First = nodeToRemove.Next;
        return nodeToRemove;
    }

    public override string? ToString()
    {
        var current = First;
        var print = "";
        while(current != null)
        {
            print += current.Value + " -> ";
            current = current.Next;
        }
        print += " <NULL> ";
        return print;
    }
}