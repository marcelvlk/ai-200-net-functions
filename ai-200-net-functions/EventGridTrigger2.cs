// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using System;
using Azure.Messaging;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

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
    }
}