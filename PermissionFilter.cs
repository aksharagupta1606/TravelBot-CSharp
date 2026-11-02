#pragma warning disable SKEXP0001
using Microsoft.SemanticKernel;

namespace TravelBot;

public sealed class PermissionFilter : IFunctionInvocationFilter
{
    public async Task OnFunctionInvocationAsync(
        FunctionInvocationContext context,
        Func<FunctionInvocationContext, Task> next)
    {
        var isBooking =
            (context.Function.PluginName == "FlightBooking" && context.Function.Name == "book_flight") ||
            (context.Function.PluginName == "HotelBooking" && context.Function.Name == "book_hotel");

        if (isBooking)
        {
            Console.WriteLine();
            Console.WriteLine("TravelBot wants to continue with a booking request.");
            Console.Write("Do you approve this demo operation? (Y/N): ");
            var answer = Console.ReadLine();

            if (!string.Equals(answer, "Y", StringComparison.OrdinalIgnoreCase))
            {
                context.Result = new FunctionResult(
                    context.Function,
                    "The operation was not approved by the user.");
                return;
            }
        }

        await next(context);
    }
}
#pragma warning restore SKEXP0001
