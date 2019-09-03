using System;

namespace ProfitRobots.MQ4Inject
{
    class InputOptionsParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public static InputOptions Parse(string[] args)
        {
            if (args.Length == 0)
                return null;

            var option = args.GetEnumerator();
            if (!option.MoveNext())
                return null;
            
            var options = new InputOptions();
            options.FileName = (string)option.Current;
            while (option.MoveNext())
            {
                switch (option.Current)
                {
                    case "--sources":
                        if (!option.MoveNext())
                            throw new ArgumentException("Sources should be specified");
                        options.Sources = ((string)option.Current);
                        break;
                }
            }
            return options;
        }

        internal static void PrintHelp()
        {
            Console.WriteLine("--sources path");
        }
    }
}
