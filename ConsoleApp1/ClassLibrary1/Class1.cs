namespace ClassLibrary1
{
    public class Class1
    {
        public void Execute()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            Console.WriteLine("Done!!!!!");

        }
    }
}