using ByteSizeLib;
using System.Collections.Generic;

namespace Lwgh.Commands
{
    public class LanguagesCommand : Command
    {
        public LanguagesCommand(string[] args) : base(args)
        {
        }
        
        public override int Run()
        {
            string repo = args[1];
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Lwgh/1.0");
            var task = Task.Run(() => client.GetAsync($"https://api.github.com/repos/{repo}/languages"));
            task.Wait();
            var result = task.Result;
            bool success = true;
            if (!result.IsSuccessStatusCode)
            {
                Console.Error.WriteLine("*** Repo Languages Load Error");
                Console.Error.WriteLine($"HTTP status code: {result.StatusCode}");
                success = false;
            }
            string response = result.Content.ReadAsStringAsync().Result;
            if (!success)
            {
                Console.Error.WriteLine(response);
                return 1;
            }

            Console.WriteLine($"Languages used by {repo}:");

            // I just didn't want to use a JSON parser.
            string[] respSplit = response.Split(',');
            int sizeTotal = 0;
            for (int i = 0; i < respSplit.Length; i++)
            {
                string langRaw = respSplit[i];
                string[] langRawSplit = langRaw.Split(':');
                string langName = langRawSplit[0];
                langName = langName.Replace("{", string.Empty);
                langName = langName.Replace("\"", string.Empty);

                string sizeStr = langRawSplit[1];
                sizeStr = sizeStr.Replace("}", string.Empty);
                int sizeNum = int.Parse(sizeStr);
                sizeTotal += sizeNum;
                ByteSize bs = ByteSize.FromBytes(sizeNum);

                Console.WriteLine($"{i + 1}. {langName}: {bs.KiloBytes:0.##} KB / {bs.KibiBytes:0.##} KiB / {sizeNum} bytes");
            }
            ByteSize bsTotal = ByteSize.FromBytes(sizeTotal);
            Console.WriteLine($"Total: {bsTotal.KiloBytes:0.##} KB / {bsTotal.KibiBytes:0.##} KiB / {sizeTotal} bytes");
            
            return 0;
        }
    }
}
