using Microsoft.SemanticKernel;

namespace TravelBot.Plugins;

public sealed class FlightBookingPlugin
{
    [KernelFunction("book_flight")]
    [System.ComponentModel.Description("Demonstration booking function. Does not contact an airline or make a real reservation.")]
    public string BookFlight(
        string destination,
        string travelDate)
        => $"DEMO ONLY: A flight booking request for {destination} on {travelDate} was received. No real ticket has been booked.";
}
