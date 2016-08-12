using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEtl
{
    class Program
    {
        static string path;
        static string filter;
        static bool recursive;

        static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                path = options.path;
                filter = options.filter;
                recursive = options.recursive;
            }
            else
            {
                Console.ReadKey(); // IMPORTANT: Remove when code finished
                Environment.Exit(0);
            }

            var etl = new Etl(path);
            etl.Extract(filter, recursive);

            //foreach (var line in etl.Rows)
            //{
            //    Console.WriteLine(line);
            //}

            //Console.ReadLine();

            etl.Transform(MyTransformer);

            foreach (var line in etl.TransformedRows)
            {
                Console.WriteLine(line.Data);
            }

            Console.ReadLine();

        }

        public static TransformationResult MyTransformer(string data)
        {
            var fields = data.Split(new []{','});

            string outData = fields[1] + ",";
            bool include = false;

            if (fields[2] == "created")
            {
                include = true;
                
                outData += UtsToDateTime(fields[3]);
            }

            var result = new TransformationResult()
            {
                Data = outData,
                Include = include
            };

            return result;
        }

        public static DateTime UtsToDateTime(string unixTimeStampString)
        {
            double uts = double.Parse(unixTimeStampString);

            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dt = dt.AddSeconds(uts);

            return dt;
        }

    }
}
