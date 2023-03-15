using System.Collections.Immutable;

#if true
// ReSharper disable AccessToModifiedClosure
var elements = new List<Element>
{
    new() { SourceId = 1, DestId = 3 },
    new() { SourceId = 2, DestId = null },
    new() { SourceId = 3, DestId = null },
    new() { SourceId = 4, DestId = 5 },
    new() { SourceId = 5, DestId = 2 },
    new() { SourceId = 6, DestId = 9 },
    new() { SourceId = 7, DestId = 10 },
    new() { SourceId = 8, DestId = null },
    new() { SourceId = 9, DestId = null },
    new() { SourceId = 10, DestId = null }
}.ToImmutableList();

var result = RearrangeElements(elements);
result.ToList().ForEach(Console.WriteLine);
Console.WriteLine();
var result2 = new SortedSet<Element>(elements, new ElementComparer());
result2.ToList().ForEach(Console.WriteLine);
Console.WriteLine();
var result3 = new SortedSet<Element>(elements, new ElementComparer2());
result3.ToList().ForEach(Console.WriteLine);
Console.WriteLine();
var result4 = elements.Sort(new ElementComparer());
result4.ForEach(Console.WriteLine);
Console.WriteLine();
elements.ForEach(Console.WriteLine);


static IEnumerable<Element> RearrangeElements(IEnumerable<Element> source)
{
    var result = new List<Element>();
    var sourceList = source.ToList();
    var currentElement = sourceList.FirstOrDefault();
    
    while (currentElement is not null)
    {
        result.Add(currentElement);
        sourceList.Remove(currentElement);
        currentElement = sourceList.Find(e => e.SourceId == currentElement.DestId)
                         ?? sourceList.FirstOrDefault();
    }
    
    return result;
}

public class ElementComparer : IComparer<Element>
{
    public int Compare(Element? x, Element? y)
    {
        if (x == null || y == null)
            return 0;

        if (x.SourceId == y.DestId)
            return -1;

        if (x.DestId == y.SourceId)
            return 1;

        return 0;
    }
}

public class ElementComparer2 : IComparer<Element>
{
    public int Compare(Element? x, Element? y) => 
        (x, y) switch
        {
            (null, _) => 0,
            (_, null) => 0,
            _ when x.SourceId == y.DestId => -1,
            _ when x.DestId == y.SourceId => 1,
            _ => 0
        };
}



public class Element
{
    public int SourceId { get; init; }
    public int? DestId { get; init; }
    
    public override string ToString() => $"{SourceId} -> {DestId}";
}
#endif