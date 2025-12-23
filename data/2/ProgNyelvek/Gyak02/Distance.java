public class Distance
{
    public static void main(String[] args)
    {
        double sum = 0;
        for (int i = 0; i < args.length - 2; i++)
        {
            Point egyik = new Point(Integer.parseInt(args[i]), Integer.parseInt(args[i+1]));
            Point masik = new Point(Integer.parseInt(args[i+2]), Integer.parseInt(args[i+3]));

            sum += egyik.distance(masik);
            i++;
        }
        System.out.println(sum);
    }
}