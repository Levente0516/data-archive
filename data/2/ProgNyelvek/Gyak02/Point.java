public class Point
{
    double x;
    double y;

    public void move(double dx, double dy)
    {
        this.x += dx;
        this.y += dy;
    }

    Point(double a, double b)
    {
        this.x = a;
        this.y = b;
    }

    public void mirror(Point p)
    {
        this.x += 2*(p.x - this.x);
        this.y += 2*(p.y - this.y);  
    }

    public double distance(Point p)
    {
        return Math.sqrt(((p.x - this.x) * (p.x - this.x)) + ((p.y - this.y) * (p.y - this.y)));
    }
}