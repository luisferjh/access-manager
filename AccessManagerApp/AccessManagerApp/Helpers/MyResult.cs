namespace AccessManagerApp.Helpers
{
    public class MyResult
    {
        public int Input { get; set; }
        public string Value { get; set; }
    }

    public class SomeGenericClass<T>
    {
        public T Value { get; set; }

        public static implicit operator
        SomeGenericClass<T>(T value)
        {
            return new SomeGenericClass<T>
            {
                Value = value
            };
        }
    }

    public class Test {

        public void tryconverted() 
        {
            string value = "test";
            SomeGenericClass<string> result = value;
          
        } 

    }
}
