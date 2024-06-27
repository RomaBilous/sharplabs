namespace Pr3;

public class Book
{
    private Title title;
    private Content content;
    private Author author;

    public Book(string title, string author, string content)
    {
        this.title = new Title(title);
        this.author = new Author(author);
        this.content = new Content(content);
    }

    public void Show()
    {
        title.Show();
        author.Show();
        content.Show();
    }
}