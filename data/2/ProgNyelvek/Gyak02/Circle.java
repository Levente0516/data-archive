public class Circle
{
    double x, y;
    double r;

    public void enlarge(double f)
    {
        this.r = this.r*f;
    }

    public double getArea()
    {
        return Math.PI*this.r*this.r;
    }
}