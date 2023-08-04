using System.Diagnostics.Contracts;

abstract class Shape {
    // Общие поля и методы для всех геометрических фигур
    public abstract double getArea();
    public abstract double getPerimeter();
}

/// <summary>
/// Класс для круга
/// </summary>
class Circle : Shape {
    private readonly double radius;

    public Circle(double radius) {
        Contract.Requires(radius > 0);
        this.radius = radius;
    }

    public override double getArea() {
        return Math.PI * radius * radius;         
    }

    public override double getPerimeter() {
        double perimeter = 2 * Math.PI * radius;
        Contract.Ensures(perimeter > 0);
        return perimeter;
    }
}


/// <summary>
/// Класс для прямоугольника
/// </summary>
class Rectangle : Shape {
    private readonly double length;
    private readonly double width;
    
    public Rectangle(double length, double width) {
        Contract.Requires(length > 0 && width > 0);
        this.length = length;
        this.width = width;
    }

    public override double getArea() {
        return length * width;
    }

    public override double getPerimeter() {
        return 2 * (length + width);
    }
}

/// <summary>
/// Класс для треугольника
/// </summary>

class Triangle : Shape {
    private readonly double side1;
    private readonly double side2;
    private readonly double side3;

    public Triangle(double side1, double side2, double side3) {
        Contract.Requires(side1 > 0 && side2 > 0 && side3 > 0);
        this.side1 = side1;
        this.side2 = side2;
        this.side3 = side3;
    }

    public override double getArea () {
        double s = (side1 + side2 + side3) / 2;
        return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
    }

    public override double getPerimeter() {
        return side1 + side2 + side3;
    }
}

/// <summary>
/// Главный класс приложения
/// </summary>
public class GeometryApp {
    public static void Main(String[] args) {
        // Пример использования конкретных классов геометрических фигур
        Shape circle = new Circle(-5.0);
        Console.WriteLine("Площадь круга: " + circle.getArea());
        Console.WriteLine("Периметр круга: " + circle.getPerimeter());

        Shape rectangle = new Rectangle(4.0, 6.0);
        Console.WriteLine("Площадь прямоугольника: " + rectangle.getArea());
        Console.WriteLine("Периметр прямоугольника: " + rectangle.getPerimeter());

        Shape triangle = new Triangle(3.0, 4.0, 5.0);
        Console.WriteLine("Площадь треугольника: " + triangle.getArea());
        Console.WriteLine("Периметр треугольника: " + triangle.getPerimeter());
    }
}