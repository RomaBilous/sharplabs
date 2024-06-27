namespace Pr3;

public class Author
{
    private string author;

    public Author(string author)
    {
        this.author = author;
    }
    
    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Author:{author}");
        Console.ResetColor();
    }
}