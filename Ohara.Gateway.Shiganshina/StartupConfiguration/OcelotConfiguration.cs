using Newtonsoft.Json.Linq;

namespace Ohara.Gateway.Shiganshina.StartupConfiguration;

public static class OcelotConfiguration
{
    /// <summary>
    /// Generate Ocelot Configurations Based On "Configuration" Folder 
    /// </summary>
    public static IConfigurationRoot GenerateConfiguration(IWebHostEnvironment hostingEnvironment)
    {
        var ocelotJson = new JObject();
        foreach (var jsonFilename in Directory.EnumerateFiles("OcelotConfiguration", "ocelot.*.json",
                     SearchOption.AllDirectories))
        {
            using var fi = File.OpenText(jsonFilename);
            var json = JObject.Parse(fi.ReadToEnd());
            ocelotJson.Merge(json, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Union
            });
        }

        if (File.Exists("ocelot.json"))
            File.Delete("ocelot.json");

        File.WriteAllText("ocelot.json", ocelotJson.ToString());

        if (hostingEnvironment == null) throw new InvalidOperationException("WebHostBuilder Is Empty!");

        var builder = new ConfigurationBuilder()
            .SetBasePath(hostingEnvironment.ContentRootPath)
            .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"ocelot.{hostingEnvironment.EnvironmentName}.json",
                optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json",
                optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        return builder.Build();
    }
}