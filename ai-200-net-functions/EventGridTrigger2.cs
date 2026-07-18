// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using Azure.Messaging;
using Azure.Messaging.EventGrid;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;

namespace ai_200_net_functions;

public class EventGridTrigger2
{
    private readonly ILogger<EventGridTrigger2> _logger;

    public EventGridTrigger2(ILogger<EventGridTrigger2> logger)
    {
        _logger = logger;
    }

    [Function(nameof(EventGridTrigger2))]
    public void Run([EventGridTrigger] CloudEvent cloudEvent)
    {
        _logger.LogInformation("C# EventGridTrigger2 function triggered.");
        //_logger.LogInformation("Event type: {type}, Event subject: {subject}", cloudEvent.Type, cloudEvent.Subject);
        _logger.LogInformation("Event type: {type}", cloudEvent.Type);
        _logger.LogInformation("Event topic: {source}", cloudEvent.Source);
        _logger.LogInformation("Event subject: {subject}", cloudEvent.Subject);
        _logger.LogInformation("Event data: {data}", cloudEvent.Data);
    }
}