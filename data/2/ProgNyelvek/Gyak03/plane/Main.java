package plane;

public class Main
{
    public static void main(String[] args)
    {
        PublicCircle PublicCircle = new PublicCircle();

        System.out.println("Terulet:" + PublicCircle.getArea());

        PublicCircle.x = 5;
        PublicCircle.y = 2;
        PublicCircle.radius = 10;

        System.out.println("Terulet:" + PublicCircle.getArea());
    }
} 