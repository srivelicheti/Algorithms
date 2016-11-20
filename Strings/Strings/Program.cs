using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter data");
           
        }

        string SortString(string input)
        {
            var count = new int[256];
            foreach (var c in input)
            {
                var index = ToIndex(c);
                count[index + 1]++;
            }
            for (int i = 1; i < 255; i++)
            {
                count[i + 1] = count[i] + count[i + 1];
            }
            var aux = new char[input.Length];

            foreach (var c in input)
            {
                var index = ToIndex(c);
                var pos = count[index];
                aux[pos] = c;
                count[index]++;
            }

            return string.Join("", aux);
        }

        static int ToIndex(char a)
        {
            return (int) a;
        }

        static string[] SortArrayOfStrings(string[] input, int start, int end, int charIndexToSortOn)
        {

            var aux = new string[end - start + 1];

            var count = new int[256];
            var bkp = new int[256];

            for (int i = start; i <= end; i++)
            {
                var countIndex = ToIndex(input[i][charIndexToSortOn]) + 1;
                count[countIndex]++;
                bkp[countIndex - 1]++;

            }

            for (int i = 1; i < 255; i++)
            {
                count[i + 1] = count[i] + count[i + 1];
            }

            for (int i = start; i <= end; i++)
            {
                var countIndex = ToIndex(input[i][charIndexToSortOn]) + 1;
                aux[count[countIndex]] = input[i];
                count[countIndex]++;
            }
            charIndexToSortOn++;
            int recStart = 0;
            foreach (var i in bkp)
            {
                
                if (i > 1)
                {
                    var tempStart = recStart + start;
                    var tempEnd = tempStart + i - 1;

                    SortArrayOfStrings(input, tempStart, tempEnd, charIndexToSortOn);
                }

                recStart = recStart + i;
            }
            
            throw new NotImplementedException();
        }
    }
}
