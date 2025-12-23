public class Complex
{
    double re;
    double im;

    Complex(double a, double b)
    {
        this.re = a;
        this.im = b;
    }

    public double abs()
    {
        return this.re*this.re + this.im*this.im;
    }

    public void add(Complex c)
    {
        this.re += c.re;
        this.im += c.im;
    }

    public void sub(Complex c)
    {
        this.re -= c.re;
        this.im -= c.im;
    }

    public void mul(Complex c)
    {
        this.re = this.re * c.re;
        this.im = this.im * c.im;
    }
}