namespace Pr3;

public class Figure
{
    private Point[] points;

    public Figure(Point point1, Point point2, Point point3)
    {
        points = new Point[]{point1, point2, point3};
    }
    
    public Figure(Point point1, Point point2, Point point3, Point point4)
    {
        points = new Point[]{point1, point2, point3, point4};
    }
    
    public Figure(Point point1, Point point2, Point point3, Point point4, Point point5)
    {
        points = new Point[]{point1, point2, point3, point4, point5};
    }

    private double LengthSide(Point A, Point B)
    {
        return Math.Sqrt(Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2));
    }

    public double PerimeterCalculator()
    {
        double perimeter = 0;
        
        for (int i = 0; i < points.Length; i++)
        {
            perimeter += LengthSide(points[i], points[(i + 1) % points.Length]);
        }

        return perimeter;
    }

    public string GetName()
    {
        string name = String.Empty;

        foreach (Point point in points)
        {
            name += point.Name;
        }

        return name;
    }
    
}