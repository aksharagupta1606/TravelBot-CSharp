using System;

Console.WriteLine("==================================");
Console.WriteLine("       TRAVELBOT - DEMO MODE");
Console.WriteLine("==================================");
Console.WriteLine("Welcome! Your local TravelBot is ready.");

while (true)
{
    Console.WriteLine("\nWhat would you like to do?");
    Console.WriteLine("1. Currency Converter");
    Console.WriteLine("2. Create Travel Itinerary");
    Console.WriteLine("3. Demo Flight Booking");
    Console.WriteLine("4. Exit");

    Console.Write("\nEnter your choice: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ConvertCurrency();
            break;

        case "2":
            CreateItinerary();
            break;

        case "3":
            Console.WriteLine("\nDEMO FLIGHT BOOKING");
            Console.WriteLine("This is only a demonstration.");
            Console.WriteLine("No actual flight has been booked.");
            break;

        case "4":
            Console.WriteLine("Thank you for using TravelBot!");
            return;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}

void ConvertCurrency()
{
    Console.WriteLine("\nSupported currencies: USD, INR, EUR, GBP, JPY");

    Console.Write("Enter source currency: ");
    string from = (Console.ReadLine() ?? "").ToUpper();

    Console.Write("Enter target currency: ");
    string to = (Console.ReadLine() ?? "").ToUpper();

    Console.Write("Enter amount: ");

    if (!double.TryParse(Console.ReadLine(), out double amount) || amount < 0)
    {
        Console.WriteLine("Please enter a valid amount.");
        return;
    }

    // Illustrative demo rates. Not live exchange rates.
    double GetRate(string currency)
    {
        return currency switch
        {
            "USD" => 1.0,
            "INR" => 83.0,
            "EUR" => 0.92,
            "GBP" => 0.79,
            "JPY" => 150.0,
            _ => 0.0
        };
    }

    double fromRate = GetRate(from);
    double toRate = GetRate(to);

    if (fromRate == 0 || toRate == 0)
    {
        Console.WriteLine("Currency not supported.");
        return;
    }

    double result = amount / fromRate * toRate;

    Console.WriteLine(
        $"\nConverted amount: {result:F2} {to}");
    Console.WriteLine("Note: These are sample rates only.");
}

void CreateItinerary()
{
    Console.Write("\nEnter your destination: ");
    string destination = Console.ReadLine() ?? "";

    Console.Write("How many days is your trip? ");

    if (!int.TryParse(Console.ReadLine(), out int days) ||
        days < 1 || days > 30)
    {
        Console.WriteLine("Please enter a number from 1 to 30.");
        return;
    }

    Console.WriteLine($"\nSample itinerary for {destination}:");

    for (int day = 1; day <= days; day++)
    {
        Console.WriteLine($"\nDay {day}:");
        Console.WriteLine("- Morning: Explore local attractions.");
        Console.WriteLine("- Afternoon: Visit popular places.");
        Console.WriteLine("- Evening: Enjoy local food and shopping.");
    }

    Console.WriteLine("\nHave a wonderful trip!");
}