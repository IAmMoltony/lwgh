namespace Lwgh.Commands
{
    public class OctocatCommand : Command
    {
        public OctocatCommand(string[] args) : base(args)
        {
        }

        public override int Run()
        {
            string octocatString = args.Count() >= 2 ? args[1] : "";
            string apiQuery;
            if (string.IsNullOrEmpty(octocatString))
            {
                // no string provided; don't insert ?s param
                apiQuery = "https://api.github.com/octocat";
            }
            else
            {
                apiQuery = $"https://api.github.com/octocat?s={octocatString}";
            }

            HttpClient client = new();
            client.DefaultRequestHeaders.Add("User-Agent", "Lwgh/1.0");
            var task = Task.Run(() => client.GetAsync(apiQuery));
            task.Wait();
            var result = task.Result;
            bool success = true;
            if (!result.IsSuccessStatusCode)
            {
                Console.Error.WriteLine("*** Octocat Load Error");
                Console.Error.WriteLine($"HTTP status code: {result.StatusCode}");
                success = false;
            }
            string response = result.Content.ReadAsStringAsync().Result;
            if (!success)
            {
                Console.Error.WriteLine(response);
                return 1;
            }

            Console.WriteLine(response);

            return 0;
        }
    }
}
