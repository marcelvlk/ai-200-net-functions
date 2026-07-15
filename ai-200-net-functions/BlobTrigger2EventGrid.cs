using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ai_200_net_functions;

public class BlobTrigger2EventGrid
{
    private readonly ILogger<BlobTrigger2EventGrid> _logger;

    public BlobTrigger2EventGrid(ILogger<BlobTrigger2EventGrid> logger)
    {
        _logger = logger;
    }

    [Function(nameof(BlobTrigger2EventGrid))]
    public async Task Run([BlobTrigger("container1/{name}", Source = BlobTriggerSource.EventGrid, Connection = "AzureWebJobsStorage")] Stream stream, string name)
    {
        _logger.LogInformation("C# BlobTrigger2EventGrid function triggered.");
        using var blobStreamReader = new StreamReader(stream);
        var content = await blobStreamReader.ReadToEndAsync();
        _logger.LogInformation("C# Blob Trigger (using Event Grid) processed blob\n Name: {name} \n Data: {content}", name, content);
    }
}
