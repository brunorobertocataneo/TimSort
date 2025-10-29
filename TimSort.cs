using System;

// Namespace alterado para TimSort
namespace TimSort
{
    // Classe renomeada para TimSort
    public static class TimSort
    {
        // Define um tamanho de bloco para o Insertion Sort inicial.
        // Em TimSort real, isso (minrun) é calculado dinamicamente.
        private const int RUN_SIZE = 32;

        /// <summary>
        /// Ordena um array usando uma versão simplificada e conceitual do TimSort.
        /// </summary>
        /// <typeparam name="T">O tipo dos elementos no array. Deve implementar IComparable.</typeparam>
        /// <param name="array">O array a ser ordenado.</param>
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            int n = array.Length;
            if (array == null || n < 2)
            {
                return; // Nada a ordenar
            }

            // Passo 1: Ordenar subarrays (runs) de tamanho RUN_SIZE usando Insertion Sort.
            for (int i = 0; i < n; i += RUN_SIZE)
            {
                int left = i;
                int right = Math.Min(i + RUN_SIZE - 1, n - 1);
                InsertionSortForTimSort(array, left, right);
            }

            // Passo 2: Mesclar (Merge) os runs ordenados.
            // Começa mesclando runs de tamanho RUN_SIZE, depois 2*RUN_SIZE, 4*RUN_SIZE, etc.
            for (int size = RUN_SIZE; size < n; size = 2 * size)
            {
                // Para cada par de runs adjacentes de tamanho 'size'
                for (int left = 0; left < n; left += 2 * size)
                {
                    // Encontra o ponto médio e o final do segundo run
                    int mid = Math.Min(left + size - 1, n - 1);
                    int right = Math.Min(left + 2 * size - 1, n - 1);

                    // Se mid < right, significa que há um segundo run para mesclar
                    if (mid < right)
                    {
                        MergeForTimSort(array, left, mid, right);
                    }
                }
            }
        }

        /// <summary>
        /// Função auxiliar: Insertion Sort para um subarray.
        /// </summary>
        private static void InsertionSortForTimSort<T>(T[] array, int left, int right) where T : IComparable<T>
        {
            for (int i = left + 1; i <= right; i++)
            {
                T key = array[i];
                int j = i - 1;
                // Move elementos de array[left..i-1] que são maiores que key
                // para uma posição à frente da sua posição atual
                while (j >= left && array[j].CompareTo(key) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }

        /// <summary>
        /// Função auxiliar: Merge (mesclar) dois subarrays ordenados.
        /// array[left..mid] e array[mid+1..right]
        /// </summary>
        private static void MergeForTimSort<T>(T[] array, int left, int mid, int right) where T : IComparable<T>
        {
            // Tamanhos dos subarrays temporários
            int len1 = mid - left + 1;
            int len2 = right - mid;

            // Cria arrays temporários
            T[] L = new T[len1];
            T[] R = new T[len2];

            // Copia dados para os arrays temporários
            Array.Copy(array, left, L, 0, len1);
            Array.Copy(array, mid + 1, R, 0, len2);

            // Índices para os subarrays L, R e para o array principal 'array'
            int i = 0, j = 0;
            int k = left;

            // Mescla os arrays temporários de volta no array principal
            while (i < len1 && j < len2)
            {
                // Usa <= para manter a estabilidade da ordenação
                if (L[i].CompareTo(R[j]) <= 0)
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copia os elementos restantes de L[], se houver
            while (i < len1)
            {
                array[k] = L[i];
                i++;
                k++;
            }

            // Copia os elementos restantes de R[], se houver
            while (j < len2)
            {
                array[k] = R[j];
                j++;
                k++;
            }
        }
    } // Fim da classe TimSort
} // Fim do namespace TimSort