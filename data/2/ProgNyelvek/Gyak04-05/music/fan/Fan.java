package music.fan;
import music.recording.Artist;
import music.recording.RecordLabel;

public class Fan
{
    private final String name;
    private final Artist favourite;
    private int moneySpent;

    public Fan(String n, Artist Art)
    {
        this.name = n;
        this.favourite = Art;
    }

    public String getName()
    {
        return this.name;
    }

    public Artist getFavourite()
    {
        return this.favourite;
    }

    public int getMoneySpent()
    {
        return this.moneySpent;
    }

    public int buyMerchandise(int n, Fan... m)
    {
        if (m.length == 1)
        {
            return (int)(n*0.9);
        }
        else if (m.length >= 2)
        {
            return (int)(n*0.8);
        }
        else
        {
            return n;
        }
    }

    public boolean favesAtSameLabel(Fan m)
    {
        if (this.favourite == m.favourite)
        {
            return true;
        }

        return false;
    }

    public String toString1()
    {
        return "name: " + name + " favourite: " + favourite + "moneySpent: " + moneySpent; 
    }

    public String toString2()
    {
        return "name = '%s', favourite = '%s', moneySpent = '%d'".formatted(name, favourite, moneySpent);
    }

    public String toString3()
    {
        return String.format("name = '%s', favourite = '%s', moneySpent = '%d'", name, favourite, moneySpent);
    }

    public String toString4()
    {
        StringBuilder sb = new StringBuilder();
        sb.append("name = ").append(name).append(" favourite = ").append(favourite).append(" moneySpent = ").append(moneySpent);
        return sb.toString();
    }
}