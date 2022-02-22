using System.Security.Cryptography.X509Certificates;

namespace FirstExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Podaj wartość a=");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj wartość b=");
            b = int.Parse(Console.ReadLine());

            var result = SwapValues(a, b);
            
            Console.WriteLine($"Zamienione wartości: a = {result.Item1} ; b = {result.Item2}");
            Console.ReadKey();

        }

        

         public static  Tuple <int,int> SwapValues(int a, int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
            var tuple = new Tuple<int, int>(a, b);
            return tuple;

        }
    }
}
