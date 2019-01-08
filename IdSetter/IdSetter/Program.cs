namespace IdSetter
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Entity1();

            x.SetId(3);

            var y = new Entity1();

            y.SetId(4);
        }
    }
}
