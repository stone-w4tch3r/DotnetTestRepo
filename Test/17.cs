#if false
using System.Diagnostics.CodeAnalysis;

    var elements = GenerateElements();
    elements.ForEach(Console.WriteLine);
    Console.WriteLine();
    var sorted = SortElements(elements);
    sorted.ToList().ForEach(Console.WriteLine);
    
    [SuppressMessage("ReSharper", "AccessToModifiedClosure")]
    static IEnumerable<Element> SortElements(List<Element> elements)
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
    
    
    
    
    
    static List<Element> GenerateElements()
    {
        var rnd = new Rnd();
        var elements = new List<Element>();
        var n = rnd.Next(10, 30);
        var usedDestIds = new HashSet<int>();
    
        for (var i = 1; i <= n; i++)
        {
            var element = new Element { Id = i };
            if (rnd.NextBool())
            {
                int dest;
                do
                {
                    dest = rnd.Next(1, n + 1);
                } while (dest == i || usedDestIds.Contains(dest));
                element.DestId = dest;
                usedDestIds.Add(dest);
            }
            elements.Add(element);
        }
    
        return elements;
    }
    
    public class Element
    {
        public int Id;
        public int? DestId;
    
        public override string ToString()
        {
            return $"Id: {Id}, DestId: {DestId}";
        }
    }
    
    public class Rnd : Random
    {
        public Rnd() : base() { }
        public Rnd(int seed) : base(seed) { }
        public bool NextBool() { return Next(2) == 0; }
    }
    
    
#endif