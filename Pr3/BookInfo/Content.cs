namespace Pr3;

public class Content
{
    private string content;

    public Content(string content)
    {
        this.content = content;
    }
    
    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Content:{content}");
        Console.ResetColor();
    }
}