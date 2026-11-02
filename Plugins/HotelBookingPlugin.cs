using Microsoft.SemanticKernel;

namespace TravelBot.Plugins;

public sealed class HotelBookingPlugin
{
    [KernelFunction("book_hotel")]
    [System.ComponentModel.Description("Demonstration hotel function. Does not contact a hotel or make a real reservation.")]
    public string BookHotel(
        string destination,
        string checkInDate,
        string checkOutDate)
        => $"DEMO ONLY: A hotel booking request for {destination}, {checkInDate} to {checkOutDate}, was received. No real room has been reserved.";
}
