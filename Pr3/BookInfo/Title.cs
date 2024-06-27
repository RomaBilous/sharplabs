namespace Pr3;

public class Title
{
    private string title;

    public Title(string title)
    {
        this.title = title;
    }

    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Title:{title}");
        Console.ResetColor();
    }
    
    
}