using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonEtl
{
    public class Etl
    {
        private string _path;
        public List<string> Rows { get; set; }
        public List<TransformationResult> TransformedRows { get; set; }
        
        public Etl(string path)
        {
            _path = path;

            Rows = new List<string>();
            TransformedRows = new List<TransformationResult>();
        }

        public void Extract(string filter, bool recursive)
        {
            var files = Directory.EnumerateFiles(_path, filter, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

            int recordNum = 1;
            int datumNum = 1;
            foreach (var f in files)
            {
                //Console.WriteLine("Extract " + f);

                string content = File.ReadAllText(f);

                //Presume every JSON is a flat store of keys->values for now
                //TODO Allow extraction of nested data
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);

                foreach (var d in data)
                {
                    string csvLine = string.Format("{0},{1},{2},{3}", datumNum, recordNum, d.Key, d.Value);
                    Rows.Add(csvLine);

                    datumNum += 1;
                }

                recordNum += 1;
            }
        }

        public void Transform(Func<string, TransformationResult> Transformer)
        {
            foreach(var d in Rows)
            {
                var result = Transformer(d);
                if (result.Include)
                {
                    TransformedRows.Add(result);
                }
            }
        }

    }
}
