public class A{
    public static void main(String[] args){
        /*String a = System.console().readLine();
        String b = System.console().readLine();
        int aa = Integer.parseInt(a);
        int bb = Integer.parseInt(b);
        for (double i = aa; i < bb; i++)
        {
            System.out.println(i/2);
        }*/
       /*
        double a = 5;
        double b = 12;

        System.out.println(a + b);
        System.out.println(a - b);
        System.out.println(a * b);
        System.out.println(a / b);
        System.out.println(b % a);
        */

        System.out.println("Adjon meg egy szamot: ");
        String k = System.console().readLine();
        int n = Integer.parseInt(k);

        int i = 1;
        while(n != 1)
        {
            i = i*n;
            n--;
        }

        System.out.println(i);
    }
}