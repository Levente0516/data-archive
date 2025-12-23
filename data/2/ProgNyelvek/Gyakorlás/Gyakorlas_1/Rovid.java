public class Rovid
{
    public static void main(String[] args)
    {
        //String name = System.console().readLine();

        //System.console().printf(args[0]);

        /*for (double i = 1; i < 5; i++)
        {
            System.out.println(i/2);
        }*/

       System.out.println("Adja meg az elso majd a masodik szamot is: ");

       int elso = Integer.parseInt(System.console().readLine());
       
       int masodik = Integer.parseInt(System.console().readLine());

       for (double i = elso; i < masodik; i++)
       {
            System.out.println(i/2);
       }
    }
}