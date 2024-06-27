namespace Pr3;

class Program
{
    static void Main(string[] args)
    {
        //Task1
        Book book1 = new Book("Romeo and Juliet", "William Shakespeare", "Romeo and Juliet is a tragedy written by William Shakespeare early in his career about the romance between two Italian youths from feuding families.");
        book1.Show();

        //Task2
        Point point1 = new Point(1,1,"A");
        Point point2 = new Point(2,3,"B");
        Point point3 = new Point(4,4,"C");
        Point point4 = new Point(6,8,"D");

        Figure figure1 = new Figure(point1, point2, point3, point4);

        Console.WriteLine($"The perimeter of polygon({figure1.GetName()}) is {Math.Round(figure1.PerimeterCalculator(),1)}");
    }
}