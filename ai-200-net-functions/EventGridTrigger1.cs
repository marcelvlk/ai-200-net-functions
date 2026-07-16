// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using Azure.Messaging;
using Azure.Messaging.EventGrid;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;

namespace ai_200_net_functions;

public class EventGridTrigger1
{
    private readonly ILogger<EventGridTrigger1> _logger;

    public EventGridTrigger1(ILogger<EventGridTrigger1> logger)
    {
        _logger = logger;
    }

    [Function(nameof(EventGridTrigger1))]
    public void Run([EventGridTrigger] EventGridEvent eventGridEvent)
    {
        _logger.LogInformation("C# EventGridTrigger1 function triggered.");
        _logger.LogInformation("Event type: {type}, Event subject: {subject}", eventGridEvent.EventType, eventGridEvent.Subject);
    }
}
