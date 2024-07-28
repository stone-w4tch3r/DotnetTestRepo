#if false

Console.WriteLine("Start");
return;

int[] Distinct(int[] src)
{
    var result = new List<int>(capacity: src.Length);
    var hashed = new HashSet<int>();

    foreach (var i in src)
    {
        if (hashed.Add(i))
        {
            result.Add(i);
        }
    }

    return result.ToArray();
}

IEnumerable<T> FilterLast<T>(IEnumerable<T> source, int n)
{
    var buffer = new Queue<T>(n);
    foreach (var item in source)
    {
        if (buffer.Count == n)
            yield return buffer.Dequeue();
        buffer.Enqueue(item);
    }
}

# endif