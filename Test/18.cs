#if false
// ReSharper disable AccessToModifiedClosure
var elements = new List<Element>
{
    new() { Id = 1, DestId = 3 },
    new() { Id = 2, DestId = null },
    new() { Id = 3, DestId = null },
    new() { Id = 4, DestId = 5 },
    new() { Id = 5, DestId = 2 },
    new() { Id = 6, DestId = 9 },
    new() { Id = 7, DestId = 10 },
    new() { Id = 8, DestId = null },
    new() { Id = 9, DestId = null },
    new() { Id = 10, DestId = null }
};

var result = RearrangeElements(elements);
result.ToList().ForEach(Console.WriteLine);


static IEnumerable<Element> RearrangeElements(List<Element> elements)
{
    var result = new List<Element>();
    var currentElement = elements.FirstOrDefault();
    
    while (currentElement is not null)
    {
        result.Add(currentElement);
        elements.Remove(currentElement);
        currentElement = elements.Find(e => e.Id == currentElement.DestId)
                         ?? elements.FirstOrDefault();
    }
    
    return result;
}

public class Element
{
    public int Id { get; init; }
    public int? DestId { get; init; }
    
    public override string ToString() => $"{Id} -> {DestId}";
}
#endif