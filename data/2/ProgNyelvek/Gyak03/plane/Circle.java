package plane;

public class Circle
{

    private double x, y, radius = 0;

    public Circle(double a, double b, double r)
    {
        if (r <= 0) throw new IllegalArgumentException("!!!");
        this.x = a;
        this.y = b;
        this.radius = r;
    }

    public double getArea()
    {
        return radius*radius*Math.PI;
    }

    public void setX(double x)
    {
        this.x = x;
    }

    public double getX()
    {
        return this.x;
    }
    
    public void setY(double y)
    {
        this.y = y;
    }

    public double getY()
    {
        return this.y;
    }

    public void setRadius(double radius)
    {
        if (radius <= 0) throw new IllegalArgumentException("!!!");
        this.radius = radius;
    }
    public double getRadius()
    {
        return this.radius;
    }
}