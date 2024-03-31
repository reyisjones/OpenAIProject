// Note: The Azure OpenAI client library for .NET is in preview.
// Install the .NET library via NuGet: dotnet add package Azure.AI.OpenAI --version 1.0.0-beta.5
using Azure;
using Azure.AI.OpenAI;
using DotNetEnv;
using static System.Environment;

public class OpenAiChat
{
    // Get the environment variables or set the values here
    string endpoint = GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
    string key = GetEnvironmentVariable("AZURE_OPENAI_API_KEY");
    string modelName = GetEnvironmentVariable("AZURE_OPENAI_MODEL_NAME");

    public async void AIClient(string question)
    {
        Env.Load();
        // Get the environment variables or set the values here
        // Console.WriteLine("Endpoint: " + endpoint); // Debugging
        // Console.WriteLine("ModelName: " + modelName); // Debugging
        // Console.WriteLine("Key: " + key); // Debugging

        OpenAIClient client = new OpenAIClient(new Uri( endpoint ),new AzureKeyCredential( key ));

        var chatCompletionsOptions = new ChatCompletionsOptions()
        {
            Messages =  {
                    new ChatMessage(ChatRole.System, @"You are an AI assistant that helps people find information."),
                    new ChatMessage(ChatRole.User, @"Does Azure OpenAI support GPT-4"),
                    new ChatMessage(ChatRole.Assistant, @"Yes it does."),
                    new ChatMessage(ChatRole.User, question),
            },
            MaxTokens = 400
        };
        if(string.IsNullOrWhiteSpace(modelName))
        {
            Console.WriteLine("No ModelName provided.\nThis application cannot be used without the proper configuration.\nPlease configure the ModelName");
            return;
        }
        Response<ChatCompletions> response = await client.GetChatCompletionsAsync(modelName, chatCompletionsOptions);
        var botResponse = response.Value.Choices.First().Message.Content;
        Console.WriteLine("Bot Response: " + botResponse);
    }
}