public class Heap<T>
{
    List<T> _data = new List<T>();

    public T Root => _data[0];
    public T LastNode => _data[_data.Count - 1];

    public int LeftChildIndex(int index) => index * 2 + 1;
    public int RightChildIndex(int index) => index * 2 + 2;
    public int ParentIndex(int index) => (index - 1) / 2;

    public bool IsEmpty => _data.Count == 0;

    public void Insert(T value)
    {
        _data.Add(value);

        var insertedIndex = _data.Count - 1;
        var parentIndex = ParentIndex(insertedIndex);

        while(parentIndex >= 0)
        {
            var parentValue = _data[parentIndex];
            if (Comparer<T>.Default.Compare(value, parentValue) > 0)
            {
                _data[parentIndex] = value;
                _data[insertedIndex] = parentValue;
                insertedIndex = parentIndex;
                parentIndex = ParentIndex(insertedIndex);
            }
            else
            {
                break;
            }
        }
    }

    public T Delete()
    {
        var toDelete = _data[0];

        _data[0] = _data[_data.Count - 1];

        var currentIndex = 0;

        do
        {
            var leftIndex = LeftChildIndex(currentIndex);
            var rightIndex = RightChildIndex(currentIndex);

            var leftValue = leftIndex >= _data.Count ? default(T) : _data[leftIndex];
            var rightValue = rightIndex >= _data.Count ? default(T) : _data[rightIndex];

            var (maxValue, maxIndex) = Comparer<T>.Default.Compare(leftValue, rightValue) < 0 ?
                (rightValue, rightIndex) : (leftValue, leftIndex);

            if (Comparer<T>.Default.Compare(_data[currentIndex], maxValue) >= 0)
            {
                break;
            }

            var temp = _data[maxIndex];
            _data[maxIndex] = _data[_data.Count - 1];
            _data[currentIndex] = temp;
            currentIndex = maxIndex;
        }
        while(true);

        _data.RemoveAt(_data.Count - 1);

        return toDelete;
    }

    public override string ToString() => string.Join(",", _data);
}