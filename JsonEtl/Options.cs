using CommandLine;
using CommandLine.Text;

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

        [Option('o', "outfile", DefaultValue = null, HelpText = "Output results to this file path instead of printing to console")]
        public string outfile { get; set; }

        [Option('e', "echo", DefaultValue = false, HelpText = "Echo the pre-transformed records as CSVs")]
        public bool echo { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
