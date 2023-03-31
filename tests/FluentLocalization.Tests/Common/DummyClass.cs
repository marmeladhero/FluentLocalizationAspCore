namespace FluentLocalization.Tests.Common;

public class DummyClass
{
    public int Id { get; set; }
    public string Property { get; set; } = null!;
    public string? Property1 { get; set; }
    
    public Nested NestedClass { get; set; } = null!;
    
    public List<Nested> NestedClasses { get; set; }
    
    public class Nested
    {
        public string Property2 { get; set; } = null!;
        public NestedNested NestedNestedClass { get; set; } = null!;
        public class NestedNested
        {
            public string Property3 { get; set; } = null!;
        }
    }
}