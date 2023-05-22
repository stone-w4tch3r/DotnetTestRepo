Console.WriteLine();

var dm = new DerivedMeeting();
dm.Speaker.Speak();
dm.Speaker.Name = "Bob";
dm.Speaker.Age = 43;
dm.Speaker.Speak();
var bm = (BaseMeeting)dm;
bm.Speaker.Speak();

class BaseSpeaker
{
    public string Name { get; set; } = "Jim";
    public virtual void Speak() => Console.WriteLine($"Hello, I'm {Name}");
}

class DerivedSpeaker : BaseSpeaker
{
    public int Age { get; set; } = 42;
    public override void Speak() => Console.WriteLine($"Hello, I'm {Name} and I'm {Age} years old");
}

class BaseMeeting
{
    public BaseSpeaker Speaker { get; } = new ();
}

class DerivedMeeting : BaseMeeting
{
    public new DerivedSpeaker Speaker { get; } = new ();
}