using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProfitRobots.MQ4Inject
{
    class Replacer
    {
        readonly List<string> _alreadyIncluded = new List<string>();
        readonly Regex _pattern = new Regex("#include <([^>]+)>");

        public string Replace(string text, string basePath)
        {
            bool replaced = true;
            while (replaced)
            {
                (text, replaced) = ReplaceAll(text, basePath);
            }
            return text;
        }

        private (string, bool) ReplaceAll(string text, string basePath)
        {
            var matches = _pattern.Matches(text);
            bool replaced = false;
            foreach (Match match in matches)
            {
                var filePath = System.IO.Path.Combine(basePath, match.Groups[1].Value);
                if (!System.IO.File.Exists(filePath))
                {
                    Console.WriteLine(match.Groups[1].Value + " skipped");
                    continue;
                }
                var module = System.IO.File.ReadAllText(filePath);
                var path = System.IO.Directory.GetParent(filePath).FullName;
                module = Replace(module, path);
                var filename = System.IO.Path.GetFileName(match.Groups[1].Value);
                if (_alreadyIncluded.Contains(filename))
                {
                    text = text.Replace(match.Groups[0].Value, "");
                }
                else
                {
                    _alreadyIncluded.Add(filename);
                    text = text.Replace(match.Groups[0].Value, module);
                    replaced = true;
                }
            }

            return (text, replaced);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            InputOptions options = ParseOptions(args);
            if (options == null)
                return;

            var text = System.IO.File.ReadAllText(options.FileName);
            var replacer = new Replacer();
            text = replacer.Replace(text, options.Sources);
            System.IO.File.WriteAllText(options.FileName, text);
        }

        static InputOptions ParseOptions(string[] args)
        {
            InputOptions options;
            try
            {
                options = InputOptionsParser.Parse(args);
                if (options == null)
                {
                    InputOptionsParser.PrintHelp();
                    return null;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return options;
        }
    }
}
