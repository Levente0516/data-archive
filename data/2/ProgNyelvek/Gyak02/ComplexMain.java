public class ComplexMain
{
    public static void main(String[] args)
    {
        Complex alpha = new Complex(3,2);
        Complex beta = new Complex(1,2);

        alpha.add(beta);

        System.out.println(alpha.re + " " + alpha.im);
    }
}