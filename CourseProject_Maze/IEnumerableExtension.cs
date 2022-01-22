using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_Maze
{
    public static class IEnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }

        public static void Shuffle<T>(this List<T> source)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            for (int i = source.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                T tmp = source[j];
                source[j] = source[i];
                source[i] = tmp;
            }
        }
    }
}
