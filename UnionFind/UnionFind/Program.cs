using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string appDirectory = Path.Combine(Environment.CurrentDirectory, "largeUF.txt");
                Console.WriteLine(appDirectory);
                var streamReader = new StreamReader(File.OpenRead(appDirectory));
                var noOfNodes = Convert.ToInt32(streamReader.ReadLine());

                var uf = new UF_QuickUnion(noOfNodes);
                var conn = streamReader.ReadLine();

                while (!string.IsNullOrEmpty(conn))
                {
                    var split = conn.Split(' ');
                    var p = Convert.ToInt32(split[0]);
                    var q = Convert.ToInt32(split[1]);

                    uf.Union(p, q);
                    conn = streamReader.ReadLine();
                }
                streamReader.Close();
                var areConnected = uf.Connected(7, 8);
                Console.WriteLine(areConnected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.Read();
        }
    }
}
