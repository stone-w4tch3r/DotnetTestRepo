#if false
    using System.Diagnostics.CodeAnalysis;
    
    Console.WriteLine("x");
    
    var class1 = new Class1();
    Console.WriteLine(class1.Name);
    
    public class Class1
    {
        private string _surName;
        public string Name { get; set; }
    
        public string City { get; set; }
    
        public Class1()
        {
            Init1();
            Init2(out _surName);
            Init3();
        }
    
        [MemberNotNull(nameof(Name))]
        private void Init1()
        {
            Name = "John";
        }
    
        private static void Init2(out string surName)
        {
            surName = "Doe";
        }
    
        [MemberNotNull(nameof(City))]
        private void Init3()
        {
            City = null;
        } //warning here
    }
#endif