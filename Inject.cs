using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProfitRobots.MQ4Inject
{
    class Inject
    {
        public Inject(InjectOptions options)
        {
            _options = options;
        }
        private readonly InjectOptions _options;

        public async Task<int> StartAsync()
        {
            var text = System.IO.File.ReadAllText(_options.SourceFile);
            var replacer = new Replacer();
            text = replacer.Replace(text, _options.Sources);
            var targetFile = _options.TargetFile ?? _options.SourceFile;
            System.IO.File.WriteAllText(targetFile, text);
            return await Task.FromResult(0);
        }

    }
}
