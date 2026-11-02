using Microsoft.SemanticKernel;

namespace TravelBot.Plugins;

public sealed class TravelItineraryPlugin
{
    [KernelFunction("CreateItinerary")]
    [System.ComponentModel.Description("Creates a suggested travel itinerary after learning the destination and trip duration.")]
    public string CreateItinerary(
        [System.ComponentModel.Description("Travel destination")] string destination,
        [System.ComponentModel.Description("Number of days")] int days,
        [System.ComponentModel.Description("Optional interests such as food, history, nature, or shopping")] string interests = "popular attractions")
    {
        if (days < 1 || days > 60)
            return "Please choose a trip length between 1 and 60 days.";

        return $"Create a {days}-day suggested itinerary for {destination}. " +
               $"Focus on {interests}. Organize the response by day, include a reasonable pace, " +
               "and remind the traveler to verify opening hours, transport, prices, and visa requirements.";
    }
}
