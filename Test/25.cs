#if false
using System.Collections;
using System.Reactive.Disposables;

Console.WriteLine();

var cd = new CompositeDisposable();

Console.WriteLine(cd.Count);

var cdAsCollection = (ICollection<IDisposable>)cd;

var d1 = Disposable.Create(() => Console.WriteLine("d1"));

cd.Add(d1);

Console.WriteLine(cd.Count);
#endif