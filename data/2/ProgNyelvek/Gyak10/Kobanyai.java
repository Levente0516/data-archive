public class Kobanyai extends Beer
{
    public String jutalomIdeje;

    public Kobanyai()
    {
        super(4.3, Type.CANNED, 0.5, "Light");
        this.jutalomIdeje = "Nap végén!";
    }

    @Override
    public void drink()
    {
        this.volume = 0;
    }

    @Override
    public boolean equals(Object obj)
    {
        return super.equals(obj) && ((Kobanyai)obj).jutalomIdeje == "Nap végén!";
    }
}