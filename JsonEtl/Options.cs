using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JsonEtl
{
    class Options
    {
        [Option('p', "path", Required = true, HelpText = "Path to get files from.")]
        public string path { get; set; }

        [Option('f', "filter", DefaultValue = "*.json", HelpText = "Filter for files to include.")]
        public string filter { get; set; }

        [Option('r', "recursive", DefaultValue = false, HelpText = "Get files recursively rather than using the top directory only.")]
        public bool recursive { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
