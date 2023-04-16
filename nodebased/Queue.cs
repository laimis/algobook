public class Queue<T>
{
    private DoublyLinkedList<T> _storage = new DoublyLinkedList<T>();

    public void Enqueue(T value)
    {
        _storage.InsertAtEnd(value);
    }

    public T Dequeue()
    {
        var node = _storage.RemoveFromFront();
        return node.Value;
    }

    public T? Peek()
    {
        if (_storage.First == null)
        {
            return default(T);
        }

        return _storage.First.Value;
    }

    public bool Empty => _storage.First == null;
}