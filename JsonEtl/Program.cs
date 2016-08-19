using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JsonEtl
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (!CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Environment.Exit(0);
            }

            bool print = (options.outfile == null);

            //Extract
            var etl = new Etl(options.path);
            etl.Extract(options.filter, options.recursive);

            var sb = new StringBuilder();

            // (Echo)
            if (options.echo)
            { 
                foreach (var line in etl.Rows)
                {
                    if (print)
                    {
                        Console.WriteLine(line);
                    }
                    else
                    {
                        sb.AppendLine(line);
                    }
                }
            }

            //Transform
            etl.Transform(MyTransformer);

            // Output/Load I suppose

            foreach (TransformationResult resultLine in etl.TransformedRows)
            {
                if (print)
                {
                    Console.WriteLine(resultLine.Data);
                }
                else
                {
                    sb.AppendLine(resultLine.Data);
                }
            }

            if (!print)
            {
                string output = sb.ToString();

                try
                {
                    File.WriteAllText(options.outfile, output);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

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
