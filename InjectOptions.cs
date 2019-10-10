
using CommandLine;

namespace ProfitRobots.MQ4Inject
{
    [Verb("inject", HelpText = "Injects includes into the code.")]
    class InjectOptions
    {
        [Option("sources", Required = true, HelpText = "Path to sources")]
        public string Sources { get; set; }

        [Option("source-file", Required = true, HelpText = "Source file.")]
        public string SourceFile { get; set; }

        [Option("target-file", HelpText = "Target file. The save as source by default.")]
        public string TargetFile { get; set; }
    }
}
