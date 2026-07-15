using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ai_200_net_functions;

public class BlobTrigger1
{
    private readonly ILogger<BlobTrigger1> _logger;

    public BlobTrigger1(ILogger<BlobTrigger1> logger)
    {
        _logger = logger;
    }

    [Function(nameof(BlobTrigger1))]
    public async Task Run([BlobTrigger("container1/{name}", Connection = "AzureWebJobsStorage")] Stream stream, string name)
    {
        _logger.LogInformation("C# BlobTrigger1 function triggered.");
        using var blobStreamReader = new StreamReader(stream);
        var content = await blobStreamReader.ReadToEndAsync();
        _logger.LogInformation("C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}", name, content);
    }
}
