class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 3, 4));
        shapes.Add(new Circle("Green", 2));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine("Color: " + shape.Color);
            Console.WriteLine("Area: " + shape.GetArea());
            Console.WriteLine();
        }
    }
}