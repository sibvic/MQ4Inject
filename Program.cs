using CommandLine;

namespace ProfitRobots.MQ4Inject
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<InjectOptions>(args)
                .MapResult(
                    (InjectOptions opts) => new Inject(opts).StartAsync().Result,
                    errs => 1);
        }
    }
}
