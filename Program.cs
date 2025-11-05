using System;

namespace TimSort
{
    class Program
    {
        static void Main()
        {
            int[] array = { -11, 12, -42, 0, 1, 90, 68, 6, -9 };

            Console.WriteLine("Array de inteiros antes da ordenação (TimSort):");
            Console.WriteLine(string.Join(", ", array));

            TimSort.Sort(array);

            Console.WriteLine("Array de inteiros após da ordenação (TimSort):");
            Console.WriteLine(string.Join(", ", array));


            Console.WriteLine("\n--- Exemplo com Strings ---");

        string[] nomes = { "Maria", "José", "Ana", "Carlos", "Zé", "Bruno", "Beatriz", "Alexandre", "Luiz" };

            Console.WriteLine("Array de nomes antes da ordenação:");
            Console.WriteLine(string.Join(", ", nomes));

            TimSort.Sort(nomes);

            Console.WriteLine("Array de nomes após a ordenação:");
            Console.WriteLine(string.Join(", ", nomes));
        }
    }
}
