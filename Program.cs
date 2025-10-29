using System;

// Namespace definido como TimSort
namespace TimSort
{
    class Program
    {
        static void Main()
        {
            // Array inicial para teste
            int[] array = { -11, 12, -42, 0, 1, 90, 68, 6, -9 };

            Console.WriteLine("Array antes da ordenação (TimSort):");
            Console.WriteLine(string.Join(", ", array));

            // Chamada para o método Sort da classe TimSort
            TimSort.Sort(array);

            Console.WriteLine("Array após a ordenação (TimSort):");
            Console.WriteLine(string.Join(", ", array));

            // Fim do programa principal
        }
    } // Fim da classe Program
} // Fim do namespace TimSort