package plane;

public class CircleMain
{
    public static void main(String[] args)
    {
        Circle Circle = new Circle(0,0,1);

        System.out.println("Terulet:" + Circle.getArea());

        Circle.setX(5);
        Circle.setY(2);
        Circle.setRadius(10);

        System.out.println("Terulet:" + Circle.getArea());
    }
} 