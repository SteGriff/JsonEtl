using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEtl
{
    class Program
    {
        static void Main(string[] args)
        {
            var etl = new Etl("C:\\Users\\stephen\\OneDrive\\Documents\\Web\\SGUK\\SGN\\upblog\\posts");
            etl.Extract();

            foreach(var line in etl.Rows)
            {
                Console.WriteLine(line);
            }

            Console.ReadLine();

        }
    }
}
