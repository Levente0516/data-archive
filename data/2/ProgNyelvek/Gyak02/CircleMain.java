public class CircleMain
{
    public static void main(String[] args)
    {
        Circle p = new Circle();
        p.x = 1;
        p.y = 1;
        p.r = 3;

        System.out.println(p.x + " " + p.y + " " + p.r);
        p.enlarge(3);
        System.out.println(p.x + " " + p.y + " " + p.r);
        System.out.println(p.getArea());
    }
}