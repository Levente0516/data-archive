public class Beer
{
    public double alcohol;
    public Type packageing;
    public double volume;
    public String color;

    public Beer(double alcohol, Type packageing, double volume, String color)
    {
        this.alcohol = alcohol;
        this.packageing = packageing;
        this.volume = volume;
        this.color = color;
    }

    public void drink()
    {
        this.volume /= 2;
    }

    @Override
    public boolean equals(Object obj)
    {
        if(!(obj instanceof Beer)) return false;
        Beer other = (Beer)obj;
        return this.alcohol == other.alcohol;
    }

    @Override
    public int hashCode()
    {
        return super.hashCode();
    }
}