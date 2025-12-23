public class PointMain
{
    public static void main(String[] args)
    {
        Point p = new Point(0,0);
        Point k = new Point(3,4);

        System.out.println("Cordinates before moving: " + p.x + " " + p.y);

        //p.move(1,1);

        System.out.println("Cordinates after moving: " + p.x + " " + p.y);

        //p.mirror(k);

        System.out.println("Cordinates after mirror: " + p.x + " " + p.y);

        System.out.println("Distance: " + p.distance(k));
    }
}