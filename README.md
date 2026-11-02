# TravelBot – AI Travel Assistant

A guided-project proof of concept based on the Microsoft Learn material supplied by the learner.

## Features
- Currency conversion through a Semantic Kernel native plugin.
- Travel itinerary prompt/function and conversational trip planning.
- Budget and trip-duration context in the conversation.
- Flight and hotel demonstration functions protected by a permission filter.
- Chat history and automatic function calling.

## Requirements
- .NET 8 SDK
- Visual Studio Code (or another .NET IDE)
- Azure OpenAI deployment, endpoint, and API key

## Setup
1. Open this folder in Visual Studio Code.
2. Edit `appsettings.json` and enter your Azure OpenAI deployment name, endpoint, and API key.
3. Review `currencies.txt`. Its rates are sample values for demonstration only.
4. Open a terminal in this folder and run:

   ```bash
   dotnet restore
   dotnet run
   ```

## Example prompts
- `Convert 52000 VND to USD.`
- `I want to visit Japan. Help me plan an itinerary.`
- `Suggest destinations for my holiday. My budget is $6000.`
- `Request a demo flight booking to Tokyo on 19 January.`
- `Request a demo hotel booking in Tokyo from 19 January to 22 January.`

## Important limitations
- This is a proof of concept, not a production travel booking system.
- Flight and hotel functions are demo stubs. They do not search live inventory, charge money, or create reservations.
- The currency rates in `currencies.txt` are illustrative and may be outdated. Do not use them for financial decisions.
- Keep API keys private. Do not upload `appsettings.json` containing real credentials to GitHub.
- The Semantic Kernel APIs can vary by package version. This project targets the package versions listed in the `.csproj`; if Microsoft Learn's current instructions use a different version, align the package versions and API calls accordingly.
