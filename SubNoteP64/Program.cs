namespace SubNoteP64
{
    internal class Program
    {
        static int[] sales =
            {
                200000,250000,400000,10,20,30,
                40,70,80,90,300000
            }; 
        
        static void Main(string[] args)
        {
            int sum = 0;
            var m = 0;
            while (m< sales.Length)
            {
                sum+= sales[m];
                m++;
            }
            Console.WriteLine($"合計は{sum}");

        }
    }
}
