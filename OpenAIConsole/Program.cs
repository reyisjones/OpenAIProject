// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to the Azure OpenAI Console!\nFeel free to ask any questions, and you'll receive answers based on your inquiries.\nAsk away:");

// Create an instance of the OpenAiChat class
OpenAiChat chatAi = new OpenAiChat();

// Continue running until the Esc key is pressed
while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
{
    var question = Console.ReadLine();
    if (string.IsNullOrWhiteSpace( question )) break; // Exit the loop if the user presses Enter

    chatAi.AIClient(question);
}

Console.WriteLine("Exiting..."); // Display a message when Esc is pressed
